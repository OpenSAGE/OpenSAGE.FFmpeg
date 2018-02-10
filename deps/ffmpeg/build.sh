./configure --disable-everything --enable-decoder=mp3 --enable-demuxer=mp3 --enable-decoder=vp6 --enable-decoder=vp6a --enable-decoder=vp6f \
--enable-demuxer=ea --enable-decoder=bink --enable-decoder=binkaudio_dct --enable-decoder=binkaudio_rdft --enable-demuxer=bink \
--enable-protocol=file --enable-decoder=adpcm_ea --enable-decoder=adpcm_ea_r3 --enable-shared
make -j4
make install