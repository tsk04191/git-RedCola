using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sysCreateData : MonoBehaviour
{
    private int charMax = 13;
    private GameObject TM;
    private titleManager tM() { return TM.GetComponent<titleManager>(); }

    [SerializeField] private TMP_InputField inpName;
    [SerializeField] private Canvas cavMain;
    [SerializeField] private Button btCheck;

    private void Awake()
    {
        TM = GameObject.Find("titleManager");

        if (PlayerPrefs.GetInt("playerSet") == 1)
        {
            gameObject.SetActive(false);
            cavMain.gameObject.SetActive(true);
            tM().DoLoadInfo();
        }
    }

    private void Start()
    {
        inpName.characterLimit = charMax;
        inpName.onValueChanged.AddListener(DoLimitChar);

        btCheck.onClick.AddListener(() => DoCheck());
    }

    private void DoLimitChar(string s)
    {
        if (s.Length > charMax)
        {
            inpName.text = s.Substring(0, charMax);
        }
    }

    private void DoCheck()
    {
        PlayerPrefs.SetInt("playerSet", 1);
        PlayerPrefs.SetString("playerName", inpName.text);
        PlayerPrefs.SetInt("playerLV", 0);

        gameObject.SetActive(false);
        cavMain.gameObject.SetActive(true);
        tM().DoLoadInfo();
    }
}
