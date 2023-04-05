using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sysExit : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Canvas cav;

    public void Exit(bool b)
    {
        switch (b)
        {
            case true:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
                break;
            case false:
                img.GetComponent<sysOnMousePointer>().Clicked = false;
                img.GetComponent<sysOnMousePointer>().SetSelected(false);
                gameObject.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);

                if (cav != null)
                {
                    cav.gameObject.SetActive(true);
                }

                gameObject.SetActive(false);
                break;
        }
    }
}
