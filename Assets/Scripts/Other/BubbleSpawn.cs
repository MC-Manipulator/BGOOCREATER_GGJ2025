using UnityEngine;

namespace DefaultNameSpace
{
    /// <summary>
    /// 泡泡生成器
    /// 禁用可停止生成
    /// <para>会不断生成泡泡</para>
    /// </summary>
    public class BubbleSpawn : MonoBehaviour
    {
        // 字段

        [SerializeField]
        private GameObject bubble;

        [Header("生成时间间隔")]
        [SerializeField]
        private float SpawnTime = 0.2f;

        [Header("泡泡属性")]
        [SerializeField]
        private float SizeMin = 1;
        [SerializeField]
        private float SizeMax = 10;
        [SerializeField]
        private float VStaticYMin = 0.5f;
        [SerializeField]
        private float VStaticYMax = 2;
        [SerializeField]
        private float VRateMin = 0;
        [SerializeField]
        private float VRateMax = 4;
        [SerializeField]
        private float RotateSpeedMin = 0.8f;
        [SerializeField]
        private float RotateSpeedMax = 6;

        private float time;

        // 消息

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
                time = SpawnTime;
        }

        // 方法

        /// <summary>
        /// 生成泡泡（不是玩家泡泡）
        /// </summary>
        public Bubble GenerateBubble()
        {
            // 2 Pi
            const float Pi2 = Mathf.PI * 2;

            GameObject go = Instantiate(this.bubble);


            // 初始化 BubbleCtrl 各属性
            BubbleCtrl bubble = go.GetComponent<BubbleCtrl>();

            bubble.RotateSpeed = Random.Range(RotateSpeedMin, RotateSpeedMax)
                * Random.value < 0.5f ? 1 : -1;

            float vStaticY = Random.Range(VStaticYMin, VStaticYMax);
            bubble.VStatic = new Vector2(0, vStaticY);
            bubble.VDynamics = new Vector2(1, 0).Rotate(Random.Range(0, Pi2));

            float vRate = Random.Range(VRateMin, VRateMax);
            bubble.VRate = new Vector2(vRate, 0).Rotate(Random.Range(0, Pi2));


            // 初始化 Bubble 各属性
            Bubble bubbleState = go.GetComponent<Bubble>();
            bubbleState.Size = Random.Range(SizeMin, SizeMax);
            return bubbleState;
        }

    }
}
