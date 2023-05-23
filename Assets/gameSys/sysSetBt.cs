using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Text.RegularExpressions;

public class sysSetBt : MonoBehaviour
{
    private List<string> langList = new List<string>();

    [Header("Button Groups")]
    [SerializeField] private List<GameObject> imgBtScreenGroup;
    [SerializeField] private List<GameObject> imgBtSoundGroup;
    [SerializeField] private List<GameObject> imgBtLangGroup;
    [SerializeField] private List<GameObject> imgBtDataGroup;

    private void Start()
    {
        DoAddBt();
        DoOpenScreenPage();

        setLangList();

    }

    private void DoAddBt()
    {
        //����â�� �� �������� ���� ��� �߰�
        imgBtScreenGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenScreenPage());
        imgBtSoundGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenSoundPage());
        imgBtLangGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenLangPage());
        imgBtDataGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenDataPage());

        //ȭ�� ����â
        //��üȭ�� ����
        imgBtScreenGroup[1].GetComponent<Button>().onClick.AddListener(() => DoSwitchFullScreen(imgBtScreenGroup[1].transform.Find("imgBool").gameObject));
        //�ػ� ����
        imgBtScreenGroup[2].transform.Find("imgMinus").GetComponent<Button>().onClick.AddListener(() => DoSwitchScreenSize(false));
        imgBtScreenGroup[2].transform.Find("imgPlus").GetComponent<Button>().onClick.AddListener(() => DoSwitchScreenSize(true));

        //��� ����â
        //��� ����
        imgBtLangGroup[1].transform.Find("imgMinus").GetComponent<Button>().onClick.AddListener(() => DoSwitchLang(false));
        imgBtLangGroup[1].transform.Find("imgPlus").GetComponent<Button>().onClick.AddListener(() => DoSwitchLang(true));

        //������ ����â
        //������ ����
        imgBtDataGroup[1].GetComponent<Button>().onClick.AddListener(() => DoDeleteData());
    }

    private void DoOpenScreenPage()
    {
        conSetSelected(0);

        conScreenPage(true);
        conLangPage(false);
        conDataPage(false);
    }

    private void DoOpenSoundPage()
    {
        conSetSelected(1);

        conScreenPage(false);
        conLangPage(false);
        conDataPage(false);
    }

    private void DoOpenLangPage()
    {
        conSetSelected(2);

        conScreenPage(false);
        conLangPage(true);
        conDataPage(false);
    }

    private void DoOpenDataPage()
    {
        conSetSelected(3);

        conScreenPage(false);
        conLangPage(false);
        conDataPage(true);
    }

    private void conSetSelected(int i)
    {
        int x = 1020, y = 1020, z = 1020, w = 1020;

        //������ ���� ��ư ��ġ ���� - 460 : ���� ����, 480 : ���õ��� ����
        switch (i)
        {
            case 0:
                x = 1000;
                break;
            case 1:
                y = 1000;
                break;
            case 2:
                z = 1000;
                break;
            case 3:
                w = 1000;
                break;
        }

        imgBtScreenGroup[0].transform.position = new Vector3(1340, x, 0);
        imgBtSoundGroup[0].transform.position = new Vector3(1500, y, 0);
        imgBtLangGroup[0].transform.position = new Vector3(1660, z, 0);
        imgBtDataGroup[0].transform.position = new Vector3(1820, w, 0);
    }

    private void conScreenPage(bool b)
    {
        imgBtScreenGroup[1].SetActive(b);
        imgBtScreenGroup[2].SetActive(b);

        imgBtScreenGroup[1].transform.Find("imgBool").gameObject.SetActive(Screen.fullScreen);
        imgBtScreenGroup[2].transform.Find("txtSize").GetComponent<TextMeshProUGUI>().text = Screen.width + " * " + Screen.height;
    }

    private void conLangPage(bool b)
    {
        imgBtLangGroup[1].SetActive(b);
    }

    private void conDataPage(bool b)
    {
        imgBtDataGroup[1].SetActive(b);
        imgBtDataGroup[2].SetActive(b);
        imgBtDataGroup[3].SetActive(b);

        imgBtDataGroup[2].GetComponent<TextMeshProUGUI>().text = Application.version;
    }

    private void DoSwitchFullScreen(GameObject g)
    {
        g.SetActive(!Screen.fullScreen);
        Screen.fullScreen = !Screen.fullScreen;
    }

    private void DoSwitchScreenSize(bool b)
    {
        int w = 16, h = 9;
        int targetW = Screen.width, targetH = Screen.height;

        if (Screen.width > 640 && !b)
        {
            targetW = (Screen.width / w - 20) * w;
            targetH = (Screen.height / h - 20) * h;
        }
        else if (Screen.width < 1920 && b)
        {
            targetW = (Screen.width / w + 20) * w;
            targetH = (Screen.height / h + 20) * h;
        }

        Screen.SetResolution(targetW, targetH, Screen.fullScreen);
        imgBtScreenGroup[2].transform.Find("txtSize").GetComponent<TextMeshProUGUI>().text = targetW + " * " + targetH;
    }

    private void DoDeleteData()
    {
        PlayerPrefs.DeleteAll();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void setLangList()
    {
        langList.Add("ko-KR");
        langList.Add("en-US");
    }

    private void DoSwitchLang(bool b)
    {
        int i = langList.IndexOf(getLangCode());

        if (i != 0 && !b)
        {
            i--;
        }
        else if (i != langList.Count - 1 && b)
        {
            i++;
        }

        loadLang(langList[i]);
    }

    private string getLangCode()
    {
        string target = LocalizationSettings.SelectedLocale.ToString();

        string pattern = @"\(([^)]+)\)$"; // ��ȣ ���� ������ �����ϴ� ���Խ� ����

        Match match = Regex.Match(target, pattern);

        string r = match.Groups[1].Value;

        return r;
    }

    private void loadLang(string c)
    {
        LocaleIdentifier code = new LocaleIdentifier(c);

        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if (anIdentifier == code)
            {
                LocalizationSettings.SelectedLocale = aLocale;
            }
        }
    }
}
