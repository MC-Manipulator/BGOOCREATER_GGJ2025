using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

namespace DefaultNameSpace
{
    /// <summary>
    /// 玩家移动
    /// <para>让泡泡受玩家操控</para>
    /// </summary>
    public class PlayerMove : MonoBehaviour
    {
        // 事件

        // 属性

        /// <summary>
        /// 速度
        /// </summary>
        public Vector3 Velocity { get; set; }

        // 字段

        [SerializeField]
        private float normalVy;
        [SerializeField]
        private float maxVy;
        [SerializeField]
        private float minVy;
        [SerializeField]
        private float maxVx;
        [SerializeField]
        private float vChangeSpeed;

        // 消息
        private bool canMove = false; // 控制是否可以移动

        void FixedUpdate()
        {
            if (!canMove)
                return;  // 如果不能移动，则跳过本次更新

            // 获取水平和垂直方向的输入值
            // 并转为目标速度
            Vector3 des = Vector3.zero;
            des.x = Input.GetAxisRaw("Horizontal") * maxVx;

            float inputY = Input.GetAxisRaw("Vertical");
            if (inputY == 0)
                des.y = normalVy;
            else if (inputY > 0)
                des.y = maxVy;
            else
                des.y = minVy;

            // 改变速度
            Velocity = Vector3.Lerp(Velocity, des, vChangeSpeed * Time.fixedDeltaTime);

            transform.position += Velocity * Time.fixedDeltaTime;
        }

        // 方法
        // 启用或禁用移动
        public void SetMovementEnabled(bool enabled)
        {
            canMove = enabled;
        }

    }
}
