using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBubble; // 玩家泡泡对象
    public Vector3 offset = new Vector3(0, 2, -10); // 摄像头偏移量

    private void LateUpdate()
    {
        if (playerBubble == null)
        {
            Debug.LogWarning("PlayerBubble is not assigned to CameraFollow.");
            return;
        }

        // 设置摄像头位置，并固定 Z 轴
        Vector3 newPosition = playerBubble.position + offset;
        newPosition.z = -10; // 确保 Z 轴固定为 -10
        transform.position = newPosition;
    }
}
