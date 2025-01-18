using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // ������ݶ���
    public Vector3 offset = new Vector3(0, 2, -10); // ����ͷƫ����
    public Transform topViewPoint; // �����ӽ�
    public Transform bottomViewPoint; // �ײ��ӽ�
    public float transitionDuration = 3f; // ��������ʱ��
    private bool isFollowing = false; // �Ƿ�ʼ�����������
    private float transitionTime = 0f; // �������ɼ�ʱ��
    private PlayerMove playerMove;  // ���� PlayerMove �ű�

    private void Start()
    {
        // ��ȡ PlayerMove �ű����
        playerMove = playerBubble.GetComponent<PlayerMove>();

        // ��ʼ��״̬������Ϊ�Ӷ�����ʼ
        transform.position = topViewPoint.position;
    }

    private void LateUpdate()
    {
        if (playerBubble == null)
        {
            Debug.LogWarning("PlayerBubble is not assigned to CameraFollow.");
            return;
        }

        if (!isFollowing)
        {
            // �Ӷ�������ײ��Ĺ���
            transitionTime += Time.deltaTime;
            float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
            transform.position = Vector3.Lerp(topViewPoint.position, bottomViewPoint.position, lerpFactor);

            if (lerpFactor >= 1f)
            {
                // ������ɣ���ʼ�����������
                isFollowing = true;

                // ����������ݵ��ƶ�
                playerMove.SetMovementEnabled(true);  // ����������ݵ��ƶ�
            }
        }
        else
        {
            // �����������
            Vector3 newPosition = playerBubble.position + offset;
            newPosition.z = -10; // ȷ�� Z ��̶�Ϊ -10
            transform.position = newPosition;
        }
    }
}
