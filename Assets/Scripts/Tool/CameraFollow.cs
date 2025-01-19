using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // 玩家泡泡对象
    public Transform topViewPoint; // 顶部视角
    public Transform bottomViewPoint; // 底部视角
    public float transitionDuration = 3f; // 动画过渡时间
    private float transitionTime = 0f; // 动画过渡计时器

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
        // 从顶部到达底部的过渡
        transitionTime += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
        transform.position = Vector3.Lerp(topViewPoint.position, bottomViewPoint.position, lerpFactor);

        if (lerpFactor >= 1f)
        {
            // 过渡完成，开始跟随玩家泡泡
            EndShowLevel();
        }
    }

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
