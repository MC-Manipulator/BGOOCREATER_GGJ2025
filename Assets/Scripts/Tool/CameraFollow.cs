using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // ������ݶ���
    public Vector3 startOffset = new Vector3(0, 30, 0);
    public Vector3 offset = new Vector3(0, 2, -10); // ����ͷƫ����
    public Transform topViewPoint; // �����ӽ�
    public Transform bottomViewPoint; // �ײ��ӽ�
    public float transitionDuration = 3f; // ��������ʱ��
    private float transitionTime = 0f; // �������ɼ�ʱ��
    public float initSize = 30;
    public float currSize = 30;
    public float targetSize = 10;


    private Camera Camera;

    private void Start()
    {
        Camera = GetComponent<Camera>();
        currSize = initSize;

        if (playerBubble == null)
        {
            Debug.LogWarning("PlayerBubble is not assigned to CameraFollow.");
            return;
        }
    }
    private void LateUpdate()
    {
        if (!showingLevel)
            return;

        // �Ӷ�������ײ��Ĺ���
        transitionTime += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
        transform.position = Vector3.Lerp(topViewPoint.position + startOffset, bottomViewPoint.position, lerpFactor);

        currSize = Mathf.Lerp(currSize, targetSize, 0.6f * Time.fixedDeltaTime);
        Camera.orthographicSize = currSize;

        if (lerpFactor >= 1f)
        {
            // �������
            EndShowLevel();
        }
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
