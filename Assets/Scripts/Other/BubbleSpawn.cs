using UnityEngine;
using UnityEngine.UIElements;

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

        [Header("生成设置")]
        [SerializeField]
        [Tooltip("生成时间间隔")]
        private float SpawnTime = 0.5f;
        [SerializeField]
        [Tooltip("单次生成个数")]
        private int SpawnCount = 1;

        [Header("泡泡属性设置")]
        [SerializeField]
        private float SizeMin = 1;
        [SerializeField]
        private float SizeMax = 4;
        [SerializeField]
        private float InvincibleTime = 0;
        [SerializeField]
        private float VStaticXMax = 0.5f;
        [SerializeField]
        private float VStaticYMin = 0.4f;
        [SerializeField]
        private float VStaticYMax = 3.5f;
        [SerializeField]
        private float VRateMin = 0;
        [SerializeField]
        private float VRateMax = 4;
        [SerializeField]
        private float RotateSpeedMin = 0.6f;
        [SerializeField]
        private float RotateSpeedMax = 8;

        private Vector2 PosMin;
        private Vector2 PosMax;
        private float time;

        // 消息

        private void Start()
        {
            PosMax = transform.localScale / 2;
            PosMin = -PosMax;
            PosMax += (Vector2)transform.position;
            PosMin += (Vector2)transform.position;
        }
        private void Update()
        {
            if (!(LevelManager.instance.state == LevelState.Game))
            {
                return;
            }

            time -= Time.deltaTime;
            if (time <= 0)
            {
                // 每过 SpawnTime 秒生成一次
                time = SpawnTime;

                // 一次生成 SpawnCount 个
                for (int i = 0; i < SpawnCount; i++)
                {
                    GenerateBubble();
                }
            }
        }

        // 方法

        /// <summary>
        /// 生成泡泡（不是玩家泡泡）
        /// </summary>
        public void GenerateBubble()
        {
            // 2 Pi
            const float Pi2 = Mathf.PI * 2;

            //限制泡泡不会在玩家摄像机视野内生成
            float x = Random.Range(PosMin.x, PosMax.x);
            float y = Random.Range(PosMin.y, PosMax.y);
            Vector2 position = new Vector3(x, y, 0);
            Vector3 viewportPosition = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(position);
            bool isInView = viewportPosition.x >= 0f && viewportPosition.x <= 1f &&
                   viewportPosition.y >= 0f && viewportPosition.y <= 1f;
            if (isInView)
            {
                return;
            }

            //限制泡泡不会生成在其他泡泡或者障碍物上
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, 0.1f);

            if (hitColliders.Length > 0)
            {
                // 找到了物体
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.tag == "Obstacle" || hitCollider.gameObject.tag == "Bubble")
                    {
                        return;
                    }
                }
            }

            GameObject go = ReInstantiate.Run(this.bubble, GameObject.Find("BubblePool").transform);
            go.transform.position = position;

            // 初始化 Bubble 各属性
            Bubble bubbleState = go.GetComponent<Bubble>();
            bubbleState.Size = Random.Range(SizeMin, SizeMax);
            bubbleState.SetInvincibleTime(InvincibleTime);

            // 初始化 BubbleCtrl 各属性
            BubbleCtrl bubble = go.GetComponent<BubbleCtrl>();

            bubble.RotateSpeed = Random.Range(RotateSpeedMin, RotateSpeedMax)
                * Random.value < 0.5f ? 1 : -1;

            float vStaticX = Random.Range(-VStaticXMax, VStaticXMax);
            float vStaticY = Random.Range(VStaticYMin, VStaticYMax);
            bubble.VStatic = new Vector2(vStaticX, vStaticY);
            bubble.VDynamics = new Vector2(1, 0).Rotate(Random.Range(0, Pi2));

            float vRate = Random.Range(VRateMin, VRateMax);
            bubble.VRate = new Vector2(vRate, 0).Rotate(Random.Range(0, Pi2));
        }

    }
}
