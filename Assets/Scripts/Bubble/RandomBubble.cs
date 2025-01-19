using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();

    void Awake()
    {
        if (spriteList.Count > 0)
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, spriteList.Count)];
        }
    }
}
