// ���������
using UnityEngine;

public class PlayerBubble : MonoBehaviour, Bubble
{
    public float size { get; set; }
    public float speed { get; set; }
    public Vector2 position { get; set; }
    public float flowSpeed; // �����ٶȣ��������ҿ���Ӱ�죩

    private void Start()
    {
        // ��ʼ�����ݵĴ�С���ٶȡ�λ�õ�
        size = 1.0f;
        speed = 2.0f;
        flowSpeed = 0.2f; // �̶��������ٶ�
        position = transform.position;
    }

    // Ӧ�� Buff Ч��
    public void ApplyBuff(string buffType)
    {
        switch (buffType)
        {
            case "enlarge":
                size *= 1.2f; // ��������
                break;
            case "speedUp":
                speed *= 1.1f; // ���������ƶ��ٶ�
                break;
            default:
                Debug.Log("δ֪��Buff����");
                break;
        }
    }

    // �����ƶ�
    public void MoveLeft()
    {
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    // �����ƶ�
    public void MoveRight()
    {
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    // �������ݵ�λ�ã����������������ƶ���
    public void UpdatePosition(float deltaTime)
    {
        // ��������λ��
        position = new Vector2(position.x, position.y + flowSpeed * deltaTime);
        transform.position = position;
    }

    private void Update()
    {
        HandleInput(); // �����������
        UpdatePosition(Time.deltaTime);
    }
    // �����������
    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft(); // ����A�������ͷ�������ƶ�
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight(); // ����D�����Ҽ�ͷ�������ƶ�
        }
    }
}
