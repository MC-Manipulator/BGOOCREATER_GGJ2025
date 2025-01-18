using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace
{
    /// <summary>
    /// 玩家移动
    /// <para>让泡泡受玩家操控</para>
    /// </summary>
    public class PlayerCtrl : MonoBehaviour
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

        /// <summary>
        /// 起点（重生点）
        /// </summary>
        private Vector3 startPoint;

        // 消息

        private void Start()
        {
            // 登记事件
            GetComponent<Bubble>().OnDie += Bubble_OnDie;
            startPoint = transform.position;
            Restart();
        }
        private void FixedUpdate()
        {
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

        /// <summary>
        /// 重新开始
        /// </summary>
        public void Restart()
        {
            transform.position = startPoint;
            Bubble b = GetComponent<Bubble>();
            b.Size = 4;
            b.SetInvincibleTime(8);
        }
        private void Bubble_OnDie()
        {
            Debug.Log("你死了！");
            Restart();
        }
    }
}