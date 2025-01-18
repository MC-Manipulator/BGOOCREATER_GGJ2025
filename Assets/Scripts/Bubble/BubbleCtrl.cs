using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace
{
    /// <summary>
    /// 非玩家移动
    /// <para>轨迹有直线、S形等</para>
    /// </summary>
    public class BubbleCtrl : MonoBehaviour
    {
        // 属性

        /// <summary>
        /// 动态速度缩放比例
        /// </summary>
        public Vector2 VRate;
        /// <summary>
        /// 静态速度
        /// </summary>
        public Vector2 VStatic;
        /// <summary>
        /// 动态速度旋转速度
        /// </summary>
        public float RotateSpeed;
        /// <summary>
        /// 动态速度
        /// </summary>
        public Vector2 VDynamics;

        // 字段

        // 消息

        private void Start()
        {
            // 登记事件
            GetComponent<Bubble>().OnDie += Bubble_OnDie;
        }


        public void FixedUpdate()
        {
            /* 改变速度
                速度 = 动态速度 + 静态速度
                静态速度不变，一直向上
                动态速度大小不变，方向不停旋转
                （动态速度会乘上缩放比例）
            */
            VDynamics = VDynamics.Rotate(RotateSpeed * Time.fixedDeltaTime);
            Vector3 v = VStatic + VRate * VDynamics;
            transform.position += v * Time.fixedDeltaTime;
        }

        // 方法

        private void Bubble_OnDie()
        {
            Destroy(gameObject);
        }
    }
}
