using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum setLang
{
    Kr,
    En
}

[System.Serializable]
public class sysLang
{
    [SerializeField]
    string strName;
    [SerializeField]
    Text txtTarget;
    [SerializeField]
    string strKr;
    [SerializeField]
    string strEn;

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
}