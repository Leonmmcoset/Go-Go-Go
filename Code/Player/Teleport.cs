using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportLocation;
    public Color teleportColor = Color.blue; // 设置传送后的颜色

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 在这里处理触碰后的显示效果，例如改变颜色
            GetComponent<Renderer>().material.color = teleportColor;

            // 将玩家传送到指定位置
            collision.gameObject.transform.position = teleportLocation.position;
        }
    }
}