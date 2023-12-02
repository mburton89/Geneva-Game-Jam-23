using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Update()
    {
        ChangeScene();
    }
    void ChangeScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            
            SceneManager.LoadScene("Room", LoadSceneMode.Single);

        }
    }
}
