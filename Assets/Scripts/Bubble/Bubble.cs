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
        /// <para>太小会死亡</para>
        /// </summary>
        public float Size
        {
            get => size;
            set
            {
                size = value;
                if (size < 0.1f)
                {
                    Die();
                    return;
                }
                transform.localScale = Vector3.one * Mathf.Sqrt(size);
            }
        }

        public bool isDead = false;
        public bool isShrinking = false;

        // 字段
        private float size;
        /// <summary>
        /// 是否在无敌时间内
        /// </summary>
        public bool isInvincible;

        public GameObject playerEatSound;
        public GameObject playerDieSound;

        // 消息

        private void Start()
        {
            isDead = false;
            
            if (isShrinking)
            {
                InvokeRepeating(nameof(Shrink), 1, 0.1f);
            }
            else
            {
                CancelInvoke(nameof(Shrink));
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Obstacle")
            {
                Die();
                return;
            }

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
            if (time <= 0)
                return;
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
            if (gameObject.tag == "Player")
            {
                playerEatSound.GetComponent<AudioSource>().Play();
            }
            // 无敌时间内不能吃
            if (bubble.isInvincible || isDead)
                return;

            Size += bubble.Size;
            bubble.Die();
        }
        /// <summary>
        /// 死亡
        /// </summary>
        public void Die()
        {
            if (!isDead)
            {
                if (gameObject.tag == "Player")
                {
                    playerDieSound.GetComponent<AudioSource>().Play();
                }
                isDead = true;
                // 触发死亡事件
                OnDie?.Invoke();
            }
        }

        /// <summary>
        /// 随时间自动缩小
        /// </summary>
        public void Shrink()
        {
            Size -= Size * 0.002f + 0.01f;
        }
    }
}
