using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class unitScoBody : MonoBehaviour
{
    GameObject GM;
    gameManager gM() { return GM.GetComponent<gameManager>(); }

    [Header("unit info")]
    [SerializeField] private string strNameIndex;
    [SerializeField] private string strName;
    [SerializeField] private string strDescription;

    [Space(5f)]
    [SerializeField] private Sprite sprImg;

    [Header("unit stat")]
    [SerializeField] private int intCost;
    [SerializeField] private int intPower;

    [Space(5f)]
    [SerializeField] private sysLang[] _unitLang;

    private void Start()
    {
        GM = GameObject.Find("gameManager");

        SetLang(gM().langSelected);
    }

    public string DoGetName()
    {
        return strName;
    }

    public string DoGetDescription()
    {
        return strDescription;
    }

    public void SetLang(setLang e)
    {
        strName = _unitLang[0].DoGet(e);
        strDescription = _unitLang[1].DoGet(e);
    }
}
