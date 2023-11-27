using UnityEngine;

public class DisplayStats : MonoBehaviour
{
    private float deltaTime = 0.0f;
    public Transform player; // 玩家的 Transform 组件

    void Update()
    {
        // 计算帧率
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int fps = Mathf.CeilToInt(1.0f / deltaTime);
        GUI.Label(new Rect(10, 10, 150, 20), "FPS: " + fps);

        if (player != null)
        {
            Vector3 playerPosition = player.position;
            GUI.Label(new Rect(10, 30, 200, 20), "Player Position: " + playerPosition.ToString("F2"));
        }
        else
        {
            GUI.Label(new Rect(10, 30, 200, 20), "Player not found!");
        }

    }
}