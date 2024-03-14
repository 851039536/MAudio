## 音频录制

### 控制台录音

```csharp
public static void CleWavStart(string filePath)
```

###  控制台停止录音

```csharp
/// <summary>
/// 控制台停止录音
/// </summary>
public static void CleWavStop()
```

### 控制台循环播放录音(弹窗播放)

```csharp
 /// <summary>
 /// 控制台循环播放录音(弹窗播放)
 /// </summary>
 /// <param name="filePath">wav文件路径</param>
 public static string PlayCleWav(string filePath)
```

## 示例

```csharp
[Fact]
public void AudioTest()
{
    var aPath = MUtil.GetCurrentProgramDirectory() + @"\rec.wav";
    // 开始录音
    MAudios.CleWavStart(aPath);
    if (!MFormUtil.MesBox("正在录音", "录音测试"))
    {
        MAudios.CleWavStop();
    }
    MAudios.CleWavStop();
    Thread.Sleep(500); 
    MAudios.PlayCleWav(aPath);
}
```

