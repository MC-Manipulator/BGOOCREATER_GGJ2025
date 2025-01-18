// 道具泡泡类
using UnityEngine;
using DefaultNameSpace;

public class ToolBubble : Bubble
{
    public float size { get; set; }
    public float speed { get; set; }
    public Vector2 position { get; set; }
    public string movementPattern; // "moving" 或 "stationary"
    public float effectValue; // Buff 或 Debuff 的效果值

    private Vector2 movementDirection; // 移动方向

    private void Start()
    {
        // 初始化泡泡的大小、速度、位置等
        size = 1.0f;
        speed = 2.0f;
        position = transform.position;
        movementPattern = "moving"; // 默认为移动
        movementDirection = new Vector2(1, 0); // 默认向右移动
    }

    // 检测与玩家的碰撞
    public void CheckCollision(PlayerBubble player)
    {
        // 这里可以做碰撞检测，检测是否和玩家泡泡发生碰撞
        if (Vector2.Distance(position, player.position) < size + player.size)
        {
            TriggerEffect(player); // 如果碰撞，则触发效果
        }
    }

    // 与玩家碰撞后触发效果
    public void TriggerEffect(PlayerBubble player)
    {
        // 根据 effectValue 应用 Buff 或 Debuff
        player.ApplyBuff("enlarge"); // 举例，应用增大泡泡效果
        Destroy(gameObject); // 销毁自身
    }

    // 更新泡泡的位置
    public void UpdatePosition(float deltaTime)
    {
        if (movementPattern == "moving")
        {
            // 根据移动模式更新泡泡位置
            position += movementDirection * speed * deltaTime;
            transform.position = position;
        }
        // 如果是 stationary，就不更新位置，保持原地
    }

    private void Update()
    {
        UpdatePosition(Time.deltaTime); // 每帧更新位置
    }
}
