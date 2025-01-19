using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // 玩家泡泡对象
    public Vector3 startOffset = new Vector3(0, 30, 0);
    public Vector3 offset = new Vector3(0, 2, -10); // 摄像头偏移量
    public Transform topViewPoint; // 顶部视角
    public Transform bottomViewPoint; // 底部视角
    public float transitionDuration = 3f; // 动画过渡时间
    private float transitionTime = 0f; // 动画过渡计时器
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

        // 从顶部到达底部的过渡
        transitionTime += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
        transform.position = Vector3.Lerp(topViewPoint.position + startOffset, bottomViewPoint.position, lerpFactor);

        currSize = Mathf.Lerp(currSize, targetSize, 0.6f * Time.fixedDeltaTime);
        Camera.orthographicSize = currSize;

        if (lerpFactor >= 1f)
        {
            // 过渡完成
            EndShowLevel();
        }
    }

    public bool showingLevel = false;

    public void StartShowLevel()
    {
        // 初始化状态，设置为从顶部开始
        transform.position = topViewPoint.position;
        showingLevel = true;
    }

    public void EndShowLevel()
    {
        showingLevel = false;
    }
}
