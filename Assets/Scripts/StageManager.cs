using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            GameManager.RequestChange(GameManager.SceneChangeType.Start);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            GameManager.RequestChange(GameManager.SceneChangeType.Retry);
        }

    }
}
