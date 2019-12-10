using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Btn : MonoBehaviour
{
    public Image musicBtn;
    public Sprite muteOn;
    public Sprite muteOff;
    public bool muteState = false;

    public void Mute()
    {
        muteState = !muteState;
    }
    public void MuteImage()
    {
        if (muteState)
        {
            musicBtn.sprite = muteOn;
        }
        else
        {
            musicBtn.sprite = muteOff;
        }        
    }
}
