using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject completedLevelUI;
    public void CompletedLevel()
    {
        completedLevelUI.SetActive(true);
    }
    void OnTriggerEnter2D()
    {
        CompletedLevel();
    }
}
