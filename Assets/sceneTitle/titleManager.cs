using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class titleManager : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField] private List<Canvas> cavPageGroup;

    [Header("Button Groups")]
    [SerializeField] private List<Button> imgBtPlayGroup;
    [SerializeField] private List<Button> imgBtSetGroup;
    [SerializeField] private List<Button> imgBtShopGroup;
    [SerializeField] private List<Button> imgBtQuitGroup;

    [Header("Info Groups")]
    [SerializeField] private List<TextMeshProUGUI> txtInfoGroup;

    private void Start()
    {
        DoAddBt();
    }

    private void DoBtGroupOpen(Canvas c, bool b)
    {
        c.gameObject.SetActive(b);
    }

    private void DoQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void DoAddBt()
    {
        //���� ���� ������ ����
        imgBtPlayGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[1], true));
        imgBtPlayGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], false));

        //���� ���� ���������� �ڷΰ���
        imgBtPlayGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], true));
        imgBtPlayGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[1], false));

        //���� ������ ����
        imgBtSetGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[2], true));
        imgBtSetGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], false));

        //���� ���������� �ڷΰ���
        imgBtSetGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], true));
        imgBtSetGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[2], false));

        //���� ������ ����
        imgBtQuitGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[4], true));
        imgBtQuitGroup[0].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], false));

        //���� ����
        imgBtQuitGroup[2].onClick.AddListener(() => DoQuit());

        //���� ���������� �ڷΰ���
        imgBtQuitGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[0], true));
        imgBtQuitGroup[1].onClick.AddListener(() => DoBtGroupOpen(cavPageGroup[4], false));
    }

    public void DoLoadInfo()
    {
        txtInfoGroup[0].text = PlayerPrefs.GetInt("playerLV").ToString();
        txtInfoGroup[1].text = PlayerPrefs.GetString("playerName");
    }
}
