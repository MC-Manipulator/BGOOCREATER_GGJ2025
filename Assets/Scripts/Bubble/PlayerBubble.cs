// 玩家泡泡类
using UnityEngine;

public class PlayerBubble : MonoBehaviour, Bubble
{
    public float size { get; set; }
    public float speed { get; set; }
    public Vector2 position { get; set; }
    public float flowSpeed; // 上升速度（不受左右控制影响）

    private void Start()
    {
        // 初始化泡泡的大小、速度、位置等
        size = 1.0f;
        speed = 2.0f;
        flowSpeed = 0.2f; // 固定的上升速度
        position = transform.position;
    }

    // 应用 Buff 效果
    public void ApplyBuff(string buffType)
    {
        switch (buffType)
        {
            case "enlarge":
                size *= 1.2f; // 增大泡泡
                break;
            case "speedUp":
                speed *= 1.1f; // 提升左右移动速度
                break;
            default:
                Debug.Log("未知的Buff类型");
                break;
        }
    }

    // 向左移动
    public void MoveLeft()
    {
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    // 向右移动
    public void MoveRight()
    {
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    // 更新泡泡的位置（包括上升和左右移动）
    public void UpdatePosition(float deltaTime)
    {
        // 更新上升位置
        position = new Vector2(position.x, position.y + flowSpeed * deltaTime);
        transform.position = position;
    }

    private void Update()
    {
        HandleInput(); // 处理键盘输入
        UpdatePosition(Time.deltaTime);
    }
    // 处理键盘输入
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft(); // 按下A键或左箭头键向左移动
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight(); // 按下D键或右箭头键向右移动
        }
    }
}
