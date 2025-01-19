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
        [SerializeField]
        private float RunShrink = 0.05f;

        public bool isRestrictMove = false;

        private Bubble bubble;

        public bool runShrinking = false;

        /// <summary>
        /// 起点（重生点）
        /// </summary>
        //private Vector3 startPoint;

        // 消息

        private void Start()
        {
            // 登记事件
            bubble = GetComponent<Bubble>();
            bubble.OnDie += Bubble_OnDie;
            //startPoint = transform.position;
            //Restart();
        }


        private void FixedUpdate()
        {
            if (isRestrictMove)
            {
                return;
            }

            Move();
        }

        // 方法

        /// <summary>
        /// 移动
        /// </summary>
        private void Move()
        {
            // 获取水平和垂直方向的输入值
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            if (inputX != 0 && inputY != 0)
            {
                // 移动会导致消耗加速
                // 可能数字要改
                if (runShrinking)
                {
                    bubble.Size -= (bubble.Size + 8) * RunShrink * Time.fixedDeltaTime;
                }
            }

            // 转换为目标速度
            Vector3 des = Vector3.zero;
            des.x = inputX * maxVx;
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

        /*
        public void Restart()
        {
            Bubble b = GetComponent<Bubble>();
            transform.position = startPoint;
            b.Size = 4;
            b.SetInvincibleTime(8);
        }
        */

        private void Bubble_OnDie()
        {
            Debug.Log("你死了！");
            //Restart();
        }

        public void RestrictMove()
        {
            isRestrictMove = true;
        }

        public void DerestrictMove()
        {
            isRestrictMove = false;
        }
    }
}
