using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // ������ݶ���
    public Vector3 offset = new Vector3(0, 2, -10); // ����ͷƫ����

    private void LateUpdate()
    {
        if (playerBubble == null)
        {
            Debug.LogWarning("PlayerBubble is not assigned to CameraFollow.");
            return;
        }

        // ��������ͷλ�ã����̶� Z ��
        Vector3 newPosition = playerBubble.position + offset;
        newPosition.z = -10; // ȷ�� Z ��̶�Ϊ -10
        transform.position = newPosition;
    }
}
