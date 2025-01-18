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

        // 消息

        public void Update()
        {
            Vector3 target = player.position + new Vector3(0, above, -10);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }

        // 方法

    }
}
