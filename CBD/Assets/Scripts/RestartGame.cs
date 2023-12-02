using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{

    void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {

            SceneManager.LoadScene("Start", LoadSceneMode.Single);

        }
    }
}
