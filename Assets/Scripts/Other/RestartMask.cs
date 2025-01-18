using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMask : MonoBehaviour
{
    public void ResetPlayer()
    {
        LevelManager.instance.ResetPlayer();
    }

    public void EndRestart()
    {
        LevelManager.instance.EndRestart();
    }
}
