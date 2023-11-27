using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    private void Update()
    {
        // 检测按键 F1
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // 生成截屏文件名
            string screenshotFileName = $"screenshot_{System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.png";

            // 指定保存路径
            string savePath = Path.Combine(Application.persistentDataPath, "Screenshots");

            // 创建目录（如果不存在）
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            // 完整的保存路径
            string screenshotPath = Path.Combine(savePath, screenshotFileName);

            // 截屏并保存
            ScreenCapture.CaptureScreenshot(screenshotPath);
            Debug.Log($"Screenshot captured at: {screenshotPath}");
        }
    }
}