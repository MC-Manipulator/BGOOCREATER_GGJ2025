using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace
{
    /// <summary>
    /// 泡泡
    /// <para>通用，玩家和其他泡泡都使用这个类</para>
    /// </summary>
    public class Bubble : MonoBehaviour
    {
        // 事件
        /// <summary>
        /// 死亡事件，死亡时触发
        /// </summary>
        public event Action OnDie;

        // 属性
        /// <summary>
        /// 泡泡大小
        /// <para>值是面积，S=R^2</para>
        /// </summary>
        public float Size
        {
            get => size;
            set
            {
                size = value;
                transform.localScale = Vector3.one * Mathf.Sqrt(size);
            }
        }

        // 字段
        private float size;
        /// <summary>
        /// 是否在无敌时间内
        /// </summary>
        public bool isInvincible;

        // 消息

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.parent.TryGetComponent(out Bubble bubble))
            {
                if (Size > bubble.Size)
                {
                    Eat(bubble);
                }
            }
        }

        // 方法

        public void SetInvincibleTime(float time)
        {
            isInvincible = true;
            Invoke(nameof(BeNotInvincible), time);
        }
        public void BeNotInvincible()
        {
            isInvincible = false;
        }

        /// <summary>
        /// 吃掉泡泡
        /// </summary>
        public void Eat(Bubble bubble)
        {
            // 无敌时间内不能吃
            if (bubble.isInvincible)
                return;
            Size += bubble.Size;
            bubble.Die();
        }
        /// <summary>
        /// 死亡
        /// </summary>
        public void Die()
        {
            // 触发死亡事件
            OnDie?.Invoke();
        }
    }
}
