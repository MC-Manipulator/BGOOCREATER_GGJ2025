using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace
{
    /// <summary>
    /// 相机
    /// <para>跟随玩家</para>
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        // 事件

        // 属性

        // 字段

        [SerializeField]
        private Transform player;
        [SerializeField]
        [Tooltip("相机中心在玩家上方的距离")]
        private float above;
        [SerializeField]
        private float speed;

        private Camera Camera;

        // 消息

        private void Start()
        {
            Camera = GetComponent<Camera>();
        }
        private void FixedUpdate()
        {
            Vector3 targetPos = player.position + new Vector3(0, above, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);

            float curSize = Camera.orthographicSize;
            float targetSize = player.localScale.x + 4;
            Camera.orthographicSize = Mathf.Lerp(curSize, targetSize, 0.6f * Time.fixedDeltaTime);
        }

        // 方法

    }
}
