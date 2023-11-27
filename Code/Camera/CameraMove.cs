using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // 玩家的 Transform 组件
    public Vector3 offset;   // 摄像机与玩家的偏移量

    void Update()
    {
        if (target != null)
        {
            // 设置摄像机的位置为玩家的位置加上偏移量
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
        }
    }
}