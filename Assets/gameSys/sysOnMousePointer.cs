using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sysOnMousePointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objDefault;
    public bool Clicked { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (objDefault!= null)
        {
            objDefault.SetActive(false);
        }
        SetSelected(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Clicked)
        {
            if (objDefault != null)
            {
                objDefault.SetActive(true);
            }
            SetSelected(false);
        }
    }

    public void SetSelected(bool b)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(b);
    }
}
