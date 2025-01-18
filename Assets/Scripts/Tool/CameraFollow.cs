using DefaultNameSpace;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // 玩家泡泡对象
    public Vector3 offset = new Vector3(0, 2, -10); // 摄像头偏移量
    public Transform topViewPoint; // 顶部视角
    public Transform bottomViewPoint; // 底部视角
    public float transitionDuration = 3f; // 动画过渡时间
    private bool isFollowing = false; // 是否开始跟随玩家泡泡
    private float transitionTime = 0f; // 动画过渡计时器
    private PlayerCtrl playerMove;  // 引用 PlayerMove 脚本



    private void Start()
    {
        // 获取 PlayerMove 脚本组件
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
            // 从顶部到达底部的过渡
            transitionTime += Time.deltaTime;
            float lerpFactor = Mathf.Clamp01(transitionTime / transitionDuration);
            transform.position = Vector3.Lerp(topViewPoint.position, bottomViewPoint.position, lerpFactor);

            if (lerpFactor >= 1f)
            {
                // 过渡完成，开始跟随玩家泡泡
                isFollowing = true;
                EndShowLevel();
                // 启动玩家泡泡的移动
                //playerMove.SetMovementEnabled(true);  // 启用玩家泡泡的移动
            }
        }
        /*
        else
        {
            // 跟随玩家泡泡
            Vector3 newPosition = playerBubble.position + offset;
            newPosition.z = -10; // 确保 Z 轴固定为 -10
            transform.position = newPosition;
        }
        */
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
