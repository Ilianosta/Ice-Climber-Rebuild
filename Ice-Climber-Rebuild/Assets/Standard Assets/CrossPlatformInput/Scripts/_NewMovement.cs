using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class _NewMovement : MonoBehaviour
{
    public Canvas Padre;
    public float limitx,limity;
    Vector3 posInicial;
    Vector3 posini;
    void Start()
    {
        posInicial = this.transform.position;
    }

    public void Drag()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Padre.transform as RectTransform,Input.mousePosition,Padre.worldCamera, out pos);
        Vector3 newPos = Padre.transform.TransformPoint(pos) - posInicial;
        newPos.x = Mathf.Clamp(newPos.x, -limitx, limitx);
        newPos.y = Mathf.Clamp(newPos.y, -limity, limity);
        transform.localPosition = newPos;
    }

    public void Drop()
    {
        this.transform.position = posInicial;
    }
}
