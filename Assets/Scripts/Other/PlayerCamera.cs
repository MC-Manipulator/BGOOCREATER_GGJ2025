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
        private float above = 0.6f;
        [SerializeField]
        private float speed = 3;

        private Camera Camera;

        // 消息

        private void Start()
        {
            Camera = GetComponent<Camera>();
        }
        private void FixedUpdate()
        {
            float curSize = Camera.orthographicSize;
            float targetSize = player.localScale.x + 4;
            Camera.orthographicSize = Mathf.Lerp(curSize, targetSize, Time.fixedDeltaTime);

            float y = above * curSize;
            Vector3 targetPos = player.position + new Vector3(0, y, -10);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }

        // 方法

    }
}
