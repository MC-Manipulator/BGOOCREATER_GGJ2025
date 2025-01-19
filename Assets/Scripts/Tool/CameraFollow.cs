using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // ������ݶ���
    public Transform topViewPoint; // �����ӽ�
    public Transform bottomViewPoint; // �ײ��ӽ�
    public float transitionDuration = 3f; // ��������ʱ��
    private float transitionTime = 0f; // �������ɼ�ʱ��

    public bool showingLevel = false;

    private void Start()
    {
        if (playerBubble == null)
        {
            Debug.LogWarning("PlayerBubble is not assigned to CameraFollow.");
        }
    }
    private void LateUpdate()
    {
        // �Ӷ�������ײ��Ĺ���
        transitionTime += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
        transform.position = Vector3.Lerp(topViewPoint.position, bottomViewPoint.position, lerpFactor);

        if (lerpFactor >= 1f)
        {
            // ������ɣ���ʼ�����������
            EndShowLevel();
        }
    }

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
