using System;
using System.Runtime.InteropServices;

#pragma warning disable CS0649

namespace OpenSage.FFmpegNative
{
    internal unsafe struct _iobuf
    {
        internal void* @_Placeholder;
    }

    /// <summary>Rational number (pair of numerator and denominator).</summary>
    internal unsafe struct AVRational
    {
        /// <summary>Numerator</summary>
        internal int @num;
        /// <summary>Denominator</summary>
        internal int @den;
    }

    /// <summary>Describe the class of an AVClass context structure. That is an arbitrary struct of which the first field is a pointer to an AVClass struct (e.g. AVCodecContext, AVFormatContext etc.).</summary>
    internal unsafe struct AVClass
    {
        /// <summary>The name of the class; usually it is the same name as the context structure type to which the AVClass is associated.</summary>
        internal byte* @class_name;
        /// <summary>A pointer to a function which returns the name of a context instance ctx associated with the class.</summary>
        internal IntPtr @item_name;
        /// <summary>a pointer to the first option specified in the class if any or NULL</summary>
        internal AVOption* @option;
        /// <summary>LIBAVUTIL_VERSION with which this structure was created. This is used to allow fields to be added without requiring major version bumps everywhere.</summary>
        internal int @version;
        /// <summary>Offset in the structure where log_level_offset is stored. 0 means there is no such variable</summary>
        internal int @log_level_offset_offset;
        /// <summary>Offset in the structure where a pointer to the parent context for logging is stored. For example a decoder could pass its AVCodecContext to eval as such a parent context, which an av_log() implementation could then leverage to display the parent context. The offset can be NULL.</summary>
        internal int @parent_log_context_offset;
        /// <summary>Return next AVOptions-enabled child or NULL</summary>
        internal IntPtr @child_next;
        /// <summary>Return an AVClass corresponding to the next potential AVOptions-enabled child.</summary>
        internal IntPtr @child_class_next;
        /// <summary>Category used for visualization (like color) This is only set if the category is equal for all objects using this class. available since version (51 &lt;&lt; 16 | 56 &lt;&lt; 8 | 100)</summary>
        internal AVClassCategory @category;
        /// <summary>Callback to return the category. available since version (51 &lt;&lt; 16 | 59 &lt;&lt; 8 | 100)</summary>
        internal IntPtr @get_category;
        /// <summary>Callback to return the supported/allowed ranges. available since version (52.12)</summary>
        internal IntPtr @query_ranges;
    }

    /// <summary>AVOption</summary>
    internal unsafe struct AVOption
    {
        internal byte* @name;
        /// <summary>short English help text</summary>
        internal byte* @help;
        /// <summary>The offset relative to the context structure where the option value is stored. It should be 0 for named constants.</summary>
        internal int @offset;
        internal AVOptionType @type;
        internal AVOption_default_val @default_val;
        /// <summary>minimum valid value for the option</summary>
        internal double @min;
        /// <summary>maximum valid value for the option</summary>
        internal double @max;
        internal int @flags;
        /// <summary>The logical unit to which the option belongs. Non-constant options and corresponding named constants share the same unit. May be NULL.</summary>
        internal byte* @unit;
    }

    /// <summary>List of AVOptionRange structs.</summary>
    internal unsafe struct AVOptionRanges
    {
        /// <summary>Array of option ranges.</summary>
        internal AVOptionRange** @range;
        /// <summary>Number of ranges per component.</summary>
        internal int @nb_ranges;
        /// <summary>Number of componentes.</summary>
        internal int @nb_components;
    }

    internal unsafe struct AVFifoBuffer
    {
        internal byte* @buffer;
        internal byte* @rptr;
        internal byte* @wptr;
        internal byte* @end;
        internal uint @rndx;
        internal uint @wndx;
    }

    /// <summary>Structure to hold side data for an AVFrame.</summary>
    internal unsafe struct AVFrameSideData
    {
        internal AVFrameSideDataType @type;
        internal byte* @data;
        internal int @size;
        internal AVDictionary* @metadata;
        internal AVBufferRef* @buf;
    }

    /// <summary>A reference to a data buffer.</summary>
    public unsafe struct AVBufferRef
    {
        internal AVBuffer* @buffer;
        /// <summary>The data buffer. It is considered writable if and only if this is the only reference to the buffer, in which case av_buffer_is_writable() returns 1.</summary>
        internal byte* @data;
        /// <summary>Size of data in bytes.</summary>
        internal int @size;
    }

    /// <summary>This structure describes decoded (raw) audio or video data.</summary>
    internal unsafe struct AVFrame
    {
        /// <summary>pointer to the picture/channel planes. This might be different from the first allocated byte</summary>
        internal byte_ptrArray8 @data;
        /// <summary>For video, size in bytes of each picture line. For audio, size in bytes of each plane.</summary>
        internal int_array8 @linesize;
        /// <summary>pointers to the data planes/channels.</summary>
        internal byte** @extended_data;
        /// <summary>Video frames only. The coded dimensions (in pixels) of the video frame, i.e. the size of the rectangle that contains some well-defined values.</summary>
        internal int @width;
        /// <summary>Video frames only. The coded dimensions (in pixels) of the video frame, i.e. the size of the rectangle that contains some well-defined values.</summary>
        internal int @height;
        /// <summary>number of audio samples (per channel) described by this frame</summary>
        internal int @nb_samples;
        /// <summary>format of the frame, -1 if unknown or unset Values correspond to enum AVPixelFormat for video frames, enum AVSampleFormat for audio)</summary>
        internal int @format;
        /// <summary>1 -&gt; keyframe, 0-&gt; not</summary>
        internal int @key_frame;
        /// <summary>Picture type of the frame.</summary>
        internal AVPictureType @pict_type;
        /// <summary>Sample aspect ratio for the video frame, 0/1 if unknown/unspecified.</summary>
        internal AVRational @sample_aspect_ratio;
        /// <summary>Presentation timestamp in time_base units (time when frame should be shown to user).</summary>
        internal long @pts;
        /// <summary>PTS copied from the AVPacket that was decoded to produce this frame.</summary>
        internal long @pkt_pts;
        /// <summary>DTS copied from the AVPacket that triggered returning this frame. (if frame threading isn&apos;t used) This is also the Presentation time of this AVFrame calculated from only AVPacket.dts values without pts values.</summary>
        internal long @pkt_dts;
        /// <summary>picture number in bitstream order</summary>
        internal int @coded_picture_number;
        /// <summary>picture number in display order</summary>
        internal int @display_picture_number;
        /// <summary>quality (between 1 (good) and FF_LAMBDA_MAX (bad))</summary>
        internal int @quality;
        /// <summary>for some private data of the user</summary>
        internal void* @opaque;
        internal ulong_array8 @error;
        /// <summary>When decoding, this signals how much the picture must be delayed. extra_delay = repeat_pict / (2*fps)</summary>
        internal int @repeat_pict;
        /// <summary>The content of the picture is interlaced.</summary>
        internal int @interlaced_frame;
        /// <summary>If the content is interlaced, is top field displayed first.</summary>
        internal int @top_field_first;
        /// <summary>Tell user application that palette has changed from previous frame.</summary>
        internal int @palette_has_changed;
        /// <summary>reordered opaque 64 bits (generally an integer or a double precision float PTS but can be anything). The user sets AVCodecContext.reordered_opaque to represent the input at that time, the decoder reorders values as needed and sets AVFrame.reordered_opaque to exactly one of the values provided by the user through AVCodecContext.reordered_opaque</summary>
        internal long @reordered_opaque;
        /// <summary>Sample rate of the audio data.</summary>
        internal int @sample_rate;
        /// <summary>Channel layout of the audio data.</summary>
        internal ulong @channel_layout;
        /// <summary>AVBuffer references backing the data for this frame. If all elements of this array are NULL, then this frame is not reference counted. This array must be filled contiguously -- if buf[i] is non-NULL then buf[j] must also be non-NULL for all j &lt; i.</summary>
        internal AVBufferRef_ptrArray8 @buf;
        /// <summary>For planar audio which requires more than AV_NUM_DATA_POINTERS AVBufferRef pointers, this array will hold all the references which cannot fit into AVFrame.buf.</summary>
        internal AVBufferRef** @extended_buf;
        /// <summary>Number of elements in extended_buf.</summary>
        internal int @nb_extended_buf;
        internal AVFrameSideData** @side_data;
        internal int @nb_side_data;
        /// <summary>Frame flags, a combination of</summary>
        internal int @flags;
        /// <summary>MPEG vs JPEG YUV range. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorRange @color_range;
        internal AVColorPrimaries @color_primaries;
        internal AVColorTransferCharacteristic @color_trc;
        /// <summary>YUV colorspace type. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorSpace @colorspace;
        internal AVChromaLocation @chroma_location;
        /// <summary>frame timestamp estimated using various heuristics, in stream time base - encoding: unused - decoding: set by libavcodec, read by user.</summary>
        internal long @best_effort_timestamp;
        /// <summary>reordered pos from the last AVPacket that has been input into the decoder - encoding: unused - decoding: Read by user.</summary>
        internal long @pkt_pos;
        /// <summary>duration of the corresponding packet, expressed in AVStream-&gt;time_base units, 0 if unknown. - encoding: unused - decoding: Read by user.</summary>
        internal long @pkt_duration;
        /// <summary>metadata. - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal AVDictionary* @metadata;
        /// <summary>decode error flags of the frame, set to a combination of FF_DECODE_ERROR_xxx flags if the decoder produced a frame, but there were errors during the decoding. - encoding: unused - decoding: set by libavcodec, read by user.</summary>
        internal int @decode_error_flags;
        /// <summary>number of audio channels, only used for audio. - encoding: unused - decoding: Read by user.</summary>
        internal int @channels;
        /// <summary>size of the corresponding packet containing the compressed frame. It is set to a negative value if unknown. - encoding: unused - decoding: set by libavcodec, read by user.</summary>
        internal int @pkt_size;
        /// <summary>QP table</summary>
        internal sbyte* @qscale_table;
        /// <summary>QP store stride</summary>
        internal int @qstride;
        internal int @qscale_type;
        internal AVBufferRef* @qp_table_buf;
        /// <summary>For hwaccel-format frames, this should be a reference to the AVHWFramesContext describing the frame.</summary>
        internal AVBufferRef* @hw_frames_ctx;
        /// <summary>AVBufferRef for free use by the API user. FFmpeg will never check the contents of the buffer ref. FFmpeg calls av_buffer_unref() on it when the frame is unreferenced. av_frame_copy_props() calls create a new reference with av_buffer_ref() for the target frame&apos;s opaque_ref field.</summary>
        internal AVBufferRef* @opaque_ref;
        /// <summary>cropping Video frames only. The number of pixels to discard from the the top/bottom/left/right border of the frame to obtain the sub-rectangle of the frame intended for presentation. @{</summary>
        internal ulong @crop_top;
        internal ulong @crop_bottom;
        internal ulong @crop_left;
        internal ulong @crop_right;
        /// <summary>AVBufferRef for internal use by a single libav* library. Must not be used to transfer data between libraries. Has to be NULL when ownership of the frame leaves the respective library.</summary>
        internal AVBufferRef* @private_ref;
    }

    internal unsafe struct AVDictionaryEntry
    {
        internal byte* @key;
        internal byte* @value;
    }

    /// <summary>A single allowed range of values, or a single allowed value.</summary>
    internal unsafe struct AVOptionRange
    {
        internal byte* @str;
        /// <summary>Value range. For string ranges this represents the min/max length. For dimensions this represents the min/max pixel count or width/height in multi-component case.</summary>
        internal double @value_min;
        /// <summary>Value range. For string ranges this represents the min/max length. For dimensions this represents the min/max pixel count or width/height in multi-component case.</summary>
        internal double @value_max;
        /// <summary>Value&apos;s component range. For string this represents the unicode range for chars, 0-127 limits to ASCII.</summary>
        internal double @component_min;
        /// <summary>Value&apos;s component range. For string this represents the unicode range for chars, 0-127 limits to ASCII.</summary>
        internal double @component_max;
        /// <summary>Range flag. If set to 1 the struct encodes a range, if set to 0 a single value.</summary>
        internal int @is_range;
    }

    /// <summary>the default value for scalar options</summary>
    internal unsafe struct AVOption_default_val
    {
        internal long @i64;
        internal double @dbl;
        internal byte* @str;
        internal AVRational @q;
    }

    /// <summary>Descriptor that unambiguously describes how the bits of a pixel are stored in the up to 4 data planes of an image. It also stores the subsampling factors and number of components.</summary>
    internal unsafe struct AVPixFmtDescriptor
    {
        internal byte* @name;
        /// <summary>The number of components each pixel has, (1-4)</summary>
        internal byte @nb_components;
        /// <summary>Amount to shift the luma width right to find the chroma width. For YV12 this is 1 for example. chroma_width = AV_CEIL_RSHIFT(luma_width, log2_chroma_w) The note above is needed to ensure rounding up. This value only refers to the chroma components.</summary>
        internal byte @log2_chroma_w;
        /// <summary>Amount to shift the luma height right to find the chroma height. For YV12 this is 1 for example. chroma_height= AV_CEIL_RSHIFT(luma_height, log2_chroma_h) The note above is needed to ensure rounding up. This value only refers to the chroma components.</summary>
        internal byte @log2_chroma_h;
        /// <summary>Combination of AV_PIX_FMT_FLAG_... flags.</summary>
        internal ulong @flags;
        /// <summary>Parameters that describe how pixels are packed. If the format has 1 or 2 components, then luma is 0. If the format has 3 or 4 components: if the RGB flag is set then 0 is red, 1 is green and 2 is blue; otherwise 0 is luma, 1 is chroma-U and 2 is chroma-V.</summary>
        internal AVComponentDescriptor_array4 @comp;
        /// <summary>Alternative comma-separated names.</summary>
        internal byte* @alias;
    }

    public unsafe struct AVComponentDescriptor
    {
        /// <summary>Which of the 4 planes contains the component.</summary>
        internal int @plane;
        /// <summary>Number of elements between 2 horizontally consecutive pixels. Elements are bits for bitstream formats, bytes otherwise.</summary>
        internal int @step;
        /// <summary>Number of elements before the component of the first pixel. Elements are bits for bitstream formats, bytes otherwise.</summary>
        internal int @offset;
        /// <summary>Number of least significant bits that must be shifted away to get the value.</summary>
        internal int @shift;
        /// <summary>Number of bits in the component.</summary>
        internal int @depth;
        /// <summary>deprecated, use step instead</summary>
        internal int @step_minus1;
        /// <summary>deprecated, use depth instead</summary>
        internal int @depth_minus1;
        /// <summary>deprecated, use offset instead</summary>
        internal int @offset_plus1;
    }

    internal unsafe struct AVTimecode
    {
        /// <summary>timecode frame start (first base frame number)</summary>
        internal int @start;
        /// <summary>flags such as drop frame, +24 hours support, ...</summary>
        internal uint @flags;
        /// <summary>frame rate in rational form</summary>
        internal AVRational @rate;
        /// <summary>frame per second; must be consistent with the rate field</summary>
        internal uint @fps;
    }

    /// <summary>This struct aggregates all the (hardware/vendor-specific) &quot;high-level&quot; state, i.e. state that is not tied to a concrete processing configuration. E.g., in an API that supports hardware-accelerated encoding and decoding, this struct will (if possible) wrap the state that is common to both encoding and decoding and from which specific instances of encoders or decoders can be derived.</summary>
    internal unsafe struct AVHWDeviceContext
    {
        /// <summary>A class for logging. Set by av_hwdevice_ctx_alloc().</summary>
        internal AVClass* @av_class;
        /// <summary>Private data used internally by libavutil. Must not be accessed in any way by the caller.</summary>
        internal AVHWDeviceInternal* @internal;
        /// <summary>This field identifies the underlying API used for hardware access.</summary>
        internal AVHWDeviceType @type;
        /// <summary>The format-specific data, allocated and freed by libavutil along with this context.</summary>
        internal void* @hwctx;
        /// <summary>This field may be set by the caller before calling av_hwdevice_ctx_init().</summary>
        internal IntPtr @free;
        /// <summary>Arbitrary user data, to be used e.g. by the free() callback.</summary>
        internal void* @user_opaque;
    }

    /// <summary>This struct describes a set or pool of &quot;hardware&quot; frames (i.e. those with data not located in normal system memory). All the frames in the pool are assumed to be allocated in the same way and interchangeable.</summary>
    internal unsafe struct AVHWFramesContext
    {
        /// <summary>A class for logging.</summary>
        internal AVClass* @av_class;
        /// <summary>Private data used internally by libavutil. Must not be accessed in any way by the caller.</summary>
        internal AVHWFramesInternal* @internal;
        /// <summary>A reference to the parent AVHWDeviceContext. This reference is owned and managed by the enclosing AVHWFramesContext, but the caller may derive additional references from it.</summary>
        internal AVBufferRef* @device_ref;
        /// <summary>The parent AVHWDeviceContext. This is simply a pointer to device_ref-&gt;data provided for convenience.</summary>
        internal AVHWDeviceContext* @device_ctx;
        /// <summary>The format-specific data, allocated and freed automatically along with this context.</summary>
        internal void* @hwctx;
        /// <summary>This field may be set by the caller before calling av_hwframe_ctx_init().</summary>
        internal IntPtr @free;
        /// <summary>Arbitrary user data, to be used e.g. by the free() callback.</summary>
        internal void* @user_opaque;
        /// <summary>A pool from which the frames are allocated by av_hwframe_get_buffer(). This field may be set by the caller before calling av_hwframe_ctx_init(). The buffers returned by calling av_buffer_pool_get() on this pool must have the properties described in the documentation in the corresponding hw type&apos;s header (hwcontext_*.h). The pool will be freed strictly before this struct&apos;s free() callback is invoked.</summary>
        internal AVBufferPool* @pool;
        /// <summary>Initial size of the frame pool. If a device type does not support dynamically resizing the pool, then this is also the maximum pool size.</summary>
        internal int @initial_pool_size;
        /// <summary>The pixel format identifying the underlying HW surface type.</summary>
        internal AVPixelFormat @format;
        /// <summary>The pixel format identifying the actual data layout of the hardware frames.</summary>
        internal AVPixelFormat @sw_format;
        /// <summary>The allocated dimensions of the frames in this pool.</summary>
        internal int @width;
        /// <summary>The allocated dimensions of the frames in this pool.</summary>
        internal int @height;
    }

    /// <summary>This struct describes the constraints on hardware frames attached to a given device with a hardware-specific configuration. This is returned by av_hwdevice_get_hwframe_constraints() and must be freed by av_hwframe_constraints_free() after use.</summary>
    internal unsafe struct AVHWFramesConstraints
    {
        /// <summary>A list of possible values for format in the hw_frames_ctx, terminated by AV_PIX_FMT_NONE. This member will always be filled.</summary>
        internal AVPixelFormat* @valid_hw_formats;
        /// <summary>A list of possible values for sw_format in the hw_frames_ctx, terminated by AV_PIX_FMT_NONE. Can be NULL if this information is not known.</summary>
        internal AVPixelFormat* @valid_sw_formats;
        /// <summary>The minimum size of frames in this hw_frames_ctx. (Zero if not known.)</summary>
        internal int @min_width;
        internal int @min_height;
        /// <summary>The maximum size of frames in this hw_frames_ctx. (INT_MAX if not known / no limit.)</summary>
        internal int @max_width;
        internal int @max_height;
    }

    /// <summary>This struct is allocated as AVHWDeviceContext.hwctx</summary>
    internal unsafe struct AVDXVA2DeviceContext
    {
        internal IDirect3DDeviceManager9* @devmgr;
    }

    internal unsafe struct IDirect3DDeviceManager9
    {
        internal IDirect3DDeviceManager9Vtbl* @lpVtbl;
    }

    internal unsafe struct IDirect3DDeviceManager9Vtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @ResetDevice;
        internal void* @OpenDeviceHandle;
        internal void* @CloseDeviceHandle;
        internal void* @TestDevice;
        internal void* @LockDevice;
        internal void* @UnlockDevice;
        internal void* @GetVideoService;
    }

    /// <summary>This struct is allocated as AVHWFramesContext.hwctx</summary>
    internal unsafe struct AVDXVA2FramesContext
    {
        /// <summary>The surface type (e.g. DXVA2_VideoProcessorRenderTarget or DXVA2_VideoDecoderRenderTarget). Must be set by the caller.</summary>
        internal ulong @surface_type;
        /// <summary>The surface pool. When an external pool is not provided by the caller, this will be managed (allocated and filled on init, freed on uninit) by libavutil.</summary>
        internal IDirect3DSurface9** @surfaces;
        internal int @nb_surfaces;
        /// <summary>Certain drivers require the decoder to be destroyed before the surfaces. To allow internally managed pools to work properly in such cases, this field is provided.</summary>
        internal IDirectXVideoDecoder* @decoder_to_release;
    }

    internal unsafe struct IDirect3DSurface9
    {
        internal IDirect3DSurface9Vtbl* @lpVtbl;
    }

    internal unsafe struct IDirect3DSurface9Vtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @SetPrivateData;
        internal void* @GetPrivateData;
        internal void* @FreePrivateData;
        internal void* @SetPriority;
        internal void* @GetPriority;
        internal void* @PreLoad;
        internal void* @GetType;
        internal void* @GetContainer;
        internal void* @GetDesc;
        internal void* @LockRect;
        internal void* @UnlockRect;
        internal void* @GetDC;
        internal void* @ReleaseDC;
    }

    internal unsafe struct IDirectXVideoDecoder
    {
        internal IDirectXVideoDecoderVtbl* @lpVtbl;
    }

    internal unsafe struct IDirectXVideoDecoderVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetVideoDecoderService;
        internal void* @GetCreationParameters;
        internal void* @GetBuffer;
        internal void* @ReleaseBuffer;
        internal void* @BeginFrame;
        internal void* @EndFrame;
        internal void* @Execute;
    }

    /// <summary>This struct is allocated as AVHWDeviceContext.hwctx</summary>
    internal unsafe struct AVD3D11VADeviceContext
    {
        /// <summary>Device used for texture creation and access. This can also be used to set the libavcodec decoding device.</summary>
        internal ID3D11Device* @device;
        /// <summary>If unset, this will be set from the device field on init.</summary>
        internal ID3D11DeviceContext* @device_context;
        /// <summary>If unset, this will be set from the device field on init.</summary>
        internal ID3D11VideoDevice* @video_device;
        /// <summary>If unset, this will be set from the device_context field on init.</summary>
        internal ID3D11VideoContext* @video_context;
        /// <summary>Callbacks for locking. They protect accesses to device_context and video_context calls. They also protect access to the internal staging texture (for av_hwframe_transfer_data() calls). They do NOT protect access to hwcontext or decoder state in general.</summary>
        internal IntPtr @lock;
        internal IntPtr @unlock;
        internal void* @lock_ctx;
    }

    internal unsafe struct ID3D11Device
    {
        internal ID3D11DeviceVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11DeviceVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @CreateBuffer;
        internal void* @CreateTexture1D;
        internal void* @CreateTexture2D;
        internal void* @CreateTexture3D;
        internal void* @CreateShaderResourceView;
        internal void* @CreateUnorderedAccessView;
        internal void* @CreateRenderTargetView;
        internal void* @CreateDepthStencilView;
        internal void* @CreateInputLayout;
        internal void* @CreateVertexShader;
        internal void* @CreateGeometryShader;
        internal void* @CreateGeometryShaderWithStreamOutput;
        internal void* @CreatePixelShader;
        internal void* @CreateHullShader;
        internal void* @CreateDomainShader;
        internal void* @CreateComputeShader;
        internal void* @CreateClassLinkage;
        internal void* @CreateBlendState;
        internal void* @CreateDepthStencilState;
        internal void* @CreateRasterizerState;
        internal void* @CreateSamplerState;
        internal void* @CreateQuery;
        internal void* @CreatePredicate;
        internal void* @CreateCounter;
        internal void* @CreateDeferredContext;
        internal void* @OpenSharedResource;
        internal void* @CheckFormatSupport;
        internal void* @CheckMultisampleQualityLevels;
        internal void* @CheckCounterInfo;
        internal void* @CheckCounter;
        internal void* @CheckFeatureSupport;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @GetFeatureLevel;
        internal void* @GetCreationFlags;
        internal void* @GetDeviceRemovedReason;
        internal void* @GetImmediateContext;
        internal void* @SetExceptionMode;
        internal void* @GetExceptionMode;
    }

    internal unsafe struct ID3D11DeviceContext
    {
        internal ID3D11DeviceContextVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11DeviceContextVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @VSSetConstantBuffers;
        internal void* @PSSetShaderResources;
        internal void* @PSSetShader;
        internal void* @PSSetSamplers;
        internal void* @VSSetShader;
        internal void* @DrawIndexed;
        internal void* @Draw;
        internal void* @Map;
        internal void* @Unmap;
        internal void* @PSSetConstantBuffers;
        internal void* @IASetInputLayout;
        internal void* @IASetVertexBuffers;
        internal void* @IASetIndexBuffer;
        internal void* @DrawIndexedInstanced;
        internal void* @DrawInstanced;
        internal void* @GSSetConstantBuffers;
        internal void* @GSSetShader;
        internal void* @IASetPrimitiveTopology;
        internal void* @VSSetShaderResources;
        internal void* @VSSetSamplers;
        internal void* @Begin;
        internal void* @End;
        internal void* @GetData;
        internal void* @SetPredication;
        internal void* @GSSetShaderResources;
        internal void* @GSSetSamplers;
        internal void* @OMSetRenderTargets;
        internal void* @OMSetRenderTargetsAndUnorderedAccessViews;
        internal void* @OMSetBlendState;
        internal void* @OMSetDepthStencilState;
        internal void* @SOSetTargets;
        internal void* @DrawAuto;
        internal void* @DrawIndexedInstancedIndirect;
        internal void* @DrawInstancedIndirect;
        internal void* @Dispatch;
        internal void* @DispatchIndirect;
        internal void* @RSSetState;
        internal void* @RSSetViewports;
        internal void* @RSSetScissorRects;
        internal void* @CopySubresourceRegion;
        internal void* @CopyResource;
        internal void* @UpdateSubresource;
        internal void* @CopyStructureCount;
        internal void* @ClearRenderTargetView;
        internal void* @ClearUnorderedAccessViewUint;
        internal void* @ClearUnorderedAccessViewFloat;
        internal void* @ClearDepthStencilView;
        internal void* @GenerateMips;
        internal void* @SetResourceMinLOD;
        internal void* @GetResourceMinLOD;
        internal void* @ResolveSubresource;
        internal void* @ExecuteCommandList;
        internal void* @HSSetShaderResources;
        internal void* @HSSetShader;
        internal void* @HSSetSamplers;
        internal void* @HSSetConstantBuffers;
        internal void* @DSSetShaderResources;
        internal void* @DSSetShader;
        internal void* @DSSetSamplers;
        internal void* @DSSetConstantBuffers;
        internal void* @CSSetShaderResources;
        internal void* @CSSetUnorderedAccessViews;
        internal void* @CSSetShader;
        internal void* @CSSetSamplers;
        internal void* @CSSetConstantBuffers;
        internal void* @VSGetConstantBuffers;
        internal void* @PSGetShaderResources;
        internal void* @PSGetShader;
        internal void* @PSGetSamplers;
        internal void* @VSGetShader;
        internal void* @PSGetConstantBuffers;
        internal void* @IAGetInputLayout;
        internal void* @IAGetVertexBuffers;
        internal void* @IAGetIndexBuffer;
        internal void* @GSGetConstantBuffers;
        internal void* @GSGetShader;
        internal void* @IAGetPrimitiveTopology;
        internal void* @VSGetShaderResources;
        internal void* @VSGetSamplers;
        internal void* @GetPredication;
        internal void* @GSGetShaderResources;
        internal void* @GSGetSamplers;
        internal void* @OMGetRenderTargets;
        internal void* @OMGetRenderTargetsAndUnorderedAccessViews;
        internal void* @OMGetBlendState;
        internal void* @OMGetDepthStencilState;
        internal void* @SOGetTargets;
        internal void* @RSGetState;
        internal void* @RSGetViewports;
        internal void* @RSGetScissorRects;
        internal void* @HSGetShaderResources;
        internal void* @HSGetShader;
        internal void* @HSGetSamplers;
        internal void* @HSGetConstantBuffers;
        internal void* @DSGetShaderResources;
        internal void* @DSGetShader;
        internal void* @DSGetSamplers;
        internal void* @DSGetConstantBuffers;
        internal void* @CSGetShaderResources;
        internal void* @CSGetUnorderedAccessViews;
        internal void* @CSGetShader;
        internal void* @CSGetSamplers;
        internal void* @CSGetConstantBuffers;
        internal void* @ClearState;
        internal void* @Flush;
        internal void* @GetType;
        internal void* @GetContextFlags;
        internal void* @FinishCommandList;
    }

    internal unsafe struct ID3D11VideoDevice
    {
        internal ID3D11VideoDeviceVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11VideoDeviceVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @CreateVideoDecoder;
        internal void* @CreateVideoProcessor;
        internal void* @CreateAuthenticatedChannel;
        internal void* @CreateCryptoSession;
        internal void* @CreateVideoDecoderOutputView;
        internal void* @CreateVideoProcessorInputView;
        internal void* @CreateVideoProcessorOutputView;
        internal void* @CreateVideoProcessorEnumerator;
        internal void* @GetVideoDecoderProfileCount;
        internal void* @GetVideoDecoderProfile;
        internal void* @CheckVideoDecoderFormat;
        internal void* @GetVideoDecoderConfigCount;
        internal void* @GetVideoDecoderConfig;
        internal void* @GetContentProtectionCaps;
        internal void* @CheckCryptoKeyExchange;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
    }

    internal unsafe struct ID3D11VideoContext
    {
        internal ID3D11VideoContextVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11VideoContextVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @GetDecoderBuffer;
        internal void* @ReleaseDecoderBuffer;
        internal void* @DecoderBeginFrame;
        internal void* @DecoderEndFrame;
        internal void* @SubmitDecoderBuffers;
        internal void* @DecoderExtension;
        internal void* @VideoProcessorSetOutputTargetRect;
        internal void* @VideoProcessorSetOutputBackgroundColor;
        internal void* @VideoProcessorSetOutputColorSpace;
        internal void* @VideoProcessorSetOutputAlphaFillMode;
        internal void* @VideoProcessorSetOutputConstriction;
        internal void* @VideoProcessorSetOutputStereoMode;
        internal void* @VideoProcessorSetOutputExtension;
        internal void* @VideoProcessorGetOutputTargetRect;
        internal void* @VideoProcessorGetOutputBackgroundColor;
        internal void* @VideoProcessorGetOutputColorSpace;
        internal void* @VideoProcessorGetOutputAlphaFillMode;
        internal void* @VideoProcessorGetOutputConstriction;
        internal void* @VideoProcessorGetOutputStereoMode;
        internal void* @VideoProcessorGetOutputExtension;
        internal void* @VideoProcessorSetStreamFrameFormat;
        internal void* @VideoProcessorSetStreamColorSpace;
        internal void* @VideoProcessorSetStreamOutputRate;
        internal void* @VideoProcessorSetStreamSourceRect;
        internal void* @VideoProcessorSetStreamDestRect;
        internal void* @VideoProcessorSetStreamAlpha;
        internal void* @VideoProcessorSetStreamPalette;
        internal void* @VideoProcessorSetStreamPixelAspectRatio;
        internal void* @VideoProcessorSetStreamLumaKey;
        internal void* @VideoProcessorSetStreamStereoFormat;
        internal void* @VideoProcessorSetStreamAutoProcessingMode;
        internal void* @VideoProcessorSetStreamFilter;
        internal void* @VideoProcessorSetStreamExtension;
        internal void* @VideoProcessorGetStreamFrameFormat;
        internal void* @VideoProcessorGetStreamColorSpace;
        internal void* @VideoProcessorGetStreamOutputRate;
        internal void* @VideoProcessorGetStreamSourceRect;
        internal void* @VideoProcessorGetStreamDestRect;
        internal void* @VideoProcessorGetStreamAlpha;
        internal void* @VideoProcessorGetStreamPalette;
        internal void* @VideoProcessorGetStreamPixelAspectRatio;
        internal void* @VideoProcessorGetStreamLumaKey;
        internal void* @VideoProcessorGetStreamStereoFormat;
        internal void* @VideoProcessorGetStreamAutoProcessingMode;
        internal void* @VideoProcessorGetStreamFilter;
        internal void* @VideoProcessorGetStreamExtension;
        internal void* @VideoProcessorBlt;
        internal void* @NegotiateCryptoSessionKeyExchange;
        internal void* @EncryptionBlt;
        internal void* @DecryptionBlt;
        internal void* @StartSessionKeyRefresh;
        internal void* @FinishSessionKeyRefresh;
        internal void* @GetEncryptionBltKey;
        internal void* @NegotiateAuthenticatedChannelKeyExchange;
        internal void* @QueryAuthenticatedChannel;
        internal void* @ConfigureAuthenticatedChannel;
        internal void* @VideoProcessorSetStreamRotation;
        internal void* @VideoProcessorGetStreamRotation;
    }

    /// <summary>D3D11 frame descriptor for pool allocation.</summary>
    internal unsafe struct AVD3D11FrameDescriptor
    {
        /// <summary>The texture in which the frame is located. The reference count is managed by the AVBufferRef, and destroying the reference will release the interface.</summary>
        internal ID3D11Texture2D* @texture;
        /// <summary>The index into the array texture element representing the frame, or 0 if the texture is not an array texture.</summary>
        internal long @index;
    }

    internal unsafe struct ID3D11Texture2D
    {
        internal ID3D11Texture2DVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11Texture2DVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @GetType;
        internal void* @SetEvictionPriority;
        internal void* @GetEvictionPriority;
        internal void* @GetDesc;
    }

    /// <summary>This struct is allocated as AVHWFramesContext.hwctx</summary>
    internal unsafe struct AVD3D11VAFramesContext
    {
        /// <summary>The canonical texture used for pool allocation. If this is set to NULL on init, the hwframes implementation will allocate and set an array texture if initial_pool_size &gt; 0.</summary>
        internal ID3D11Texture2D* @texture;
        /// <summary>D3D11_TEXTURE2D_DESC.BindFlags used for texture creation. The user must at least set D3D11_BIND_DECODER if the frames context is to be used for video decoding. This field is ignored/invalid if a user-allocated texture is provided.</summary>
        internal uint @BindFlags;
        /// <summary>D3D11_TEXTURE2D_DESC.MiscFlags used for texture creation. This field is ignored/invalid if a user-allocated texture is provided.</summary>
        internal uint @MiscFlags;
    }

    internal unsafe struct SwsVector
    {
        /// <summary>pointer to the list of coefficients</summary>
        internal double* @coeff;
        /// <summary>number of coefficients in the vector</summary>
        internal int @length;
    }

    internal unsafe struct SwsFilter
    {
        internal SwsVector* @lumH;
        internal SwsVector* @lumV;
        internal SwsVector* @chrH;
        internal SwsVector* @chrV;
    }

    /// <summary>This struct describes the properties of a single codec described by an AVCodecID.</summary>
    internal unsafe struct AVCodecDescriptor
    {
        internal AVCodecID @id;
        internal AVMediaType @type;
        /// <summary>Name of the codec described by this descriptor. It is non-empty and unique for each codec descriptor. It should contain alphanumeric characters and &apos;_&apos; only.</summary>
        internal byte* @name;
        /// <summary>A more descriptive name for this codec. May be NULL.</summary>
        internal byte* @long_name;
        /// <summary>Codec properties, a combination of AV_CODEC_PROP_* flags.</summary>
        internal int @props;
        /// <summary>MIME type(s) associated with the codec. May be NULL; if not, a NULL-terminated array of MIME types. The first item is always non-NULL and is the preferred MIME type.</summary>
        internal byte** @mime_types;
        /// <summary>If non-NULL, an array of profiles recognized for this codec. Terminated with FF_PROFILE_UNKNOWN.</summary>
        internal AVProfile* @profiles;
    }

    /// <summary>AVProfile.</summary>
    internal unsafe struct AVProfile
    {
        internal int @profile;
        /// <summary>short name for the profile</summary>
        internal byte* @name;
    }

    internal unsafe struct RcOverride
    {
        internal int @start_frame;
        internal int @end_frame;
        internal int @qscale;
        internal float @quality_factor;
    }

    /// <summary>Pan Scan area. This specifies the area which should be displayed. Note there may be multiple such areas for one frame.</summary>
    internal unsafe struct AVPanScan
    {
        /// <summary>id - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal int @id;
        /// <summary>width and height in 1/16 pel - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal int @width;
        internal int @height;
        /// <summary>position of the top left corner in 1/16 pel for up to 3 fields/frames - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal short_arrayOfArray6 @position;
    }

    /// <summary>This structure describes the bitrate properties of an encoded bitstream. It roughly corresponds to a subset the VBV parameters for MPEG-2 or HRD parameters for H.264/HEVC.</summary>
    internal unsafe struct AVCPBProperties
    {
        /// <summary>Maximum bitrate of the stream, in bits per second. Zero if unknown or unspecified.</summary>
        internal int @max_bitrate;
        /// <summary>Minimum bitrate of the stream, in bits per second. Zero if unknown or unspecified.</summary>
        internal int @min_bitrate;
        /// <summary>Average bitrate of the stream, in bits per second. Zero if unknown or unspecified.</summary>
        internal int @avg_bitrate;
        /// <summary>The size of the buffer to which the ratecontrol is applied, in bits. Zero if unknown or unspecified.</summary>
        internal int @buffer_size;
        /// <summary>The delay between the time the packet this structure is associated with is received and the time when it should be decoded, in periods of a 27MHz clock.</summary>
        internal ulong @vbv_delay;
    }

    internal unsafe struct AVPacketSideData
    {
        internal byte* @data;
        internal int @size;
        internal AVPacketSideDataType @type;
    }

    /// <summary>This structure stores compressed data. It is typically exported by demuxers and then passed as input to decoders, or received as output from encoders and then passed to muxers.</summary>
    internal unsafe struct AVPacket
    {
        /// <summary>A reference to the reference-counted buffer where the packet data is stored. May be NULL, then the packet data is not reference-counted.</summary>
        internal AVBufferRef* @buf;
        /// <summary>Presentation timestamp in AVStream-&gt;time_base units; the time at which the decompressed packet will be presented to the user. Can be AV_NOPTS_VALUE if it is not stored in the file. pts MUST be larger or equal to dts as presentation cannot happen before decompression, unless one wants to view hex dumps. Some formats misuse the terms dts and pts/cts to mean something different. Such timestamps must be converted to true pts/dts before they are stored in AVPacket.</summary>
        internal long @pts;
        /// <summary>Decompression timestamp in AVStream-&gt;time_base units; the time at which the packet is decompressed. Can be AV_NOPTS_VALUE if it is not stored in the file.</summary>
        internal long @dts;
        internal byte* @data;
        internal int @size;
        internal int @stream_index;
        /// <summary>A combination of AV_PKT_FLAG values</summary>
        internal int @flags;
        /// <summary>Additional packet data that can be provided by the container. Packet can contain several types of side information.</summary>
        internal AVPacketSideData* @side_data;
        internal int @side_data_elems;
        /// <summary>Duration of this packet in AVStream-&gt;time_base units, 0 if unknown. Equals next_pts - this_pts in presentation order.</summary>
        internal long @duration;
        /// <summary>byte position in stream, -1 if unknown</summary>
        internal long @pos;
        internal long @convergence_duration;
    }

    /// <summary>main external API structure. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. You can use AVOptions (av_opt* / av_set/get*()) to access these fields from user applications. The name string for AVOptions options matches the associated command line parameter name and can be found in libavcodec/options_table.h The AVOption/command line parameter names differ in some cases from the C structure field names for historic reasons or brevity. sizeof(AVCodecContext) must not be used outside libav*.</summary>
    internal unsafe struct AVCodecContext
    {
        /// <summary>information on struct for av_log - set by avcodec_alloc_context3</summary>
        internal AVClass* @av_class;
        internal int @log_level_offset;
        internal AVMediaType @codec_type;
        internal AVCodec* @codec;
        internal AVCodecID @codec_id;
        /// <summary>fourcc (LSB first, so &quot;ABCD&quot; -&gt; (&apos;D&apos;&lt;&lt;24) + (&apos;C&apos;&lt;&lt;16) + (&apos;B&apos;&lt;&lt;8) + &apos;A&apos;). This is used to work around some encoder bugs. A demuxer should set this to what is stored in the field used to identify the codec. If there are multiple such fields in a container then the demuxer should choose the one which maximizes the information about the used codec. If the codec tag field in a container is larger than 32 bits then the demuxer should remap the longer ID to 32 bits with a table or other structure. Alternatively a new extra_codec_tag + size could be added but for this a clear advantage must be demonstrated first. - encoding: Set by user, if not then the default based on codec_id will be used. - decoding: Set by user, will be converted to uppercase by libavcodec during init.</summary>
        internal uint @codec_tag;
        internal void* @priv_data;
        /// <summary>Private context used for internal data.</summary>
        internal AVCodecInternal* @internal;
        /// <summary>Private data of the user, can be used to carry app specific stuff. - encoding: Set by user. - decoding: Set by user.</summary>
        internal void* @opaque;
        /// <summary>the average bitrate - encoding: Set by user; unused for constant quantizer encoding. - decoding: Set by user, may be overwritten by libavcodec if this info is available in the stream</summary>
        internal long @bit_rate;
        /// <summary>number of bits the bitstream is allowed to diverge from the reference. the reference can be CBR (for CBR pass1) or VBR (for pass2) - encoding: Set by user; unused for constant quantizer encoding. - decoding: unused</summary>
        internal int @bit_rate_tolerance;
        /// <summary>Global quality for codecs which cannot change it per frame. This should be proportional to MPEG-1/2/4 qscale. - encoding: Set by user. - decoding: unused</summary>
        internal int @global_quality;
        /// <summary>- encoding: Set by user. - decoding: unused</summary>
        internal int @compression_level;
        /// <summary>AV_CODEC_FLAG_*. - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @flags;
        /// <summary>AV_CODEC_FLAG2_* - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @flags2;
        /// <summary>some codecs need / can use extradata like Huffman tables. MJPEG: Huffman tables rv10: additional flags MPEG-4: global headers (they can be in the bitstream or here) The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger than extradata_size to avoid problems if it is read with the bitstream reader. The bytewise contents of extradata must not depend on the architecture or CPU endianness. - encoding: Set/allocated/freed by libavcodec. - decoding: Set/allocated/freed by user.</summary>
        internal byte* @extradata;
        internal int @extradata_size;
        /// <summary>This is the fundamental unit of time (in seconds) in terms of which frame timestamps are represented. For fixed-fps content, timebase should be 1/framerate and timestamp increments should be identically 1. This often, but not always is the inverse of the frame rate or field rate for video. 1/time_base is not the average frame rate if the frame rate is not constant.</summary>
        internal AVRational @time_base;
        /// <summary>For some codecs, the time base is closer to the field rate than the frame rate. Most notably, H.264 and MPEG-2 specify time_base as half of frame duration if no telecine is used ...</summary>
        internal int @ticks_per_frame;
        /// <summary>Codec delay.</summary>
        internal int @delay;
        /// <summary>picture width / height.</summary>
        internal int @width;
        /// <summary>picture width / height.</summary>
        internal int @height;
        /// <summary>Bitstream width / height, may be different from width/height e.g. when the decoded frame is cropped before being output or lowres is enabled.</summary>
        internal int @coded_width;
        /// <summary>Bitstream width / height, may be different from width/height e.g. when the decoded frame is cropped before being output or lowres is enabled.</summary>
        internal int @coded_height;
        /// <summary>the number of pictures in a group of pictures, or 0 for intra_only - encoding: Set by user. - decoding: unused</summary>
        internal int @gop_size;
        /// <summary>Pixel format, see AV_PIX_FMT_xxx. May be set by the demuxer if known from headers. May be overridden by the decoder if it knows better.</summary>
        internal AVPixelFormat @pix_fmt;
        /// <summary>If non NULL, &apos;draw_horiz_band&apos; is called by the libavcodec decoder to draw a horizontal band. It improves cache usage. Not all codecs can do that. You must check the codec capabilities beforehand. When multithreading is used, it may be called from multiple threads at the same time; threads might draw different parts of the same AVFrame, or multiple AVFrames, and there is no guarantee that slices will be drawn in order. The function is also used by hardware acceleration APIs. It is called at least once during frame decoding to pass the data needed for hardware render. In that mode instead of pixel data, AVFrame points to a structure specific to the acceleration API. The application reads the structure and can change some fields to indicate progress or mark state. - encoding: unused - decoding: Set by user.</summary>
        internal IntPtr @draw_horiz_band;
        /// <summary>callback to negotiate the pixelFormat</summary>
        internal IntPtr @get_format;
        /// <summary>maximum number of B-frames between non-B-frames Note: The output will be delayed by max_b_frames+1 relative to the input. - encoding: Set by user. - decoding: unused</summary>
        internal int @max_b_frames;
        /// <summary>qscale factor between IP and B-frames If &gt; 0 then the last P-frame quantizer will be used (q= lastp_q*factor+offset). If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset). - encoding: Set by user. - decoding: unused</summary>
        internal float @b_quant_factor;
        internal int @b_frame_strategy;
        /// <summary>qscale offset between IP and B-frames - encoding: Set by user. - decoding: unused</summary>
        internal float @b_quant_offset;
        /// <summary>Size of the frame reordering buffer in the decoder. For MPEG-2 it is 1 IPB or 0 low delay IP. - encoding: Set by libavcodec. - decoding: Set by libavcodec.</summary>
        internal int @has_b_frames;
        internal int @mpeg_quant;
        /// <summary>qscale factor between P- and I-frames If &gt; 0 then the last P-frame quantizer will be used (q = lastp_q * factor + offset). If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset). - encoding: Set by user. - decoding: unused</summary>
        internal float @i_quant_factor;
        /// <summary>qscale offset between P and I-frames - encoding: Set by user. - decoding: unused</summary>
        internal float @i_quant_offset;
        /// <summary>luminance masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused</summary>
        internal float @lumi_masking;
        /// <summary>temporary complexity masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused</summary>
        internal float @temporal_cplx_masking;
        /// <summary>spatial complexity masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused</summary>
        internal float @spatial_cplx_masking;
        /// <summary>p block masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused</summary>
        internal float @p_masking;
        /// <summary>darkness masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused</summary>
        internal float @dark_masking;
        /// <summary>slice count - encoding: Set by libavcodec. - decoding: Set by user (or 0).</summary>
        internal int @slice_count;
        internal int @prediction_method;
        /// <summary>slice offsets in the frame in bytes - encoding: Set/allocated by libavcodec. - decoding: Set/allocated by user (or NULL).</summary>
        internal int* @slice_offset;
        /// <summary>sample aspect ratio (0 if unknown) That is the width of a pixel divided by the height of the pixel. Numerator and denominator must be relatively prime and smaller than 256 for some video standards. - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal AVRational @sample_aspect_ratio;
        /// <summary>motion estimation comparison function - encoding: Set by user. - decoding: unused</summary>
        internal int @me_cmp;
        /// <summary>subpixel motion estimation comparison function - encoding: Set by user. - decoding: unused</summary>
        internal int @me_sub_cmp;
        /// <summary>macroblock comparison function (not supported yet) - encoding: Set by user. - decoding: unused</summary>
        internal int @mb_cmp;
        /// <summary>interlaced DCT comparison function - encoding: Set by user. - decoding: unused</summary>
        internal int @ildct_cmp;
        /// <summary>ME diamond size &amp; shape - encoding: Set by user. - decoding: unused</summary>
        internal int @dia_size;
        /// <summary>amount of previous MV predictors (2a+1 x 2a+1 square) - encoding: Set by user. - decoding: unused</summary>
        internal int @last_predictor_count;
        internal int @pre_me;
        /// <summary>motion estimation prepass comparison function - encoding: Set by user. - decoding: unused</summary>
        internal int @me_pre_cmp;
        /// <summary>ME prepass diamond size &amp; shape - encoding: Set by user. - decoding: unused</summary>
        internal int @pre_dia_size;
        /// <summary>subpel ME quality - encoding: Set by user. - decoding: unused</summary>
        internal int @me_subpel_quality;
        /// <summary>maximum motion estimation search range in subpel units If 0 then no limit.</summary>
        internal int @me_range;
        /// <summary>slice flags - encoding: unused - decoding: Set by user.</summary>
        internal int @slice_flags;
        /// <summary>macroblock decision mode - encoding: Set by user. - decoding: unused</summary>
        internal int @mb_decision;
        /// <summary>custom intra quantization matrix - encoding: Set by user, can be NULL. - decoding: Set by libavcodec.</summary>
        internal ushort* @intra_matrix;
        /// <summary>custom inter quantization matrix - encoding: Set by user, can be NULL. - decoding: Set by libavcodec.</summary>
        internal ushort* @inter_matrix;
        internal int @scenechange_threshold;
        internal int @noise_reduction;
        /// <summary>precision of the intra DC coefficient - 8 - encoding: Set by user. - decoding: Set by libavcodec</summary>
        internal int @intra_dc_precision;
        /// <summary>Number of macroblock rows at the top which are skipped. - encoding: unused - decoding: Set by user.</summary>
        internal int @skip_top;
        /// <summary>Number of macroblock rows at the bottom which are skipped. - encoding: unused - decoding: Set by user.</summary>
        internal int @skip_bottom;
        /// <summary>minimum MB Lagrange multiplier - encoding: Set by user. - decoding: unused</summary>
        internal int @mb_lmin;
        /// <summary>maximum MB Lagrange multiplier - encoding: Set by user. - decoding: unused</summary>
        internal int @mb_lmax;
        internal int @me_penalty_compensation;
        /// <summary>- encoding: Set by user. - decoding: unused</summary>
        internal int @bidir_refine;
        internal int @brd_scale;
        /// <summary>minimum GOP size - encoding: Set by user. - decoding: unused</summary>
        internal int @keyint_min;
        /// <summary>number of reference frames - encoding: Set by user. - decoding: Set by lavc.</summary>
        internal int @refs;
        internal int @chromaoffset;
        /// <summary>Note: Value depends upon the compare function used for fullpel ME. - encoding: Set by user. - decoding: unused</summary>
        internal int @mv0_threshold;
        internal int @b_sensitivity;
        /// <summary>Chromaticity coordinates of the source primaries. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorPrimaries @color_primaries;
        /// <summary>Color Transfer Characteristic. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorTransferCharacteristic @color_trc;
        /// <summary>YUV colorspace type. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorSpace @colorspace;
        /// <summary>MPEG vs JPEG YUV range. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVColorRange @color_range;
        /// <summary>This defines the location of chroma samples. - encoding: Set by user - decoding: Set by libavcodec</summary>
        internal AVChromaLocation @chroma_sample_location;
        /// <summary>Number of slices. Indicates number of picture subdivisions. Used for parallelized decoding. - encoding: Set by user - decoding: unused</summary>
        internal int @slices;
        /// <summary>Field order - encoding: set by libavcodec - decoding: Set by user.</summary>
        internal AVFieldOrder @field_order;
        /// <summary>samples per second</summary>
        internal int @sample_rate;
        /// <summary>number of audio channels</summary>
        internal int @channels;
        /// <summary>sample format</summary>
        internal AVSampleFormat @sample_fmt;
        /// <summary>Number of samples per channel in an audio frame.</summary>
        internal int @frame_size;
        /// <summary>Frame counter, set by libavcodec.</summary>
        internal int @frame_number;
        /// <summary>number of bytes per packet if constant and known or 0 Used by some WAV based audio codecs.</summary>
        internal int @block_align;
        /// <summary>Audio cutoff bandwidth (0 means &quot;automatic&quot;) - encoding: Set by user. - decoding: unused</summary>
        internal int @cutoff;
        /// <summary>Audio channel layout. - encoding: set by user. - decoding: set by user, may be overwritten by libavcodec.</summary>
        internal ulong @channel_layout;
        /// <summary>Request decoder to use this channel layout if it can (0 for default) - encoding: unused - decoding: Set by user.</summary>
        internal ulong @request_channel_layout;
        /// <summary>Type of service that the audio stream conveys. - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal AVAudioServiceType @audio_service_type;
        /// <summary>desired sample format - encoding: Not used. - decoding: Set by user. Decoder will decode to this format if it can.</summary>
        internal AVSampleFormat @request_sample_fmt;
        /// <summary>This callback is called at the beginning of each frame to get data buffer(s) for it. There may be one contiguous buffer for all the data or there may be a buffer per each data plane or anything in between. What this means is, you may set however many entries in buf[] you feel necessary. Each buffer must be reference-counted using the AVBuffer API (see description of buf[] below).</summary>
        internal IntPtr @get_buffer2;
        /// <summary>If non-zero, the decoded audio and video frames returned from avcodec_decode_video2() and avcodec_decode_audio4() are reference-counted and are valid indefinitely. The caller must free them with av_frame_unref() when they are not needed anymore. Otherwise, the decoded frames must not be freed by the caller and are only valid until the next decode call.</summary>
        internal int @refcounted_frames;
        /// <summary>amount of qscale change between easy &amp; hard scenes (0.0-1.0)</summary>
        internal float @qcompress;
        /// <summary>amount of qscale smoothing over time (0.0-1.0)</summary>
        internal float @qblur;
        /// <summary>minimum quantizer - encoding: Set by user. - decoding: unused</summary>
        internal int @qmin;
        /// <summary>maximum quantizer - encoding: Set by user. - decoding: unused</summary>
        internal int @qmax;
        /// <summary>maximum quantizer difference between frames - encoding: Set by user. - decoding: unused</summary>
        internal int @max_qdiff;
        /// <summary>decoder bitstream buffer size - encoding: Set by user. - decoding: unused</summary>
        internal int @rc_buffer_size;
        /// <summary>ratecontrol override, see RcOverride - encoding: Allocated/set/freed by user. - decoding: unused</summary>
        internal int @rc_override_count;
        internal RcOverride* @rc_override;
        /// <summary>maximum bitrate - encoding: Set by user. - decoding: Set by user, may be overwritten by libavcodec.</summary>
        internal long @rc_max_rate;
        /// <summary>minimum bitrate - encoding: Set by user. - decoding: unused</summary>
        internal long @rc_min_rate;
        /// <summary>Ratecontrol attempt to use, at maximum, &lt;value&gt; of what can be used without an underflow. - encoding: Set by user. - decoding: unused.</summary>
        internal float @rc_max_available_vbv_use;
        /// <summary>Ratecontrol attempt to use, at least, &lt;value&gt; times the amount needed to prevent a vbv overflow. - encoding: Set by user. - decoding: unused.</summary>
        internal float @rc_min_vbv_overflow_use;
        /// <summary>Number of bits which should be loaded into the rc buffer before decoding starts. - encoding: Set by user. - decoding: unused</summary>
        internal int @rc_initial_buffer_occupancy;
        internal int @coder_type;
        internal int @context_model;
        internal int @frame_skip_threshold;
        internal int @frame_skip_factor;
        internal int @frame_skip_exp;
        internal int @frame_skip_cmp;
        /// <summary>trellis RD quantization - encoding: Set by user. - decoding: unused</summary>
        internal int @trellis;
        internal int @min_prediction_order;
        internal int @max_prediction_order;
        internal long @timecode_frame_start;
        internal IntPtr @rtp_callback;
        internal int @rtp_payload_size;
        internal int @mv_bits;
        internal int @header_bits;
        internal int @i_tex_bits;
        internal int @p_tex_bits;
        internal int @i_count;
        internal int @p_count;
        internal int @skip_count;
        internal int @misc_bits;
        internal int @frame_bits;
        /// <summary>pass1 encoding statistics output buffer - encoding: Set by libavcodec. - decoding: unused</summary>
        internal byte* @stats_out;
        /// <summary>pass2 encoding statistics input buffer Concatenated stuff from stats_out of pass1 should be placed here. - encoding: Allocated/set/freed by user. - decoding: unused</summary>
        internal byte* @stats_in;
        /// <summary>Work around bugs in encoders which sometimes cannot be detected automatically. - encoding: Set by user - decoding: Set by user</summary>
        internal int @workaround_bugs;
        /// <summary>strictly follow the standard (MPEG-4, ...). - encoding: Set by user. - decoding: Set by user. Setting this to STRICT or higher means the encoder and decoder will generally do stupid things, whereas setting it to unofficial or lower will mean the encoder might produce output that is not supported by all spec-compliant decoders. Decoders don&apos;t differentiate between normal, unofficial and experimental (that is, they always try to decode things when they can) unless they are explicitly asked to behave stupidly (=strictly conform to the specs)</summary>
        internal int @strict_std_compliance;
        /// <summary>error concealment flags - encoding: unused - decoding: Set by user.</summary>
        internal int @error_concealment;
        /// <summary>debug - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @debug;
        /// <summary>Error recognition; may misdetect some more or less valid parts as errors. - encoding: unused - decoding: Set by user.</summary>
        internal int @err_recognition;
        /// <summary>opaque 64-bit number (generally a PTS) that will be reordered and output in AVFrame.reordered_opaque - encoding: unused - decoding: Set by user.</summary>
        internal long @reordered_opaque;
        /// <summary>Hardware accelerator in use - encoding: unused. - decoding: Set by libavcodec</summary>
        internal AVHWAccel* @hwaccel;
        /// <summary>Hardware accelerator context. For some hardware accelerators, a global context needs to be provided by the user. In that case, this holds display-dependent data FFmpeg cannot instantiate itself. Please refer to the FFmpeg HW accelerator documentation to know how to fill this is. e.g. for VA API, this is a struct vaapi_context. - encoding: unused - decoding: Set by user</summary>
        internal void* @hwaccel_context;
        /// <summary>error - encoding: Set by libavcodec if flags &amp; AV_CODEC_FLAG_PSNR. - decoding: unused</summary>
        internal ulong_array8 @error;
        /// <summary>DCT algorithm, see FF_DCT_* below - encoding: Set by user. - decoding: unused</summary>
        internal int @dct_algo;
        /// <summary>IDCT algorithm, see FF_IDCT_* below. - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @idct_algo;
        /// <summary>bits per sample/pixel from the demuxer (needed for huffyuv). - encoding: Set by libavcodec. - decoding: Set by user.</summary>
        internal int @bits_per_coded_sample;
        /// <summary>Bits per sample/pixel of internal libavcodec pixel/sample format. - encoding: set by user. - decoding: set by libavcodec.</summary>
        internal int @bits_per_raw_sample;
        /// <summary>low resolution decoding, 1-&gt; 1/2 size, 2-&gt;1/4 size - encoding: unused - decoding: Set by user.</summary>
        internal int @lowres;
        /// <summary>the picture in the bitstream - encoding: Set by libavcodec. - decoding: unused</summary>
        internal AVFrame* @coded_frame;
        /// <summary>thread count is used to decide how many independent tasks should be passed to execute() - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @thread_count;
        /// <summary>Which multithreading methods to use. Use of FF_THREAD_FRAME will increase decoding delay by one frame per thread, so clients which cannot provide future frames should not use it.</summary>
        internal int @thread_type;
        /// <summary>Which multithreading methods are in use by the codec. - encoding: Set by libavcodec. - decoding: Set by libavcodec.</summary>
        internal int @active_thread_type;
        /// <summary>Set by the client if its custom get_buffer() callback can be called synchronously from another thread, which allows faster multithreaded decoding. draw_horiz_band() will be called from other threads regardless of this setting. Ignored if the default get_buffer() is used. - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @thread_safe_callbacks;
        /// <summary>The codec may call this to execute several independent things. It will return only after finishing all tasks. The user may replace this with some multithreaded implementation, the default implementation will execute the parts serially.</summary>
        internal IntPtr @execute;
        /// <summary>The codec may call this to execute several independent things. It will return only after finishing all tasks. The user may replace this with some multithreaded implementation, the default implementation will execute the parts serially. Also see avcodec_thread_init and e.g. the --enable-pthread configure option.</summary>
        internal IntPtr @execute2;
        /// <summary>noise vs. sse weight for the nsse comparison function - encoding: Set by user. - decoding: unused</summary>
        internal int @nsse_weight;
        /// <summary>profile - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal int @profile;
        /// <summary>level - encoding: Set by user. - decoding: Set by libavcodec.</summary>
        internal int @level;
        /// <summary>Skip loop filtering for selected frames. - encoding: unused - decoding: Set by user.</summary>
        internal AVDiscard @skip_loop_filter;
        /// <summary>Skip IDCT/dequantization for selected frames. - encoding: unused - decoding: Set by user.</summary>
        internal AVDiscard @skip_idct;
        /// <summary>Skip decoding for selected frames. - encoding: unused - decoding: Set by user.</summary>
        internal AVDiscard @skip_frame;
        /// <summary>Header containing style information for text subtitles. For SUBTITLE_ASS subtitle type, it should contain the whole ASS [Script Info] and [V4+ Styles] section, plus the [Events] line and the Format line following. It shouldn&apos;t include any Dialogue line. - encoding: Set/allocated/freed by user (before avcodec_open2()) - decoding: Set/allocated/freed by libavcodec (by avcodec_open2())</summary>
        internal byte* @subtitle_header;
        internal int @subtitle_header_size;
        /// <summary>VBV delay coded in the last frame (in periods of a 27 MHz clock). Used for compliant TS muxing. - encoding: Set by libavcodec. - decoding: unused.</summary>
        internal ulong @vbv_delay;
        /// <summary>Encoding only and set by default. Allow encoders to output packets that do not contain any encoded data, only side data.</summary>
        internal int @side_data_only_packets;
        /// <summary>Audio only. The number of &quot;priming&quot; samples (padding) inserted by the encoder at the beginning of the audio. I.e. this number of leading decoded samples must be discarded by the caller to get the original audio without leading padding.</summary>
        internal int @initial_padding;
        /// <summary>- decoding: For codecs that store a framerate value in the compressed bitstream, the decoder may export it here. { 0, 1} when unknown. - encoding: May be used to signal the framerate of CFR content to an encoder.</summary>
        internal AVRational @framerate;
        /// <summary>Nominal unaccelerated pixel format, see AV_PIX_FMT_xxx. - encoding: unused. - decoding: Set by libavcodec before calling get_format()</summary>
        internal AVPixelFormat @sw_pix_fmt;
        /// <summary>Timebase in which pkt_dts/pts and AVPacket.dts/pts are. - encoding unused. - decoding set by user.</summary>
        internal AVRational @pkt_timebase;
        /// <summary>AVCodecDescriptor - encoding: unused. - decoding: set by libavcodec.</summary>
        internal AVCodecDescriptor* @codec_descriptor;
        /// <summary>Current statistics for PTS correction. - decoding: maintained and used by libavcodec, not intended to be used by user apps - encoding: unused</summary>
        internal long @pts_correction_num_faulty_pts;
        /// <summary>Number of incorrect PTS values so far</summary>
        internal long @pts_correction_num_faulty_dts;
        /// <summary>Number of incorrect DTS values so far</summary>
        internal long @pts_correction_last_pts;
        /// <summary>PTS of the last frame</summary>
        internal long @pts_correction_last_dts;
        /// <summary>Character encoding of the input subtitles file. - decoding: set by user - encoding: unused</summary>
        internal byte* @sub_charenc;
        /// <summary>Subtitles character encoding mode. Formats or codecs might be adjusting this setting (if they are doing the conversion themselves for instance). - decoding: set by libavcodec - encoding: unused</summary>
        internal int @sub_charenc_mode;
        /// <summary>Skip processing alpha if supported by codec. Note that if the format uses pre-multiplied alpha (common with VP6, and recommended due to better video quality/compression) the image will look as if alpha-blended onto a black background. However for formats that do not use pre-multiplied alpha there might be serious artefacts (though e.g. libswscale currently assumes pre-multiplied alpha anyway).</summary>
        internal int @skip_alpha;
        /// <summary>Number of samples to skip after a discontinuity - decoding: unused - encoding: set by libavcodec</summary>
        internal int @seek_preroll;
        /// <summary>debug motion vectors - encoding: Set by user. - decoding: Set by user.</summary>
        internal int @debug_mv;
        /// <summary>custom intra quantization matrix - encoding: Set by user, can be NULL. - decoding: unused.</summary>
        internal ushort* @chroma_intra_matrix;
        /// <summary>dump format separator. can be &quot;, &quot; or &quot; &quot; or anything else - encoding: Set by user. - decoding: Set by user.</summary>
        internal byte* @dump_separator;
        /// <summary>&apos;,&apos; separated list of allowed decoders. If NULL then all are allowed - encoding: unused - decoding: set by user</summary>
        internal byte* @codec_whitelist;
        /// <summary>Properties of the stream that gets decoded - encoding: unused - decoding: set by libavcodec</summary>
        internal uint @properties;
        /// <summary>Additional data associated with the entire coded stream.</summary>
        internal AVPacketSideData* @coded_side_data;
        internal int @nb_coded_side_data;
        /// <summary>A reference to the AVHWFramesContext describing the input (for encoding) or output (decoding) frames. The reference is set by the caller and afterwards owned (and freed) by libavcodec - it should never be read by the caller after being set.</summary>
        internal AVBufferRef* @hw_frames_ctx;
        /// <summary>Control the form of AVSubtitle.rects[N]-&gt;ass - decoding: set by user - encoding: unused</summary>
        internal int @sub_text_format;
        /// <summary>Audio only. The amount of padding (in samples) appended by the encoder to the end of the audio. I.e. this number of decoded samples must be discarded by the caller from the end of the stream to get the original audio without any trailing padding.</summary>
        internal int @trailing_padding;
        /// <summary>The number of pixels per image to maximally accept.</summary>
        internal long @max_pixels;
        /// <summary>A reference to the AVHWDeviceContext describing the device which will be used by a hardware encoder/decoder. The reference is set by the caller and afterwards owned (and freed) by libavcodec.</summary>
        internal AVBufferRef* @hw_device_ctx;
        /// <summary>Bit set of AV_HWACCEL_FLAG_* flags, which affect hardware accelerated decoding (if active). - encoding: unused - decoding: Set by user (either before avcodec_open2(), or in the AVCodecContext.get_format callback)</summary>
        internal int @hwaccel_flags;
        /// <summary>Video decoding only. Certain video codecs support cropping, meaning that only a sub-rectangle of the decoded frame is intended for display. This option controls how cropping is handled by libavcodec.</summary>
        internal int @apply_cropping;
        internal int @extra_hw_frames;
    }

    /// <summary>AVCodec.</summary>
    internal unsafe struct AVCodec
    {
        /// <summary>Name of the codec implementation. The name is globally unique among encoders and among decoders (but an encoder and a decoder can share the same name). This is the primary way to find a codec from the user perspective.</summary>
        internal byte* @name;
        /// <summary>Descriptive name for the codec, meant to be more human readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.</summary>
        internal byte* @long_name;
        internal AVMediaType @type;
        internal AVCodecID @id;
        /// <summary>Codec capabilities. see AV_CODEC_CAP_*</summary>
        internal int @capabilities;
        /// <summary>array of supported framerates, or NULL if any, array is terminated by {0,0}</summary>
        internal AVRational* @supported_framerates;
        /// <summary>array of supported pixel formats, or NULL if unknown, array is terminated by -1</summary>
        internal AVPixelFormat* @pix_fmts;
        /// <summary>array of supported audio samplerates, or NULL if unknown, array is terminated by 0</summary>
        internal int* @supported_samplerates;
        /// <summary>array of supported sample formats, or NULL if unknown, array is terminated by -1</summary>
        internal AVSampleFormat* @sample_fmts;
        /// <summary>array of support channel layouts, or NULL if unknown. array is terminated by 0</summary>
        internal ulong* @channel_layouts;
        /// <summary>maximum value for lowres supported by the decoder</summary>
        internal byte @max_lowres;
        /// <summary>AVClass for the private context</summary>
        internal AVClass* @priv_class;
        /// <summary>array of recognized profiles, or NULL if unknown, array is terminated by {FF_PROFILE_UNKNOWN}</summary>
        internal AVProfile* @profiles;
        /// <summary>Group name of the codec implementation. This is a short symbolic name of the wrapper backing this codec. A wrapper uses some kind of external implementation for the codec, such as an external library, or a codec implementation provided by the OS or the hardware. If this field is NULL, this is a builtin, libavcodec native codec. If non-NULL, this will be the suffix in AVCodec.name in most cases (usually AVCodec.name will be of the form &quot;&lt;codec_name&gt;_&lt;wrapper_name&gt;&quot;).</summary>
        internal byte* @wrapper_name;
        /// <summary>*************************************************************** No fields below this line are part of the internal API. They may not be used outside of libavcodec and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal int @priv_data_size;
        internal AVCodec* @next;
        /// <summary>@{</summary>
        internal IntPtr @init_thread_copy;
        /// <summary>Copy necessary context variables from a previous thread context to the current one. If not defined, the next thread will start automatically; otherwise, the codec must call ff_thread_finish_setup().</summary>
        internal IntPtr @update_thread_context;
        /// <summary>Private codec-specific defaults.</summary>
        internal AVCodecDefault* @defaults;
        /// <summary>Initialize codec static data, called from avcodec_register().</summary>
        internal IntPtr @init_static_data;
        internal IntPtr @init;
        internal IntPtr @encode_sub;
        /// <summary>Encode data to an AVPacket.</summary>
        internal IntPtr @encode2;
        internal IntPtr @decode;
        internal IntPtr @close;
        /// <summary>Encode API with decoupled packet/frame dataflow. The API is the same as the avcodec_ prefixed APIs (avcodec_send_frame() etc.), except that: - never called if the codec is closed or the wrong type, - if AV_CODEC_CAP_DELAY is not set, drain frames are never sent, - only one drain frame is ever passed down,</summary>
        internal IntPtr @send_frame;
        internal IntPtr @receive_packet;
        /// <summary>Decode API with decoupled packet/frame dataflow. This function is called to get one output frame. It should call ff_decode_get_packet() to obtain input data.</summary>
        internal IntPtr @receive_frame;
        /// <summary>Flush buffers. Will be called when seeking</summary>
        internal IntPtr @flush;
        /// <summary>Internal codec capabilities. See FF_CODEC_CAP_* in internal.h</summary>
        internal int @caps_internal;
        /// <summary>Decoding only, a comma-separated list of bitstream filters to apply to packets before decoding.</summary>
        internal byte* @bsfs;
        /// <summary>Array of pointers to hardware configurations supported by the codec, or NULL if no hardware supported. The array is terminated by a NULL pointer.</summary>
        internal AVCodecHWConfigInternal** @hw_configs;
    }

    internal unsafe struct AVSubtitle
    {
        internal ushort @format;
        internal uint @start_display_time;
        internal uint @end_display_time;
        internal uint @num_rects;
        internal AVSubtitleRect** @rects;
        /// <summary>Same as packet pts, in AV_TIME_BASE</summary>
        internal long @pts;
    }

    internal unsafe struct AVSubtitleRect
    {
        /// <summary>top left corner of pict, undefined when pict is not set</summary>
        internal int @x;
        /// <summary>top left corner of pict, undefined when pict is not set</summary>
        internal int @y;
        /// <summary>width of pict, undefined when pict is not set</summary>
        internal int @w;
        /// <summary>height of pict, undefined when pict is not set</summary>
        internal int @h;
        /// <summary>number of colors in pict, undefined when pict is not set</summary>
        internal int @nb_colors;
        internal AVPicture @pict;
        /// <summary>data+linesize for the bitmap of this subtitle. Can be set for text/ass as well once they are rendered.</summary>
        internal byte_ptrArray4 @data;
        internal int_array4 @linesize;
        internal AVSubtitleType @type;
        /// <summary>0 terminated plain UTF-8 text</summary>
        internal byte* @text;
        /// <summary>0 terminated ASS/SSA compatible event line. The presentation of this is unaffected by the other values in this struct.</summary>
        internal byte* @ass;
        internal int @flags;
    }

    /// <summary>Picture data structure.</summary>
    internal unsafe struct AVPicture
    {
        /// <summary>pointers to the image data planes</summary>
        internal byte_ptrArray8 @data;
        /// <summary>number of bytes per line</summary>
        internal int_array8 @linesize;
    }

    internal unsafe struct AVHWAccel
    {
        /// <summary>Name of the hardware accelerated codec. The name is globally unique among encoders and among decoders (but an encoder and a decoder can share the same name).</summary>
        internal byte* @name;
        /// <summary>Type of codec implemented by the hardware accelerator.</summary>
        internal AVMediaType @type;
        /// <summary>Codec implemented by the hardware accelerator.</summary>
        internal AVCodecID @id;
        /// <summary>Supported pixel format.</summary>
        internal AVPixelFormat @pix_fmt;
        /// <summary>Hardware accelerated codec capabilities. see AV_HWACCEL_CODEC_CAP_*</summary>
        internal int @capabilities;
        /// <summary>Allocate a custom buffer</summary>
        internal IntPtr @alloc_frame;
        /// <summary>Called at the beginning of each frame or field picture.</summary>
        internal IntPtr @start_frame;
        /// <summary>Callback for parameter data (SPS/PPS/VPS etc).</summary>
        internal IntPtr @decode_params;
        /// <summary>Callback for each slice.</summary>
        internal IntPtr @decode_slice;
        /// <summary>Called at the end of each frame or field picture.</summary>
        internal IntPtr @end_frame;
        /// <summary>Size of per-frame hardware accelerator private data.</summary>
        internal int @frame_priv_data_size;
        /// <summary>Called for every Macroblock in a slice.</summary>
        internal IntPtr @decode_mb;
        /// <summary>Initialize the hwaccel private data.</summary>
        internal IntPtr @init;
        /// <summary>Uninitialize the hwaccel private data.</summary>
        internal IntPtr @uninit;
        /// <summary>Size of the private data to allocate in AVCodecInternal.hwaccel_priv_data.</summary>
        internal int @priv_data_size;
        /// <summary>Internal hwaccel capabilities.</summary>
        internal int @caps_internal;
        /// <summary>Fill the given hw_frames context with current codec parameters. Called from get_format. Refer to avcodec_get_hw_frames_parameters() for details.</summary>
        internal IntPtr @frame_params;
    }

    internal unsafe struct AVCodecHWConfig
    {
        /// <summary>A hardware pixel format which the codec can use.</summary>
        internal AVPixelFormat @pix_fmt;
        /// <summary>Bit set of AV_CODEC_HW_CONFIG_METHOD_* flags, describing the possible setup methods which can be used with this configuration.</summary>
        internal int @methods;
        /// <summary>The device type associated with the configuration.</summary>
        internal AVHWDeviceType @device_type;
    }

    /// <summary>This struct describes the properties of an encoded stream.</summary>
    internal unsafe struct AVCodecParameters
    {
        /// <summary>General type of the encoded data.</summary>
        internal AVMediaType @codec_type;
        /// <summary>Specific type of the encoded data (the codec used).</summary>
        internal AVCodecID @codec_id;
        /// <summary>Additional information about the codec (corresponds to the AVI FOURCC).</summary>
        internal uint @codec_tag;
        /// <summary>Extra binary data needed for initializing the decoder, codec-dependent.</summary>
        internal byte* @extradata;
        /// <summary>Size of the extradata content in bytes.</summary>
        internal int @extradata_size;
        /// <summary>- video: the pixel format, the value corresponds to enum AVPixelFormat. - audio: the sample format, the value corresponds to enum AVSampleFormat.</summary>
        internal int @format;
        /// <summary>The average bitrate of the encoded data (in bits per second).</summary>
        internal long @bit_rate;
        /// <summary>The number of bits per sample in the codedwords.</summary>
        internal int @bits_per_coded_sample;
        /// <summary>This is the number of valid bits in each output sample. If the sample format has more bits, the least significant bits are additional padding bits, which are always 0. Use right shifts to reduce the sample to its actual size. For example, audio formats with 24 bit samples will have bits_per_raw_sample set to 24, and format set to AV_SAMPLE_FMT_S32. To get the original sample use &quot;(int32_t)sample &gt;&gt; 8&quot;.&quot;</summary>
        internal int @bits_per_raw_sample;
        /// <summary>Codec-specific bitstream restrictions that the stream conforms to.</summary>
        internal int @profile;
        internal int @level;
        /// <summary>Video only. The dimensions of the video frame in pixels.</summary>
        internal int @width;
        internal int @height;
        /// <summary>Video only. The aspect ratio (width / height) which a single pixel should have when displayed.</summary>
        internal AVRational @sample_aspect_ratio;
        /// <summary>Video only. The order of the fields in interlaced video.</summary>
        internal AVFieldOrder @field_order;
        /// <summary>Video only. Additional colorspace characteristics.</summary>
        internal AVColorRange @color_range;
        internal AVColorPrimaries @color_primaries;
        internal AVColorTransferCharacteristic @color_trc;
        internal AVColorSpace @color_space;
        internal AVChromaLocation @chroma_location;
        /// <summary>Video only. Number of delayed frames.</summary>
        internal int @video_delay;
        /// <summary>Audio only. The channel layout bitmask. May be 0 if the channel layout is unknown or unspecified, otherwise the number of bits set must be equal to the channels field.</summary>
        internal ulong @channel_layout;
        /// <summary>Audio only. The number of audio channels.</summary>
        internal int @channels;
        /// <summary>Audio only. The number of audio samples per second.</summary>
        internal int @sample_rate;
        /// <summary>Audio only. The number of bytes per coded audio frame, required by some formats.</summary>
        internal int @block_align;
        /// <summary>Audio only. Audio frame size, if known. Required by some formats to be static.</summary>
        internal int @frame_size;
        /// <summary>Audio only. The amount of padding (in samples) inserted by the encoder at the beginning of the audio. I.e. this number of leading decoded samples must be discarded by the caller to get the original audio without leading padding.</summary>
        internal int @initial_padding;
        /// <summary>Audio only. The amount of padding (in samples) appended by the encoder to the end of the audio. I.e. this number of decoded samples must be discarded by the caller from the end of the stream to get the original audio without any trailing padding.</summary>
        internal int @trailing_padding;
        /// <summary>Audio only. Number of samples to skip after a discontinuity.</summary>
        internal int @seek_preroll;
    }

    internal unsafe struct AVCodecParserContext
    {
        internal void* @priv_data;
        internal AVCodecParser* @parser;
        internal long @frame_offset;
        internal long @cur_offset;
        internal long @next_frame_offset;
        internal int @pict_type;
        /// <summary>This field is used for proper frame duration computation in lavf. It signals, how much longer the frame duration of the current frame is compared to normal frame duration.</summary>
        internal int @repeat_pict;
        internal long @pts;
        internal long @dts;
        internal long @last_pts;
        internal long @last_dts;
        internal int @fetch_timestamp;
        internal int @cur_frame_start_index;
        internal long_array4 @cur_frame_offset;
        internal long_array4 @cur_frame_pts;
        internal long_array4 @cur_frame_dts;
        internal int @flags;
        /// <summary>byte offset from starting packet start</summary>
        internal long @offset;
        internal long_array4 @cur_frame_end;
        /// <summary>Set by parser to 1 for key frames and 0 for non-key frames. It is initialized to -1, so if the parser doesn&apos;t set this flag, old-style fallback using AV_PICTURE_TYPE_I picture type as key frames will be used.</summary>
        internal int @key_frame;
        internal long @convergence_duration;
        /// <summary>Synchronization point for start of timestamp generation.</summary>
        internal int @dts_sync_point;
        /// <summary>Offset of the current timestamp against last timestamp sync point in units of AVCodecContext.time_base.</summary>
        internal int @dts_ref_dts_delta;
        /// <summary>Presentation delay of current frame in units of AVCodecContext.time_base.</summary>
        internal int @pts_dts_delta;
        /// <summary>Position of the packet in file.</summary>
        internal long_array4 @cur_frame_pos;
        /// <summary>Byte position of currently parsed frame in stream.</summary>
        internal long @pos;
        /// <summary>Previous frame byte position.</summary>
        internal long @last_pos;
        /// <summary>Duration of the current frame. For audio, this is in units of 1 / AVCodecContext.sample_rate. For all other types, this is in units of AVCodecContext.time_base.</summary>
        internal int @duration;
        internal AVFieldOrder @field_order;
        /// <summary>Indicate whether a picture is coded as a frame, top field or bottom field.</summary>
        internal AVPictureStructure @picture_structure;
        /// <summary>Picture number incremented in presentation or output order. This field may be reinitialized at the first picture of a new sequence.</summary>
        internal int @output_picture_number;
        /// <summary>Dimensions of the decoded video intended for presentation.</summary>
        internal int @width;
        internal int @height;
        /// <summary>Dimensions of the coded video.</summary>
        internal int @coded_width;
        internal int @coded_height;
        /// <summary>The format of the coded data, corresponds to enum AVPixelFormat for video and for enum AVSampleFormat for audio.</summary>
        internal int @format;
    }

    internal unsafe struct AVCodecParser
    {
        internal int_array5 @codec_ids;
        internal int @priv_data_size;
        internal IntPtr @parser_init;
        internal IntPtr @parser_parse;
        internal IntPtr @parser_close;
        internal IntPtr @split;
        internal AVCodecParser* @next;
    }

    /// <summary>The bitstream filter state.</summary>
    internal unsafe struct AVBSFContext
    {
        /// <summary>A class for logging and AVOptions</summary>
        internal AVClass* @av_class;
        /// <summary>The bitstream filter this context is an instance of.</summary>
        internal AVBitStreamFilter* @filter;
        /// <summary>Opaque libavcodec internal data. Must not be touched by the caller in any way.</summary>
        internal AVBSFInternal* @internal;
        /// <summary>Opaque filter-specific private data. If filter-&gt;priv_class is non-NULL, this is an AVOptions-enabled struct.</summary>
        internal void* @priv_data;
        /// <summary>Parameters of the input stream. This field is allocated in av_bsf_alloc(), it needs to be filled by the caller before av_bsf_init().</summary>
        internal AVCodecParameters* @par_in;
        /// <summary>Parameters of the output stream. This field is allocated in av_bsf_alloc(), it is set by the filter in av_bsf_init().</summary>
        internal AVCodecParameters* @par_out;
        /// <summary>The timebase used for the timestamps of the input packets. Set by the caller before av_bsf_init().</summary>
        internal AVRational @time_base_in;
        /// <summary>The timebase used for the timestamps of the output packets. Set by the filter in av_bsf_init().</summary>
        internal AVRational @time_base_out;
    }

    internal unsafe struct AVBitStreamFilter
    {
        internal byte* @name;
        /// <summary>A list of codec ids supported by the filter, terminated by AV_CODEC_ID_NONE. May be NULL, in that case the bitstream filter works with any codec id.</summary>
        internal AVCodecID* @codec_ids;
        /// <summary>A class for the private data, used to declare bitstream filter private AVOptions. This field is NULL for bitstream filters that do not declare any options.</summary>
        internal AVClass* @priv_class;
        /// <summary>*************************************************************** No fields below this line are part of the internal API. They may not be used outside of libavcodec and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal int @priv_data_size;
        internal IntPtr @init;
        internal IntPtr @filter;
        internal IntPtr @close;
    }

    internal unsafe struct AVBitStreamFilterContext
    {
        internal void* @priv_data;
        internal AVBitStreamFilter* @filter;
        internal AVCodecParserContext* @parser;
        internal AVBitStreamFilterContext* @next;
        /// <summary>Internal default arguments, used if NULL is passed to av_bitstream_filter_filter(). Not for access by library users.</summary>
        internal byte* @args;
    }

    /// <summary>This structure is used to provides the necessary configurations and data to the Direct3D11 FFmpeg HWAccel implementation.</summary>
    internal unsafe struct AVD3D11VAContext
    {
        /// <summary>D3D11 decoder object</summary>
        internal ID3D11VideoDecoder* @decoder;
        /// <summary>D3D11 VideoContext</summary>
        internal ID3D11VideoContext* @video_context;
        /// <summary>D3D11 configuration used to create the decoder</summary>
        internal D3D11_VIDEO_DECODER_CONFIG* @cfg;
        /// <summary>The number of surface in the surface array</summary>
        internal uint @surface_count;
        /// <summary>The array of Direct3D surfaces used to create the decoder</summary>
        internal ID3D11VideoDecoderOutputView** @surface;
        /// <summary>A bit field configuring the workarounds needed for using the decoder</summary>
        internal ulong @workaround;
        /// <summary>Private to the FFmpeg AVHWAccel implementation</summary>
        internal uint @report_id;
        /// <summary>Mutex to access video_context</summary>
        internal void* @context_mutex;
    }

    internal unsafe struct ID3D11VideoDecoder
    {
        internal ID3D11VideoDecoderVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11VideoDecoderVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @GetCreationParameters;
        internal void* @GetDriverHandle;
    }

    internal unsafe struct D3D11_VIDEO_DECODER_CONFIG
    {
        internal _GUID @guidConfigBitstreamEncryption;
        internal _GUID @guidConfigMBcontrolEncryption;
        internal _GUID @guidConfigResidDiffEncryption;
        internal uint @ConfigBitstreamRaw;
        internal uint @ConfigMBcontrolRasterOrder;
        internal uint @ConfigResidDiffHost;
        internal uint @ConfigSpatialResid8;
        internal uint @ConfigResid8Subtraction;
        internal uint @ConfigSpatialHost8or9Clipping;
        internal uint @ConfigSpatialResidInterleaved;
        internal uint @ConfigIntraResidUnsigned;
        internal uint @ConfigResidDiffAccelerator;
        internal uint @ConfigHostInverseScan;
        internal uint @ConfigSpecificIDCT;
        internal uint @Config4GroupedCoefs;
        internal ushort @ConfigMinRenderTargetBuffCount;
        internal ushort @ConfigDecoderSpecific;
    }

    internal unsafe struct _GUID
    {
        internal ulong @Data1;
        internal ushort @Data2;
        internal ushort @Data3;
        internal byte_array8 @Data4;
    }

    internal unsafe struct ID3D11VideoDecoderOutputView
    {
        internal ID3D11VideoDecoderOutputViewVtbl* @lpVtbl;
    }

    internal unsafe struct ID3D11VideoDecoderOutputViewVtbl
    {
        internal void* @QueryInterface;
        internal void* @AddRef;
        internal void* @Release;
        internal void* @GetDevice;
        internal void* @GetPrivateData;
        internal void* @SetPrivateData;
        internal void* @SetPrivateDataInterface;
        internal void* @GetResource;
        internal void* @GetDesc;
    }

    /// <summary>This structure contains the data a format has to probe a file.</summary>
    internal unsafe struct AVProbeData
    {
        internal byte* @filename;
        /// <summary>Buffer must have AVPROBE_PADDING_SIZE of extra allocated bytes filled with zero.</summary>
        internal byte* @buf;
        /// <summary>Size of buf except extra allocated bytes</summary>
        internal int @buf_size;
        /// <summary>mime_type, when known.</summary>
        internal byte* @mime_type;
    }

    internal unsafe struct AVIndexEntry
    {
        internal long @pos;
        /// <summary>Timestamp in AVStream.time_base units, preferably the time from which on correctly decoded frames are available when seeking to this entry. That means preferable PTS on keyframe based formats. But demuxers can choose to store a different timestamp, if it is more convenient for the implementation or nothing better is known</summary>
        internal long @timestamp;
        /// <summary>Flag is used to indicate which frame should be discarded after decoding.</summary>
        internal int @flags2_size30;
        /// <summary>Minimum distance between this and the previous keyframe, used to avoid unneeded searching.</summary>
        internal int @min_distance;
    }

    /// <summary>Stream structure. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVStream) must not be used outside libav*.</summary>
    internal unsafe struct AVStream
    {
        /// <summary>stream index in AVFormatContext</summary>
        internal int @index;
        /// <summary>Format-specific stream ID. decoding: set by libavformat encoding: set by the user, replaced by libavformat if left unset</summary>
        internal int @id;
        internal AVCodecContext* @codec;
        internal void* @priv_data;
        /// <summary>This is the fundamental unit of time (in seconds) in terms of which frame timestamps are represented.</summary>
        internal AVRational @time_base;
        /// <summary>Decoding: pts of the first frame of the stream in presentation order, in stream time base. Only set this if you are absolutely 100% sure that the value you set it to really is the pts of the first frame. This may be undefined (AV_NOPTS_VALUE).</summary>
        internal long @start_time;
        /// <summary>Decoding: duration of the stream, in stream time base. If a source file does not specify a duration, but does specify a bitrate, this value will be estimated from bitrate and file size.</summary>
        internal long @duration;
        /// <summary>number of frames in this stream if known or 0</summary>
        internal long @nb_frames;
        /// <summary>AV_DISPOSITION_* bit field</summary>
        internal int @disposition;
        /// <summary>Selects which packets can be discarded at will and do not need to be demuxed.</summary>
        internal AVDiscard @discard;
        /// <summary>sample aspect ratio (0 if unknown) - encoding: Set by user. - decoding: Set by libavformat.</summary>
        internal AVRational @sample_aspect_ratio;
        internal AVDictionary* @metadata;
        /// <summary>Average framerate</summary>
        internal AVRational @avg_frame_rate;
        /// <summary>For streams with AV_DISPOSITION_ATTACHED_PIC disposition, this packet will contain the attached picture.</summary>
        internal AVPacket @attached_pic;
        /// <summary>An array of side data that applies to the whole stream (i.e. the container does not allow it to change between packets).</summary>
        internal AVPacketSideData* @side_data;
        /// <summary>The number of elements in the AVStream.side_data array.</summary>
        internal int @nb_side_data;
        /// <summary>Flags for the user to detect events happening on the stream. Flags must be cleared by the user once the event has been handled. A combination of AVSTREAM_EVENT_FLAG_*.</summary>
        internal int @event_flags;
        /// <summary>Real base framerate of the stream. This is the lowest framerate with which all timestamps can be represented accurately (it is the least common multiple of all framerates in the stream). Note, this value is just a guess! For example, if the time base is 1/90000 and all frames have either approximately 3600 or 1800 timer ticks, then r_frame_rate will be 50/1.</summary>
        internal AVRational @r_frame_rate;
        /// <summary>String containing pairs of key and values describing recommended encoder configuration. Pairs are separated by &apos;,&apos;. Keys are separated from values by &apos;=&apos;.</summary>
        internal byte* @recommended_encoder_configuration;
        /// <summary>Codec parameters associated with this stream. Allocated and freed by libavformat in avformat_new_stream() and avformat_free_context() respectively.</summary>
        internal AVCodecParameters* @codecpar;
        internal AVStream_info* @info;
        /// <summary>number of bits in pts (used for wrapping control)</summary>
        internal int @pts_wrap_bits;
        /// <summary>Timestamp corresponding to the last dts sync point.</summary>
        internal long @first_dts;
        internal long @cur_dts;
        internal long @last_IP_pts;
        internal int @last_IP_duration;
        /// <summary>Number of packets to buffer for codec probing</summary>
        internal int @probe_packets;
        /// <summary>Number of frames that have been demuxed during avformat_find_stream_info()</summary>
        internal int @codec_info_nb_frames;
        internal AVStreamParseType @need_parsing;
        internal AVCodecParserContext* @parser;
        /// <summary>last packet in packet_buffer for this stream when muxing.</summary>
        internal AVPacketList* @last_in_packet_buffer;
        internal AVProbeData @probe_data;
        internal long_array17 @pts_buffer;
        /// <summary>Only used if the format does not support seeking natively.</summary>
        internal AVIndexEntry* @index_entries;
        internal int @nb_index_entries;
        internal uint @index_entries_allocated_size;
        /// <summary>Stream Identifier This is the MPEG-TS stream identifier +1 0 means unknown</summary>
        internal int @stream_identifier;
        internal long @interleaver_chunk_size;
        internal long @interleaver_chunk_duration;
        /// <summary>stream probing state -1 -&gt; probing finished 0 -&gt; no probing requested rest -&gt; perform probing with request_probe being the minimum score to accept. NOT PART OF internal API</summary>
        internal int @request_probe;
        /// <summary>Indicates that everything up to the next keyframe should be discarded.</summary>
        internal int @skip_to_keyframe;
        /// <summary>Number of samples to skip at the start of the frame decoded from the next packet.</summary>
        internal int @skip_samples;
        /// <summary>If not 0, the number of samples that should be skipped from the start of the stream (the samples are removed from packets with pts==0, which also assumes negative timestamps do not happen). Intended for use with formats such as mp3 with ad-hoc gapless audio support.</summary>
        internal long @start_skip_samples;
        /// <summary>If not 0, the first audio sample that should be discarded from the stream. This is broken by design (needs global sample count), but can&apos;t be avoided for broken by design formats such as mp3 with ad-hoc gapless audio support.</summary>
        internal long @first_discard_sample;
        /// <summary>The sample after last sample that is intended to be discarded after first_discard_sample. Works on frame boundaries only. Used to prevent early EOF if the gapless info is broken (considered concatenated mp3s).</summary>
        internal long @last_discard_sample;
        /// <summary>Number of internally decoded frames, used internally in libavformat, do not access its lifetime differs from info which is why it is not in that structure.</summary>
        internal int @nb_decoded_frames;
        /// <summary>Timestamp offset added to timestamps before muxing NOT PART OF internal API</summary>
        internal long @mux_ts_offset;
        /// <summary>Internal data to check for wrapping of the time stamp</summary>
        internal long @pts_wrap_reference;
        /// <summary>Options for behavior, when a wrap is detected.</summary>
        internal int @pts_wrap_behavior;
        /// <summary>Internal data to prevent doing update_initial_durations() twice</summary>
        internal int @update_initial_durations_done;
        /// <summary>Internal data to generate dts from pts</summary>
        internal long_array17 @pts_reorder_error;
        internal byte_array17 @pts_reorder_error_count;
        /// <summary>Internal data to analyze DTS and detect faulty mpeg streams</summary>
        internal long @last_dts_for_order_check;
        internal byte @dts_ordered;
        internal byte @dts_misordered;
        /// <summary>Internal data to inject global side data</summary>
        internal int @inject_global_side_data;
        /// <summary>display aspect ratio (0 if unknown) - encoding: unused - decoding: Set by libavformat to calculate sample_aspect_ratio internally</summary>
        internal AVRational @display_aspect_ratio;
        /// <summary>An opaque field for libavformat internal usage. Must not be accessed in any way by callers.</summary>
        internal AVStreamInternal* @internal;
    }

    /// <summary>Stream information used internally by avformat_find_stream_info()</summary>
    internal unsafe struct AVStream_info
    {
        internal long @last_dts;
        internal long @duration_gcd;
        internal int @duration_count;
        internal long @rfps_duration_sum;
        internal double_arrayOfArray798* @duration_error;
        internal long @codec_info_duration;
        internal long @codec_info_duration_fields;
        internal int @frame_delay_evidence;
        /// <summary>0 -&gt; decoder has not been searched for yet. &gt;0 -&gt; decoder found &lt;0 -&gt; decoder with codec_id == -found_decoder has not been found</summary>
        internal int @found_decoder;
        internal long @last_duration;
        /// <summary>Those are used for average framerate estimation.</summary>
        internal long @fps_first_dts;
        internal int @fps_first_dts_idx;
        internal long @fps_last_dts;
        internal int @fps_last_dts_idx;
    }

    internal unsafe struct AVPacketList
    {
        internal AVPacket @pkt;
        internal AVPacketList* @next;
    }

    /// <summary>New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVProgram) must not be used outside libav*.</summary>
    internal unsafe struct AVProgram
    {
        internal int @id;
        internal int @flags;
        /// <summary>selects which program to discard and which to feed to the caller</summary>
        internal AVDiscard @discard;
        internal uint* @stream_index;
        internal uint @nb_stream_indexes;
        internal AVDictionary* @metadata;
        internal int @program_num;
        internal int @pmt_pid;
        internal int @pcr_pid;
        /// <summary>*************************************************************** All fields below this line are not part of the internal API. They may not be used outside of libavformat and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal long @start_time;
        internal long @end_time;
        /// <summary>reference dts for wrap detection</summary>
        internal long @pts_wrap_reference;
        /// <summary>behavior on wrap detection</summary>
        internal int @pts_wrap_behavior;
    }

    internal unsafe struct AVChapter
    {
        /// <summary>unique ID to identify the chapter</summary>
        internal int @id;
        /// <summary>time base in which the start/end timestamps are specified</summary>
        internal AVRational @time_base;
        /// <summary>chapter start/end time in time_base units</summary>
        internal long @start;
        /// <summary>chapter start/end time in time_base units</summary>
        internal long @end;
        internal AVDictionary* @metadata;
    }

    /// <summary>@{</summary>
    internal unsafe struct AVOutputFormat
    {
        internal byte* @name;
        /// <summary>Descriptive name for the format, meant to be more human-readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.</summary>
        internal byte* @long_name;
        internal byte* @mime_type;
        /// <summary>comma-separated filename extensions</summary>
        internal byte* @extensions;
        /// <summary>default audio codec</summary>
        internal AVCodecID @audio_codec;
        /// <summary>default video codec</summary>
        internal AVCodecID @video_codec;
        /// <summary>default subtitle codec</summary>
        internal AVCodecID @subtitle_codec;
        /// <summary>can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_GLOBALHEADER, AVFMT_NOTIMESTAMPS, AVFMT_VARIABLE_FPS, AVFMT_NODIMENSIONS, AVFMT_NOSTREAMS, AVFMT_ALLOW_FLUSH, AVFMT_TS_NONSTRICT, AVFMT_TS_NEGATIVE</summary>
        internal int @flags;
        /// <summary>List of supported codec_id-codec_tag pairs, ordered by &quot;better choice first&quot;. The arrays are all terminated by AV_CODEC_ID_NONE.</summary>
        internal AVCodecTag** @codec_tag;
        /// <summary>AVClass for the private context</summary>
        internal AVClass* @priv_class;
        /// <summary>*************************************************************** No fields below this line are part of the internal API. They may not be used outside of libavformat and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal AVOutputFormat* @next;
        /// <summary>size of private data so that it can be allocated in the wrapper</summary>
        internal int @priv_data_size;
        internal IntPtr @write_header;
        /// <summary>Write a packet. If AVFMT_ALLOW_FLUSH is set in flags, pkt can be NULL in order to flush data buffered in the muxer. When flushing, return 0 if there still is more data to flush, or 1 if everything was flushed and there is no more buffered data.</summary>
        internal IntPtr @write_packet;
        internal IntPtr @write_trailer;
        /// <summary>Currently only used to set pixel format if not YUV420P.</summary>
        internal IntPtr @interleave_packet;
        /// <summary>Test if the given codec can be stored in this container.</summary>
        internal IntPtr @query_codec;
        internal IntPtr @get_output_timestamp;
        /// <summary>Allows sending messages from application to device.</summary>
        internal IntPtr @control_message;
        /// <summary>Write an uncoded AVFrame.</summary>
        internal IntPtr @write_uncoded_frame;
        /// <summary>Returns device list with it properties.</summary>
        internal IntPtr @get_device_list;
        /// <summary>Initialize device capabilities submodule.</summary>
        internal IntPtr @create_device_capabilities;
        /// <summary>Free device capabilities submodule.</summary>
        internal IntPtr @free_device_capabilities;
        /// <summary>default data codec</summary>
        internal AVCodecID @data_codec;
        /// <summary>Initialize format. May allocate data here, and set any AVFormatContext or AVStream parameters that need to be set before packets are sent. This method must not write output.</summary>
        internal IntPtr @init;
        /// <summary>Deinitialize format. If present, this is called whenever the muxer is being destroyed, regardless of whether or not the header has been written.</summary>
        internal IntPtr @deinit;
        /// <summary>Set up any necessary bitstream filtering and extract any extra data needed for the global header. Return 0 if more packets from this stream must be checked; 1 if not.</summary>
        internal IntPtr @check_bitstream;
    }

    /// <summary>Format I/O context. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVFormatContext) must not be used outside libav*, use avformat_alloc_context() to create an AVFormatContext.</summary>
    internal unsafe struct AVFormatContext
    {
        /// <summary>A class for logging and Exports (de)muxer private options if they exist.</summary>
        internal AVClass* @av_class;
        /// <summary>The input container format.</summary>
        internal AVInputFormat* @iformat;
        /// <summary>The output container format.</summary>
        internal AVOutputFormat* @oformat;
        /// <summary>Format private data. This is an AVOptions-enabled struct if and only if iformat/oformat.priv_class is not NULL.</summary>
        internal void* @priv_data;
        /// <summary>I/O context.</summary>
        internal AVIOContext* @pb;
        /// <summary>Flags signalling stream properties. A combination of AVFMTCTX_*. Set by libavformat.</summary>
        internal int @ctx_flags;
        /// <summary>Number of elements in AVFormatContext.streams.</summary>
        internal uint @nb_streams;
        /// <summary>A list of all streams in the file. New streams are created with avformat_new_stream().</summary>
        internal AVStream** @streams;
        /// <summary>input or output filename</summary>
        internal byte_array1024 @filename;
        /// <summary>input or output URL. Unlike the old filename field, this field has no length restriction.</summary>
        internal byte* @url;
        /// <summary>Position of the first frame of the component, in AV_TIME_BASE fractional seconds. NEVER set this value directly: It is deduced from the AVStream values.</summary>
        internal long @start_time;
        /// <summary>Duration of the stream, in AV_TIME_BASE fractional seconds. Only set this value if you know none of the individual stream durations and also do not set any of them. This is deduced from the AVStream values if not set.</summary>
        internal long @duration;
        /// <summary>Total stream bitrate in bit/s, 0 if not available. Never set it directly if the file_size and the duration are known as FFmpeg can compute it automatically.</summary>
        internal long @bit_rate;
        internal uint @packet_size;
        internal int @max_delay;
        /// <summary>Flags modifying the (de)muxer behaviour. A combination of AVFMT_FLAG_*. Set by the user before avformat_open_input() / avformat_write_header().</summary>
        internal int @flags;
        /// <summary>Maximum size of the data read from input for determining the input container format. Demuxing only, set by the caller before avformat_open_input().</summary>
        internal long @probesize;
        /// <summary>Maximum duration (in AV_TIME_BASE units) of the data read from input in avformat_find_stream_info(). Demuxing only, set by the caller before avformat_find_stream_info(). Can be set to 0 to let avformat choose using a heuristic.</summary>
        internal long @max_analyze_duration;
        internal byte* @key;
        internal int @keylen;
        internal uint @nb_programs;
        internal AVProgram** @programs;
        /// <summary>Forced video codec_id. Demuxing: Set by user.</summary>
        internal AVCodecID @video_codec_id;
        /// <summary>Forced audio codec_id. Demuxing: Set by user.</summary>
        internal AVCodecID @audio_codec_id;
        /// <summary>Forced subtitle codec_id. Demuxing: Set by user.</summary>
        internal AVCodecID @subtitle_codec_id;
        /// <summary>Maximum amount of memory in bytes to use for the index of each stream. If the index exceeds this size, entries will be discarded as needed to maintain a smaller size. This can lead to slower or less accurate seeking (depends on demuxer). Demuxers for which a full in-memory index is mandatory will ignore this. - muxing: unused - demuxing: set by user</summary>
        internal uint @max_index_size;
        /// <summary>Maximum amount of memory in bytes to use for buffering frames obtained from realtime capture devices.</summary>
        internal uint @max_picture_buffer;
        /// <summary>Number of chapters in AVChapter array. When muxing, chapters are normally written in the file header, so nb_chapters should normally be initialized before write_header is called. Some muxers (e.g. mov and mkv) can also write chapters in the trailer. To write chapters in the trailer, nb_chapters must be zero when write_header is called and non-zero when write_trailer is called. - muxing: set by user - demuxing: set by libavformat</summary>
        internal uint @nb_chapters;
        internal AVChapter** @chapters;
        /// <summary>Metadata that applies to the whole file.</summary>
        internal AVDictionary* @metadata;
        /// <summary>Start time of the stream in real world time, in microseconds since the Unix epoch (00:00 1st January 1970). That is, pts=0 in the stream was captured at this real world time. - muxing: Set by the caller before avformat_write_header(). If set to either 0 or AV_NOPTS_VALUE, then the current wall-time will be used. - demuxing: Set by libavformat. AV_NOPTS_VALUE if unknown. Note that the value may become known after some number of frames have been received.</summary>
        internal long @start_time_realtime;
        /// <summary>The number of frames used for determining the framerate in avformat_find_stream_info(). Demuxing only, set by the caller before avformat_find_stream_info().</summary>
        internal int @fps_probe_size;
        /// <summary>Error recognition; higher values will detect more errors but may misdetect some more or less valid parts as errors. Demuxing only, set by the caller before avformat_open_input().</summary>
        internal int @error_recognition;
        /// <summary>Custom interrupt callbacks for the I/O layer.</summary>
        internal AVIOInterruptCB @interrupt_callback;
        /// <summary>Flags to enable debugging.</summary>
        internal int @debug;
        /// <summary>Maximum buffering duration for interleaving.</summary>
        internal long @max_interleave_delta;
        /// <summary>Allow non-standard and experimental extension</summary>
        internal int @strict_std_compliance;
        /// <summary>Flags for the user to detect events happening on the file. Flags must be cleared by the user once the event has been handled. A combination of AVFMT_EVENT_FLAG_*.</summary>
        internal int @event_flags;
        /// <summary>Maximum number of packets to read while waiting for the first timestamp. Decoding only.</summary>
        internal int @max_ts_probe;
        /// <summary>Avoid negative timestamps during muxing. Any value of the AVFMT_AVOID_NEG_TS_* constants. Note, this only works when using av_interleaved_write_frame. (interleave_packet_per_dts is in use) - muxing: Set by user - demuxing: unused</summary>
        internal int @avoid_negative_ts;
        /// <summary>Transport stream id. This will be moved into demuxer private options. Thus no API/ABI compatibility</summary>
        internal int @ts_id;
        /// <summary>Audio preload in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused</summary>
        internal int @audio_preload;
        /// <summary>Max chunk time in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused</summary>
        internal int @max_chunk_duration;
        /// <summary>Max chunk size in bytes Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused</summary>
        internal int @max_chunk_size;
        /// <summary>forces the use of wallclock timestamps as pts/dts of packets This has undefined results in the presence of B frames. - encoding: unused - decoding: Set by user</summary>
        internal int @use_wallclock_as_timestamps;
        /// <summary>avio flags, used to force AVIO_FLAG_DIRECT. - encoding: unused - decoding: Set by user</summary>
        internal int @avio_flags;
        /// <summary>The duration field can be estimated through various ways, and this field can be used to know how the duration was estimated. - encoding: unused - decoding: Read by user</summary>
        internal AVDurationEstimationMethod @duration_estimation_method;
        /// <summary>Skip initial bytes when opening stream - encoding: unused - decoding: Set by user</summary>
        internal long @skip_initial_bytes;
        /// <summary>Correct single timestamp overflows - encoding: unused - decoding: Set by user</summary>
        internal uint @correct_ts_overflow;
        /// <summary>Force seeking to any (also non key) frames. - encoding: unused - decoding: Set by user</summary>
        internal int @seek2any;
        /// <summary>Flush the I/O context after each packet. - encoding: Set by user - decoding: unused</summary>
        internal int @flush_packets;
        /// <summary>format probing score. The maximal score is AVPROBE_SCORE_MAX, its set when the demuxer probes the format. - encoding: unused - decoding: set by avformat, read by user</summary>
        internal int @probe_score;
        /// <summary>number of bytes to read maximally to identify format. - encoding: unused - decoding: set by user</summary>
        internal int @format_probesize;
        /// <summary>&apos;,&apos; separated list of allowed decoders. If NULL then all are allowed - encoding: unused - decoding: set by user</summary>
        internal byte* @codec_whitelist;
        /// <summary>&apos;,&apos; separated list of allowed demuxers. If NULL then all are allowed - encoding: unused - decoding: set by user</summary>
        internal byte* @format_whitelist;
        /// <summary>An opaque field for libavformat internal usage. Must not be accessed in any way by callers.</summary>
        internal AVFormatInternal* @internal;
        /// <summary>IO repositioned flag. This is set by avformat when the underlaying IO context read pointer is repositioned, for example when doing byte based seeking. Demuxers can use the flag to detect such changes.</summary>
        internal int @io_repositioned;
        /// <summary>Forced video codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user</summary>
        internal AVCodec* @video_codec;
        /// <summary>Forced audio codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user</summary>
        internal AVCodec* @audio_codec;
        /// <summary>Forced subtitle codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user</summary>
        internal AVCodec* @subtitle_codec;
        /// <summary>Forced data codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user</summary>
        internal AVCodec* @data_codec;
        /// <summary>Number of bytes to be written as padding in a metadata header. Demuxing: Unused. Muxing: Set by user via av_format_set_metadata_header_padding.</summary>
        internal int @metadata_header_padding;
        /// <summary>User data. This is a place for some private data of the user.</summary>
        internal void* @opaque;
        /// <summary>Callback used by devices to communicate with application.</summary>
        internal IntPtr @control_message_cb;
        /// <summary>Output timestamp offset, in microseconds. Muxing: set by user</summary>
        internal long @output_ts_offset;
        /// <summary>dump format separator. can be &quot;, &quot; or &quot; &quot; or anything else - muxing: Set by user. - demuxing: Set by user.</summary>
        internal byte* @dump_separator;
        /// <summary>Forced Data codec_id. Demuxing: Set by user.</summary>
        internal AVCodecID @data_codec_id;
        /// <summary>Called to open further IO contexts when needed for demuxing.</summary>
        internal IntPtr @open_cb;
        /// <summary>&apos;,&apos; separated list of allowed protocols. - encoding: unused - decoding: set by user</summary>
        internal byte* @protocol_whitelist;
        /// <summary>A callback for opening new IO streams.</summary>
        internal IntPtr @io_open;
        /// <summary>A callback for closing the streams opened with AVFormatContext.io_open().</summary>
        internal IntPtr @io_close;
        /// <summary>&apos;,&apos; separated list of disallowed protocols. - encoding: unused - decoding: set by user</summary>
        internal byte* @protocol_blacklist;
        /// <summary>The maximum number of streams. - encoding: unused - decoding: set by user</summary>
        internal int @max_streams;
    }

    /// <summary>@{</summary>
    internal unsafe struct AVInputFormat
    {
        /// <summary>A comma separated list of short names for the format. New names may be appended with a minor bump.</summary>
        internal byte* @name;
        /// <summary>Descriptive name for the format, meant to be more human-readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.</summary>
        internal byte* @long_name;
        /// <summary>Can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_SHOW_IDS, AVFMT_GENERIC_INDEX, AVFMT_TS_DISCONT, AVFMT_NOBINSEARCH, AVFMT_NOGENSEARCH, AVFMT_NO_BYTE_SEEK, AVFMT_SEEK_TO_PTS.</summary>
        internal int @flags;
        /// <summary>If extensions are defined, then no probe is done. You should usually not use extension format guessing because it is not reliable enough</summary>
        internal byte* @extensions;
        internal AVCodecTag** @codec_tag;
        /// <summary>AVClass for the private context</summary>
        internal AVClass* @priv_class;
        /// <summary>Comma-separated list of mime types. It is used check for matching mime types while probing.</summary>
        internal byte* @mime_type;
        /// <summary>*************************************************************** No fields below this line are part of the internal API. They may not be used outside of libavformat and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal AVInputFormat* @next;
        /// <summary>Raw demuxers store their codec ID here.</summary>
        internal int @raw_codec_id;
        /// <summary>Size of private data so that it can be allocated in the wrapper.</summary>
        internal int @priv_data_size;
        /// <summary>Tell if a given file has a chance of being parsed as this format. The buffer provided is guaranteed to be AVPROBE_PADDING_SIZE bytes big so you do not have to check for that unless you need more.</summary>
        internal IntPtr @read_probe;
        /// <summary>Read the format header and initialize the AVFormatContext structure. Return 0 if OK. &apos;avformat_new_stream&apos; should be called to create new streams.</summary>
        internal IntPtr @read_header;
        /// <summary>Read one packet and put it in &apos;pkt&apos;. pts and flags are also set. &apos;avformat_new_stream&apos; can be called only if the flag AVFMTCTX_NOHEADER is used and only in the calling thread (not in a background thread).</summary>
        internal IntPtr @read_packet;
        /// <summary>Close the stream. The AVFormatContext and AVStreams are not freed by this function</summary>
        internal IntPtr @read_close;
        /// <summary>Seek to a given timestamp relative to the frames in stream component stream_index.</summary>
        internal IntPtr @read_seek;
        /// <summary>Get the next timestamp in stream[stream_index].time_base units.</summary>
        internal IntPtr @read_timestamp;
        /// <summary>Start/resume playing - only meaningful if using a network-based format (RTSP).</summary>
        internal IntPtr @read_play;
        /// <summary>Pause playing - only meaningful if using a network-based format (RTSP).</summary>
        internal IntPtr @read_pause;
        /// <summary>Seek to timestamp ts. Seeking will be done so that the point from which all active streams can be presented successfully will be closest to ts and within min/max_ts. Active streams are all streams that have AVStream.discard &lt; AVDISCARD_ALL.</summary>
        internal IntPtr @read_seek2;
        /// <summary>Returns device list with it properties.</summary>
        internal IntPtr @get_device_list;
        /// <summary>Initialize device capabilities submodule.</summary>
        internal IntPtr @create_device_capabilities;
        /// <summary>Free device capabilities submodule.</summary>
        internal IntPtr @free_device_capabilities;
    }

    /// <summary>List of devices.</summary>
    internal unsafe struct AVDeviceInfoList
    {
        /// <summary>list of autodetected devices</summary>
        internal AVDeviceInfo** @devices;
        /// <summary>number of autodetected devices</summary>
        internal int @nb_devices;
        /// <summary>index of default device or -1 if no default</summary>
        internal int @default_device;
    }

    /// <summary>Structure describes device capabilities.</summary>
    internal unsafe struct AVDeviceCapabilitiesQuery
    {
        internal AVClass* @av_class;
        internal AVFormatContext* @device_context;
        internal AVCodecID @codec;
        internal AVSampleFormat @sample_format;
        internal AVPixelFormat @pixel_format;
        internal int @sample_rate;
        internal int @channels;
        internal long @channel_layout;
        internal int @window_width;
        internal int @window_height;
        internal int @frame_width;
        internal int @frame_height;
        internal AVRational @fps;
    }

    /// <summary>Bytestream IO Context. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVIOContext) must not be used outside libav*.</summary>
    internal unsafe struct AVIOContext
    {
        /// <summary>A class for private options.</summary>
        internal AVClass* @av_class;
        /// <summary>Start of the buffer.</summary>
        internal byte* @buffer;
        /// <summary>Maximum buffer size</summary>
        internal int @buffer_size;
        /// <summary>Current position in the buffer</summary>
        internal byte* @buf_ptr;
        /// <summary>End of the data, may be less than buffer+buffer_size if the read function returned less data than requested, e.g. for streams where no more data has been received yet.</summary>
        internal byte* @buf_end;
        /// <summary>A private pointer, passed to the read/write/seek/... functions.</summary>
        internal void* @opaque;
        internal AVIOContext_read_packet_func @read_packet;
        internal AVIOContext_write_packet_func @write_packet;
        internal AVIOContext_seek_func @seek;
        /// <summary>position in the file of the current buffer</summary>
        internal long @pos;
        /// <summary>true if eof reached</summary>
        internal int @eof_reached;
        /// <summary>true if open for writing</summary>
        internal int @write_flag;
        internal int @max_packet_size;
        internal ulong @checksum;
        internal byte* @checksum_ptr;
        internal IntPtr @update_checksum;
        /// <summary>contains the error code or 0 if no error happened</summary>
        internal int @error;
        /// <summary>Pause or resume playback for network streaming protocols - e.g. MMS.</summary>
        internal IntPtr @read_pause;
        /// <summary>Seek to a given timestamp in stream with the specified stream_index. Needed for some network streaming protocols which don&apos;t support seeking to byte position.</summary>
        internal IntPtr @read_seek;
        /// <summary>A combination of AVIO_SEEKABLE_ flags or 0 when the stream is not seekable.</summary>
        internal int @seekable;
        /// <summary>max filesize, used to limit allocations This field is internal to libavformat and access from outside is not allowed.</summary>
        internal long @maxsize;
        /// <summary>avio_read and avio_write should if possible be satisfied directly instead of going through a buffer, and avio_seek will always call the underlying seek function directly.</summary>
        internal int @direct;
        /// <summary>Bytes read statistic This field is internal to libavformat and access from outside is not allowed.</summary>
        internal long @bytes_read;
        /// <summary>seek statistic This field is internal to libavformat and access from outside is not allowed.</summary>
        internal int @seek_count;
        /// <summary>writeout statistic This field is internal to libavformat and access from outside is not allowed.</summary>
        internal int @writeout_count;
        /// <summary>Original buffer size used internally after probing and ensure seekback to reset the buffer size This field is internal to libavformat and access from outside is not allowed.</summary>
        internal int @orig_buffer_size;
        /// <summary>Threshold to favor readahead over seek. This is current internal only, do not use from outside.</summary>
        internal int @short_seek_threshold;
        /// <summary>&apos;,&apos; separated list of allowed protocols.</summary>
        internal byte* @protocol_whitelist;
        /// <summary>&apos;,&apos; separated list of disallowed protocols.</summary>
        internal byte* @protocol_blacklist;
        /// <summary>A callback that is used instead of write_packet.</summary>
        internal IntPtr @write_data_type;
        /// <summary>If set, don&apos;t call write_data_type separately for AVIO_DATA_MARKER_BOUNDARY_POINT, but ignore them and treat them as AVIO_DATA_MARKER_UNKNOWN (to avoid needlessly small chunks of data returned from the callback).</summary>
        internal int @ignore_boundary_point;
        /// <summary>Internal, not meant to be used from outside of AVIOContext.</summary>
        internal AVIODataMarkerType @current_type;
        internal long @last_time;
        /// <summary>A callback that is used instead of short_seek_threshold. This is current internal only, do not use from outside.</summary>
        internal IntPtr @short_seek_get;
        internal long @written;
        /// <summary>Maximum reached position before a backward seek in the write buffer, used keeping track of already written data for a later flush.</summary>
        internal byte* @buf_ptr_max;
        /// <summary>Try to buffer at least this amount of data before flushing it</summary>
        internal int @min_packet_size;
    }

    /// <summary>Callback for checking whether to abort blocking functions. AVERROR_EXIT is returned in this case by the interrupted function. During blocking operations, callback is called with opaque as parameter. If the callback returns 1, the blocking operation will be aborted.</summary>
    internal unsafe struct AVIOInterruptCB
    {
        internal IntPtr @callback;
        internal void* @opaque;
    }

    /// <summary>Describes single entry of the directory.</summary>
    internal unsafe struct AVIODirEntry
    {
        /// <summary>Filename</summary>
        internal byte* @name;
        /// <summary>Type of the entry</summary>
        internal int @type;
        /// <summary>Set to 1 when name is encoded with UTF-8, 0 otherwise. Name can be encoded with UTF-8 even though 0 is set.</summary>
        internal int @utf8;
        /// <summary>File size in bytes, -1 if unknown.</summary>
        internal long @size;
        /// <summary>Time of last modification in microseconds since unix epoch, -1 if unknown.</summary>
        internal long @modification_timestamp;
        /// <summary>Time of last access in microseconds since unix epoch, -1 if unknown.</summary>
        internal long @access_timestamp;
        /// <summary>Time of last status change in microseconds since unix epoch, -1 if unknown.</summary>
        internal long @status_change_timestamp;
        /// <summary>User ID of owner, -1 if unknown.</summary>
        internal long @user_id;
        /// <summary>Group ID of owner, -1 if unknown.</summary>
        internal long @group_id;
        /// <summary>Unix file mode, -1 if unknown.</summary>
        internal long @filemode;
    }

    internal unsafe struct AVIODirContext
    {
        internal URLContext* @url_context;
    }

    /// <summary>An instance of a filter</summary>
    internal unsafe struct AVFilterContext
    {
        /// <summary>needed for av_log() and filters common options</summary>
        internal AVClass* @av_class;
        /// <summary>the AVFilter of which this is an instance</summary>
        internal AVFilter* @filter;
        /// <summary>name of this filter instance</summary>
        internal byte* @name;
        /// <summary>array of input pads</summary>
        internal AVFilterPad* @input_pads;
        /// <summary>array of pointers to input links</summary>
        internal AVFilterLink** @inputs;
        /// <summary>number of input pads</summary>
        internal uint @nb_inputs;
        /// <summary>array of output pads</summary>
        internal AVFilterPad* @output_pads;
        /// <summary>array of pointers to output links</summary>
        internal AVFilterLink** @outputs;
        /// <summary>number of output pads</summary>
        internal uint @nb_outputs;
        /// <summary>private data for use by the filter</summary>
        internal void* @priv;
        /// <summary>filtergraph this filter belongs to</summary>
        internal AVFilterGraph* @graph;
        /// <summary>Type of multithreading being allowed/used. A combination of AVFILTER_THREAD_* flags.</summary>
        internal int @thread_type;
        /// <summary>An opaque struct for libavfilter internal use.</summary>
        internal AVFilterInternal* @internal;
        internal AVFilterCommand* @command_queue;
        /// <summary>enable expression string</summary>
        internal byte* @enable_str;
        /// <summary>parsed expression (AVExpr*)</summary>
        internal void* @enable;
        /// <summary>variable values for the enable expression</summary>
        internal double* @var_values;
        /// <summary>the enabled state from the last expression evaluation</summary>
        internal int @is_disabled;
        /// <summary>For filters which will create hardware frames, sets the device the filter should create them in. All other filters will ignore this field: in particular, a filter which consumes or processes hardware frames will instead use the hw_frames_ctx field in AVFilterLink to carry the hardware context information.</summary>
        internal AVBufferRef* @hw_device_ctx;
        /// <summary>Max number of threads allowed in this filter instance. If &lt;= 0, its value is ignored. Overrides global number of threads set per filter graph.</summary>
        internal int @nb_threads;
        /// <summary>Ready status of the filter. A non-0 value means that the filter needs activating; a higher value suggests a more urgent activation.</summary>
        internal uint @ready;
        /// <summary>Sets the number of extra hardware frames which the filter will allocate on its output links for use in following filters or by the caller.</summary>
        internal int @extra_hw_frames;
    }

    /// <summary>Filter definition. This defines the pads a filter contains, and all the callback functions used to interact with the filter.</summary>
    internal unsafe struct AVFilter
    {
        /// <summary>Filter name. Must be non-NULL and unique among filters.</summary>
        internal byte* @name;
        /// <summary>A description of the filter. May be NULL.</summary>
        internal byte* @description;
        /// <summary>List of inputs, terminated by a zeroed element.</summary>
        internal AVFilterPad* @inputs;
        /// <summary>List of outputs, terminated by a zeroed element.</summary>
        internal AVFilterPad* @outputs;
        /// <summary>A class for the private data, used to declare filter private AVOptions. This field is NULL for filters that do not declare any options.</summary>
        internal AVClass* @priv_class;
        /// <summary>A combination of AVFILTER_FLAG_*</summary>
        internal int @flags;
        /// <summary>Filter pre-initialization function</summary>
        internal IntPtr @preinit;
        /// <summary>Filter initialization function.</summary>
        internal IntPtr @init;
        /// <summary>Should be set instead of want to pass a dictionary of AVOptions to nested contexts that are allocated during init.</summary>
        internal IntPtr @init_dict;
        /// <summary>Filter uninitialization function.</summary>
        internal IntPtr @uninit;
        /// <summary>Query formats supported by the filter on its inputs and outputs.</summary>
        internal IntPtr @query_formats;
        /// <summary>size of private data to allocate for the filter</summary>
        internal int @priv_size;
        /// <summary>Additional flags for avfilter internal use only.</summary>
        internal int @flags_internal;
        /// <summary>Used by the filter registration system. Must not be touched by any other code.</summary>
        internal AVFilter* @next;
        /// <summary>Make the filter instance process a command.</summary>
        internal IntPtr @process_command;
        /// <summary>Filter initialization function, alternative to the init() callback. Args contains the user-supplied parameters, opaque is used for providing binary data.</summary>
        internal IntPtr @init_opaque;
        /// <summary>Filter activation function.</summary>
        internal IntPtr @activate;
    }

    /// <summary>A link between two filters. This contains pointers to the source and destination filters between which this link exists, and the indexes of the pads involved. In addition, this link also contains the parameters which have been negotiated and agreed upon between the filter, such as image dimensions, format, etc.</summary>
    internal unsafe struct AVFilterLink
    {
        /// <summary>source filter</summary>
        internal AVFilterContext* @src;
        /// <summary>output pad on the source filter</summary>
        internal AVFilterPad* @srcpad;
        /// <summary>dest filter</summary>
        internal AVFilterContext* @dst;
        /// <summary>input pad on the dest filter</summary>
        internal AVFilterPad* @dstpad;
        /// <summary>filter media type</summary>
        internal AVMediaType @type;
        /// <summary>agreed upon image width</summary>
        internal int @w;
        /// <summary>agreed upon image height</summary>
        internal int @h;
        /// <summary>agreed upon sample aspect ratio</summary>
        internal AVRational @sample_aspect_ratio;
        /// <summary>channel layout of current buffer (see libavutil/channel_layout.h)</summary>
        internal ulong @channel_layout;
        /// <summary>samples per second</summary>
        internal int @sample_rate;
        /// <summary>agreed upon media format</summary>
        internal int @format;
        /// <summary>Define the time base used by the PTS of the frames/samples which will pass through this link. During the configuration stage, each filter is supposed to change only the output timebase, while the timebase of the input link is assumed to be an unchangeable property.</summary>
        internal AVRational @time_base;
        /// <summary>*************************************************************** All fields below this line are not part of the internal API. They may not be used outside of libavfilter and can be changed and removed at will. New internal fields should be added right above. ****************************************************************</summary>
        internal AVFilterFormats* @in_formats;
        internal AVFilterFormats* @out_formats;
        /// <summary>Lists of channel layouts and sample rates used for automatic negotiation.</summary>
        internal AVFilterFormats* @in_samplerates;
        internal AVFilterFormats* @out_samplerates;
        internal AVFilterChannelLayouts* @in_channel_layouts;
        internal AVFilterChannelLayouts* @out_channel_layouts;
        /// <summary>Audio only, the destination filter sets this to a non-zero value to request that buffers with the given number of samples should be sent to it. AVFilterPad.needs_fifo must also be set on the corresponding input pad. Last buffer before EOF will be padded with silence.</summary>
        internal int @request_samples;
        internal AVFilterLink_init_state @init_state;
        /// <summary>Graph the filter belongs to.</summary>
        internal AVFilterGraph* @graph;
        /// <summary>Current timestamp of the link, as defined by the most recent frame(s), in link time_base units.</summary>
        internal long @current_pts;
        /// <summary>Current timestamp of the link, as defined by the most recent frame(s), in AV_TIME_BASE units.</summary>
        internal long @current_pts_us;
        /// <summary>Index in the age array.</summary>
        internal int @age_index;
        /// <summary>Frame rate of the stream on the link, or 1/0 if unknown or variable; if left to 0/0, will be automatically copied from the first input of the source filter if it exists.</summary>
        internal AVRational @frame_rate;
        /// <summary>Buffer partially filled with samples to achieve a fixed/minimum size.</summary>
        internal AVFrame* @partial_buf;
        /// <summary>Size of the partial buffer to allocate. Must be between min_samples and max_samples.</summary>
        internal int @partial_buf_size;
        /// <summary>Minimum number of samples to filter at once. If filter_frame() is called with fewer samples, it will accumulate them in partial_buf. This field and the related ones must not be changed after filtering has started. If 0, all related fields are ignored.</summary>
        internal int @min_samples;
        /// <summary>Maximum number of samples to filter at once. If filter_frame() is called with more samples, it will split them.</summary>
        internal int @max_samples;
        /// <summary>Number of channels.</summary>
        internal int @channels;
        /// <summary>Link processing flags.</summary>
        internal uint @flags;
        /// <summary>Number of past frames sent through the link.</summary>
        internal long @frame_count_in;
        /// <summary>Number of past frames sent through the link.</summary>
        internal long @frame_count_out;
        /// <summary>A pointer to a FFFramePool struct.</summary>
        internal void* @frame_pool;
        /// <summary>True if a frame is currently wanted on the output of this filter. Set when ff_request_frame() is called by the output, cleared when a frame is filtered.</summary>
        internal int @frame_wanted_out;
        /// <summary>For hwaccel pixel formats, this should be a reference to the AVHWFramesContext describing the frames.</summary>
        internal AVBufferRef* @hw_frames_ctx;
        /// <summary>Internal structure members. The fields below this limit are internal for libavfilter&apos;s use and must in no way be accessed by applications.</summary>
        internal byte_array61440 @reserved;
    }

    internal unsafe struct AVFilterGraph
    {
        internal AVClass* @av_class;
        internal AVFilterContext** @filters;
        internal uint @nb_filters;
        /// <summary>sws options to use for the auto-inserted scale filters</summary>
        internal byte* @scale_sws_opts;
        /// <summary>libavresample options to use for the auto-inserted resample filters</summary>
        internal byte* @resample_lavr_opts;
        /// <summary>Type of multithreading allowed for filters in this graph. A combination of AVFILTER_THREAD_* flags.</summary>
        internal int @thread_type;
        /// <summary>Maximum number of threads used by filters in this graph. May be set by the caller before adding any filters to the filtergraph. Zero (the default) means that the number of threads is determined automatically.</summary>
        internal int @nb_threads;
        /// <summary>Opaque object for libavfilter internal use.</summary>
        internal AVFilterGraphInternal* @internal;
        /// <summary>Opaque user data. May be set by the caller to an arbitrary value, e.g. to be used from callbacks like Libavfilter will not touch this field in any way.</summary>
        internal void* @opaque;
        /// <summary>This callback may be set by the caller immediately after allocating the graph and before adding any filters to it, to provide a custom multithreading implementation.</summary>
        internal IntPtr @execute;
        /// <summary>swr options to use for the auto-inserted aresample filters, Access ONLY through AVOptions</summary>
        internal byte* @aresample_swr_opts;
        /// <summary>Private fields</summary>
        internal AVFilterLink** @sink_links;
        internal int @sink_links_count;
        internal uint @disable_auto_convert;
    }

    /// <summary>A linked-list of the inputs/outputs of the filter chain.</summary>
    internal unsafe struct AVFilterInOut
    {
        /// <summary>unique name for this input/output in the list</summary>
        internal byte* @name;
        /// <summary>filter context associated to this input/output</summary>
        internal AVFilterContext* @filter_ctx;
        /// <summary>index of the filt_ctx pad to use for linking</summary>
        internal int @pad_idx;
        /// <summary>next input/input in the list, NULL if this is the last</summary>
        internal AVFilterInOut* @next;
    }

    /// <summary>This structure contains the parameters describing the frames that will be passed to this filter.</summary>
    internal unsafe struct AVBufferSrcParameters
    {
        /// <summary>video: the pixel format, value corresponds to enum AVPixelFormat audio: the sample format, value corresponds to enum AVSampleFormat</summary>
        internal int @format;
        /// <summary>The timebase to be used for the timestamps on the input frames.</summary>
        internal AVRational @time_base;
        /// <summary>Video only, the display dimensions of the input frames.</summary>
        internal int @width;
        /// <summary>Video only, the display dimensions of the input frames.</summary>
        internal int @height;
        /// <summary>Video only, the sample (pixel) aspect ratio.</summary>
        internal AVRational @sample_aspect_ratio;
        /// <summary>Video only, the frame rate of the input video. This field must only be set to a non-zero value if input stream has a known constant framerate and should be left at its initial value if the framerate is variable or unknown.</summary>
        internal AVRational @frame_rate;
        /// <summary>Video with a hwaccel pixel format only. This should be a reference to an AVHWFramesContext instance describing the input frames.</summary>
        internal AVBufferRef* @hw_frames_ctx;
        /// <summary>Audio only, the audio sampling rate in samples per secon.</summary>
        internal int @sample_rate;
        /// <summary>Audio only, the audio channel layout</summary>
        internal ulong @channel_layout;
    }

    /// <summary>Struct to use for initializing a buffersink context.</summary>
    internal unsafe struct AVBufferSinkParams
    {
        /// <summary>list of allowed pixel formats, terminated by AV_PIX_FMT_NONE</summary>
        internal AVPixelFormat* @pixel_fmts;
    }

    /// <summary>Struct to use for initializing an abuffersink context.</summary>
    internal unsafe struct AVABufferSinkParams
    {
        /// <summary>list of allowed sample formats, terminated by AV_SAMPLE_FMT_NONE</summary>
        internal AVSampleFormat* @sample_fmts;
        /// <summary>list of allowed channel layouts, terminated by -1</summary>
        internal long* @channel_layouts;
        /// <summary>list of allowed channel counts, terminated by -1</summary>
        internal int* @channel_counts;
        /// <summary>if not 0, accept any channel count or layout</summary>
        internal int @all_channel_counts;
        /// <summary>list of allowed sample rates, terminated by -1</summary>
        internal int* @sample_rates;
    }

    /// <summary>Structure describes basic parameters of the device.</summary>
    internal unsafe struct AVDeviceInfo
    {
        /// <summary>device name, format depends on device</summary>
        internal byte* @device_name;
        /// <summary>human friendly name</summary>
        internal byte* @device_description;
    }

    internal unsafe struct AVDeviceRect
    {
        /// <summary>x coordinate of top left corner</summary>
        internal int @x;
        /// <summary>y coordinate of top left corner</summary>
        internal int @y;
        /// <summary>width</summary>
        internal int @width;
        /// <summary>height</summary>
        internal int @height;
    }

    internal unsafe struct AVAudioFifo
    {
    }

    internal unsafe struct AVBPrint
    {
    }

    internal unsafe struct AVDictionary
    {
    }

    internal unsafe struct AVBuffer
    {
    }

    internal unsafe struct AVBufferPool
    {
    }

    internal unsafe struct AVHWDeviceInternal
    {
    }

    internal unsafe struct AVHWFramesInternal
    {
    }

    internal unsafe struct SwrContext
    {
    }

    internal unsafe struct SwsContext
    {
    }

    internal unsafe struct AVCodecDefault
    {
    }

    internal unsafe struct AVCodecHWConfigInternal
    {
    }

    internal unsafe struct AVCodecInternal
    {
    }

    internal unsafe struct MpegEncContext
    {
    }

    internal unsafe struct AVBSFInternal
    {
    }

    internal unsafe struct AVBSFList
    {
    }

    internal unsafe struct AVStreamInternal
    {
    }

    internal unsafe struct AVFormatInternal
    {
    }

    internal unsafe struct AVCodecTag
    {
    }

    internal unsafe struct URLContext
    {
    }

    internal unsafe struct AVFilterPad
    {
    }

    internal unsafe struct AVFilterFormats
    {
    }

    internal unsafe struct AVFilterChannelLayouts
    {
    }

    internal unsafe struct AVFilterGraphInternal
    {
    }

    internal unsafe struct AVFilterInternal
    {
    }

    internal unsafe struct AVFilterCommand
    {
    }
}

#pragma warning restore CS0649