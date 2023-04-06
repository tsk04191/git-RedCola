using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class sysLang
{
    [SerializeField] private string strName;
    [SerializeField] private Text txtTarget;
    [SerializeField] private string strKr;
    [SerializeField] private string strEn;

    public override string ToString()
    {
        return strName;
    }

    public void DoSet(setLang l)
    {
        switch (l)
        {
            case setLang.Kr:
                txtTarget.text = strKr;
                break;
            case setLang.En:
                txtTarget.text = strEn;
                break;
        }
    }

    public string DoGet(setLang l)
    {
        switch (l)
        {
            case setLang.Kr:
                return strKr;
            case setLang.En:
                return strEn;
            default:
                return null;
        }
    }
}