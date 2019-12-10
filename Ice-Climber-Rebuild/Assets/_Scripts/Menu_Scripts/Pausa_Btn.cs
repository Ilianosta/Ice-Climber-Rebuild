using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa_Btn : MonoBehaviour
{
    public bool isPaused = false;
    public void Pausar()
    {
        isPaused = true;
        if (isPaused)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
    public void Renaudar()
    {
        isPaused = false;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
