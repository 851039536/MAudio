using NAudio.Wave;

namespace MAudio
{
   public  class MAudios
    {
        #region 控制台录音播放

        private static WaveInEvent _cle;
        private static WaveFileWriter _cleFileWriter;
        /// <summary>
        /// 计算已录制的秒数
        /// </summary>
        public static int SecondsRecordedCle;

        /// <summary>
        /// 控制台录音
        /// </summary>
        /// <param name="filePath">wav文件路径</param>
        public static void CleWavStart(string filePath)
        {
            // 创建对象
            _cle = new WaveInEvent();
            // 添加DataAvailable事件处理回调
            _cle.DataAvailable += OnDataAvailable;
            // 创建WaveFileWriter对象
            _cleFileWriter = new WaveFileWriter(filePath,_cle.WaveFormat);
            // 开始录音
            _cle.StartRecording();


        }

        /// <summary>
        /// 控制台停止录音
        /// </summary>
        public static void CleWavStop()
        {
            _cle?.StopRecording();

            _cle?.Dispose();

            _cleFileWriter?.Close();
            _cleFileWriter = null;
        }


        /// <summary>
        /// 录音数据回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnDataAvailable(object sender,WaveInEventArgs e)
        {
            // 写入录音数据
            _cleFileWriter.Write(e.Buffer,0,e.BytesRecorded);
            // 计算已录制的秒数
            SecondsRecordedCle = (int)_cleFileWriter.Length / _cleFileWriter.WaveFormat.AverageBytesPerSecond;
        }


        /// <summary>
        /// 控制台循环播放录音(弹窗播放)
        /// </summary>
        /// <param name="filePath">wav文件路径</param>
        public static string PlayCleWav(string filePath)
        {
            var player = new System.Media.SoundPlayer(filePath);
            player.PlayLooping();

            // 如果用户选择没有录音，则将错误标志设置为false
            if (!MForm.MesBox("录音回拨,是否有声音?","录音检测"))
            {
                player.Stop();
                player.Dispose();
                return "False";
            }
            player.Stop();
            player.Dispose();
            return "True";
        }

        #endregion
    }
}
