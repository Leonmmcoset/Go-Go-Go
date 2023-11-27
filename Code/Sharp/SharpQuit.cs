using UnityEngine;
using UnityEngine.SceneManagement;

public class SharpQuit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否与玩家发生碰撞
        if (collision.gameObject.CompareTag("Player"))
        {
            // 重新加载当前场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}