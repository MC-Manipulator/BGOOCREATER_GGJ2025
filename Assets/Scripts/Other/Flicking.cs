using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicking : MonoBehaviour
{
    public float timer = 0f;
    private bool _resize = true;

    void Update()
    {
        if (_resize)
        {

            timer += Time.deltaTime;
            transform.localScale += Vector3.one * 1 * Time.deltaTime;
            if (timer >= 1f)
            {
                _resize = false;
            }
        }
        else
        {

            timer -= Time.deltaTime;
            transform.localScale -= Vector3.one * 1 * Time.deltaTime;

            if (timer <= 0f)
            {
                _resize = true;
            }
        }
    }
}
