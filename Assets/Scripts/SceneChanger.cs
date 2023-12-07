using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }

    }
}
