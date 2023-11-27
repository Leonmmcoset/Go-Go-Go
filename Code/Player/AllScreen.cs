using UnityEngine;

public class AllScreen : MonoBehaviour
{
    void Update()
    {
        // 检测 F11 键的按下
        if (Input.GetKeyDown(KeyCode.F11))
        {
            // 切换全屏模式
            ToggleFullscreen();
        }
    }

    void ToggleFullscreen()
    {
        // 判断当前是否为全屏模式
        bool isFullscreen = Screen.fullScreen;

        // 切换全屏状态
        Screen.fullScreen = !isFullscreen;
    }
}