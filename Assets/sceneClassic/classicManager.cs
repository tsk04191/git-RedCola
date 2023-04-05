using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class classicManager : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }

    [Header("language")]
    [SerializeField] public sysLang[] _classicLang;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");
        gameObject.GetComponent<sysMenu>()._sysLang = _classicLang;
    }

    private void Start()
    {
        gM().LoadLang(_classicLang);
    }
}
