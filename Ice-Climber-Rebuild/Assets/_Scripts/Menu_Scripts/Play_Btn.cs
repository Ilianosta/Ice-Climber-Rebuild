using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_Btn : MonoBehaviour
{

    public void Play()
    {
        if (this.gameObject.CompareTag("In_GameUI"))
        {
            SceneManager.LoadScene("Main_Menu");
        } else if (this.gameObject.CompareTag("Off_GameUI"))
        {
            SceneManager.LoadScene("GameScene");

        }
    }
}
