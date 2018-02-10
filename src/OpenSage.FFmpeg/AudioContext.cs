using System;
using System.Collections.Generic;
using System.Text;
using FFmpeg.AutoGen;

namespace OpenSage.FFmpeg
{
    public sealed unsafe class AudioContext : StreamContext
    {
        private AVFrame* _resampled;
        private SwrContext* _resampler;
        private AVSampleFormat _smplFmt;
        /// <summary>
        /// use a chain of buffers to ensure smooth playback
        /// </summary>
        private List<int> _buffers;
        private int _currentBuffer = 0;
        private readonly int _chainSize = 4;

        /// <summary>
        /// Called once for each audio stream
        /// </summary>
        /// <param name="stream">the underlying libav stream</param>
        /// <param name="source">the container</param>
        public AudioContext(AVStream* stream, Source source) : base(stream, source)
        {
            _type = StreamType.Audio;
            _info = new AudioStreamInfo()
            {
                BitRate = _codecCtx->bit_rate,
                Frequency = _codecCtx->sample_rate,
                Channels = _codecCtx->channels
            };
            CreateAudio();
        }

        /// <summary>
        /// Create the audio buffers in the handler. Check if resampling is required
        /// </summary>
        private void CreateAudio()
        {
            var audioHandler = _source.AudioHandler;

            _smplFmt = _codecCtx->sample_fmt;

            switch (_smplFmt)
            {
                //convert planar formats to interleaved formats when requested
                case AVSampleFormat.AV_SAMPLE_FMT_U8P:
                case AVSampleFormat.AV_SAMPLE_FMT_S16P:
                case AVSampleFormat.AV_SAMPLE_FMT_S32P:
                case AVSampleFormat.AV_SAMPLE_FMT_FLTP:
                case AVSampleFormat.AV_SAMPLE_FMT_DBLP:
                    if (audioHandler?.Layout == AudioLayout.Interleaved)
                    {
                        //this is the interval from planar to interleaved formats
                        _smplFmt -= 5;
                    }
                    break;
                case AVSampleFormat.AV_SAMPLE_FMT_S64P:
                    if (audioHandler?.Layout == AudioLayout.Interleaved)
                    {
                        //this is the interval from planar to interleaved formats
                        _smplFmt = AVSampleFormat.AV_SAMPLE_FMT_S64;
                    }
                    break;
            }

            //check if we must perform resampling
            bool resample = (_smplFmt != _codecCtx->sample_fmt);
            if (resample)
            {
                SetupResampler();
            }

            //TODO: fix this to handle the index correctly
            var audioInfo = _info as AudioStreamInfo;

            _buffers = new List<int>();
            if (audioHandler != null)
            {
                for (int i = 0; i < _chainSize; ++i)
                {
                    _buffers.Add(audioHandler.CreateBuffer(audioInfo.Frequency, audioInfo.Channels, audioInfo.BitRate));
                }
            }
        }


        /// <summary>
        /// Called when a new packet arrives
        /// </summary>
        protected override void Update()
        {
            AVFrame* frame = _decoded;

            //check if we must perform resampling
            bool resample = (_smplFmt != _codecCtx->sample_fmt);

            if (resample)
            {
                ffmpeg.swr_convert_frame(_resampler, _resampled, _decoded);
                frame = _resampled;
            }

            //get the size of our data buffer
            int data_size = ffmpeg.av_samples_get_buffer_size(null, _codecCtx->channels, _decoded->nb_samples, _smplFmt, 1);

            var audioHandler = _source.AudioHandler;

            //Only use the first data plane
            var buffer = _buffers[_currentBuffer];
            audioHandler?.UpdateBuffer(buffer,new IntPtr(_decoded->data[0]), data_size);

            if (_currentBuffer==_chainSize)
            {
                _currentBuffer = 0;
            }
        }


        /// <summary>
        /// create a resampler to convert the audio format to our output format
        /// </summary>
        private void SetupResampler()
        {
            _resampled = ffmpeg.av_frame_alloc();
            _resampled->channel_layout = _codecCtx->channel_layout;
            _resampled->sample_rate = _codecCtx->sample_rate;
            _resampled->format = (int)_smplFmt;

            //we only want to change from planar to interleaved
            _resampler = ffmpeg.swr_alloc_set_opts(null,
                (long)_codecCtx->channel_layout,      //Out layout should be identical to input layout
                _smplFmt,
                _codecCtx->sample_rate,    //Out frequency should be identical to input frequency
                (long)_codecCtx->channel_layout,
                _codecCtx->sample_fmt,
                _codecCtx->sample_rate,
                0, null);       //No logging

            if (ffmpeg.swr_init(_resampler) != 0)
            {
                throw new InvalidOperationException("Can't init resampler!");
            }
        }
    }
}
