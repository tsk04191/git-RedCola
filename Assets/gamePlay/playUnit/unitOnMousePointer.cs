using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class unitOnMousePointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objDefault;
    private Sprite sprOnMouse;
    private Sprite sprOnClicked;
    public bool Clicked { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (objDefault!= null)
        {
            SetSelected(false);
        }
        SetSelected(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Clicked)
        {
            if (objDefault != null)
            {
                SetSelected(true);
            }
            SetSelected(false);
        }
    }

    public void SetSelected(bool b)
    {
        objDefault.SetActive(b);
    }
}
