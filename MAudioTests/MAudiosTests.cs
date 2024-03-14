using System.Threading;
using MAudio;
using MechTE_480.FormCategory;
using MechTE_480.util;
using Xunit;
using Xunit.Abstractions;

namespace MAudioTests
{
    public class MAudiosTests
    {
        
        private readonly ITestOutputHelper _msg;

        public MAudiosTests(ITestOutputHelper msg)
        {
            _msg = msg;
        }
        [Fact]
        public void AudioTest()
        {
            var aPath = MUtil.GetCurrentProgramDirectory() + @"\rec.wav";
            // 开始录音
            MAudios.CleWavStart(aPath);
            if (!MFormUtil.MesBox("正在录音", "录音测试"))
            {
                //停止录音
                MAudios.CleWavStop();
            }
        
            MAudios.CleWavStop();
            Thread.Sleep(500); 
            MAudios.PlayCleWav(aPath);
        }
    }
}