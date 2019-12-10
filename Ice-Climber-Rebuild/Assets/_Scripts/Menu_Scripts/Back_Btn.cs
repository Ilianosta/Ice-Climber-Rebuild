using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Btn : MonoBehaviour
{
    public GameObject opcMenu;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = opcMenu.active;
    }
    public void Atras()
    {
        opcMenu.SetActive(!isActive);
    }
}
