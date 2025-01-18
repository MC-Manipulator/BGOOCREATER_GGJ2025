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
    private PlayerCtrl playerMove;  // ���� PlayerMove �ű�



    private void Start()
    {
        // ��ȡ PlayerMove �ű����
        playerMove = playerBubble.GetComponent<PlayerCtrl>();

    }

    private void LateUpdate()
    {
        if (!showingLevel)
            return;

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
                EndShowLevel();
                // ����������ݵ��ƶ�
                //playerMove.SetMovementEnabled(true);  // ����������ݵ��ƶ�
            }
        }
        /*
        else
        {
            // �����������
            Vector3 newPosition = playerBubble.position + offset;
            newPosition.z = -10; // ȷ�� Z ��̶�Ϊ -10
            transform.position = newPosition;
        }
        */
    }

    public bool showingLevel = false;

    public void StartShowLevel()
    {

        // ��ʼ��״̬������Ϊ�Ӷ�����ʼ
        transform.position = topViewPoint.position;
        showingLevel = true;

    }

    public void EndShowLevel()
    {
        showingLevel = false;
    }
}
