// ����������
using UnityEngine;
using DefaultNameSpace;

public class ToolBubble : Bubble
{
    public float size { get; set; }
    public float speed { get; set; }
    public Vector2 position { get; set; }
    public string movementPattern; // "moving" �� "stationary"
    public float effectValue; // Buff �� Debuff ��Ч��ֵ

    private Vector2 movementDirection; // �ƶ�����

    private void Start()
    {
        // ��ʼ�����ݵĴ�С���ٶȡ�λ�õ�
        size = 1.0f;
        speed = 2.0f;
        position = transform.position;
        movementPattern = "moving"; // Ĭ��Ϊ�ƶ�
        movementDirection = new Vector2(1, 0); // Ĭ�������ƶ�
    }

    // �������ҵ���ײ
    public void CheckCollision(PlayerBubble player)
    {
        // �����������ײ��⣬����Ƿ��������ݷ�����ײ
        if (Vector2.Distance(position, player.position) < size + player.size)
        {
            TriggerEffect(player); // �����ײ���򴥷�Ч��
        }
    }

    // �������ײ�󴥷�Ч��
    public void TriggerEffect(PlayerBubble player)
    {
        // ���� effectValue Ӧ�� Buff �� Debuff
        player.ApplyBuff("enlarge"); // ������Ӧ����������Ч��
        Destroy(gameObject); // ��������
    }

    // �������ݵ�λ��
    public void UpdatePosition(float deltaTime)
    {
        if (movementPattern == "moving")
        {
            // �����ƶ�ģʽ��������λ��
            position += movementDirection * speed * deltaTime;
            transform.position = position;
        }
        // ����� stationary���Ͳ�����λ�ã�����ԭ��
    }

    private void Update()
    {
        UpdatePosition(Time.deltaTime); // ÿ֡����λ��
    }
}
