using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度

    private bool moveRight = true; // 初始方向为向右

    private void Update()
    {
        // 获取当前物体的刚体组件
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // 根据当前方向更新物体的速度
        float horizontalMovement = moveRight ? moveSpeed : -moveSpeed;
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当物体碰到其他物体时，改变移动方向
        moveRight = !moveRight;
    }
}