using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class resetscript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            CheckPointManager.instance.Respawn(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
