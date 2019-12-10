using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Btn : MonoBehaviour
{
    public GameObject optMenu;
    bool isActive = false;

    public void Opciones()
    {
        isActive = !isActive;
        optMenu.SetActive(isActive);
        isActive = !isActive;
    }
}
