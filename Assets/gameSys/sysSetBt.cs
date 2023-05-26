using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Text.RegularExpressions;
using UnityEngine.Audio;

public class sysSetBt : MonoBehaviour
{
    private GameObject GM;
    private audioManager aM() { return GM.transform.Find("audioManager").GetComponent<audioManager>(); }
    private List<string> langList = new List<string>();

    [Header("Button Groups")]
    [SerializeField] private List<GameObject> imgBtScreenGroup;
    [SerializeField] private List<GameObject> imgBtSoundGroup;
    [SerializeField] private List<GameObject> imgBtLangGroup;
    [SerializeField] private List<GameObject> imgBtDataGroup;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");
    }

    private void Start()
    {
        DoAddBt();
        DoOpenScreenPage();

        setLangList();
    }

    private void DoAddBt()
    {
        //설정창의 각 페이지를 여는 기능 추가
        imgBtScreenGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenScreenPage());
        imgBtScreenGroup[0].GetComponent<Button>().onClick.AddListener(() => aM().DoPlayClicked(true));
        imgBtSoundGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenSoundPage());
        imgBtSoundGroup[0].GetComponent<Button>().onClick.AddListener(() => aM().DoPlayClicked(true));
        imgBtLangGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenLangPage());
        imgBtLangGroup[0].GetComponent<Button>().onClick.AddListener(() => aM().DoPlayClicked(true));
        imgBtDataGroup[0].GetComponent<Button>().onClick.AddListener(() => DoOpenDataPage());
        imgBtDataGroup[0].GetComponent<Button>().onClick.AddListener(() => aM().DoPlayClicked(true));

        //화면 설정창
        //전체화면 설정
        imgBtScreenGroup[1].GetComponent<Button>().onClick.AddListener(() => DoSwitchFullScreen(imgBtScreenGroup[1].transform.Find("imgBool").gameObject));
        //해상도 설정
        imgBtScreenGroup[2].transform.Find("imgMinus").GetComponent<Button>().onClick.AddListener(() => DoSwitchScreenSize(false));
        imgBtScreenGroup[2].transform.Find("imgPlus").GetComponent<Button>().onClick.AddListener(() => DoSwitchScreenSize(true));

        //음량 설정창
        imgBtSoundGroup[1].transform.Find("sldMaster").GetComponent<Slider>().onValueChanged.AddListener(DoSetMasterVol);
        imgBtSoundGroup[2].transform.Find("sldBGM").GetComponent<Slider>().onValueChanged.AddListener(DoSetBGMVol);
        imgBtSoundGroup[3].transform.Find("sldSFX").GetComponent<Slider>().onValueChanged.AddListener(DoSetSFXVol);
        //설정된 음량값 불러오기
        SetSldSoundPref();

        //언어 설정창
        //언어 설정
        imgBtLangGroup[1].transform.Find("imgMinus").GetComponent<Button>().onClick.AddListener(() => DoSwitchLang(false));
        imgBtLangGroup[1].transform.Find("imgPlus").GetComponent<Button>().onClick.AddListener(() => DoSwitchLang(true));

        //데이터 설정창
        //데이터 삭제
        imgBtDataGroup[1].GetComponent<Button>().onClick.AddListener(() => DoDeleteData());
    }

    private void DoOpenScreenPage()
    {
        conSetSelected(0);

        conScreenPage(true);
        conSoundPage(false);
        conLangPage(false);
        conDataPage(false);
    }

    private void DoOpenSoundPage()
    {
        conSetSelected(1);

        conScreenPage(false);
        conSoundPage(true);
        conLangPage(false);
        conDataPage(false);
    }

    private void DoOpenLangPage()
    {
        conSetSelected(2);

        conScreenPage(false);
        conSoundPage(false);
        conLangPage(true);
        conDataPage(false);
    }

    private void DoOpenDataPage()
    {
        conSetSelected(3);

        conScreenPage(false);
        conSoundPage(false);
        conLangPage(false);
        conDataPage(true);
    }

    private void conSetSelected(int i)
    {
        int x = 1020, y = 1020, z = 1020, w = 1020;

        //페이지 선택 버튼 위치 정렬 - 460 : 현제 선택, 480 : 선택되지 않음
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

    private void conSoundPage(bool b)
    {
        imgBtSoundGroup[1].SetActive(b);
        imgBtSoundGroup[2].SetActive(b);
        imgBtSoundGroup[3].SetActive(b);
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

        aM().DoPlayClicked(true);
    }

    private void DoSwitchScreenSize(bool b)
    {
        int w = 16, h = 9;
        int targetW = Screen.width, targetH = Screen.height;

        if (Screen.width > 640 && !b)
        {
            targetW = (Screen.width / w - 20) * w;
            targetH = (Screen.height / h - 20) * h;
            aM().DoPlayClicked(true);
        }
        else if (Screen.width < 1920 && b)
        {
            targetW = (Screen.width / w + 20) * w;
            targetH = (Screen.height / h + 20) * h;
            aM().DoPlayClicked(true);
        }
        else
        {
            aM().DoPlayClicked(false);
        }

        Screen.SetResolution(targetW, targetH, Screen.fullScreen);
        imgBtScreenGroup[2].transform.Find("txtSize").GetComponent<TextMeshProUGUI>().text = targetW + " * " + targetH;
    }

    private void DoDeleteData()
    {
        PlayerPrefs.DeleteAll();
        aM().DoPlayClicked(true);

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

            aM().DoPlayClicked(true);
        }
        else if (i != langList.Count - 1 && b)
        {
            i++;

            aM().DoPlayClicked(true);
        }
        else
        {
            aM().DoPlayClicked(false);
        }

        loadLang(langList[i]);
    }

    private string getLangCode()
    {
        string target = LocalizationSettings.SelectedLocale.ToString();

        string pattern = @"\(([^)]+)\)$"; // 괄호 안의 내용을 추출하는 정규식 패턴

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

    private void DoSetMasterVol(float v)
    {
        PlayerPrefs.SetFloat("volMaster", v);
        aM().DoSetVolumeMaster(v);
    }

    private void DoSetBGMVol(float v)
    {
        PlayerPrefs.SetFloat("volBGM", v);
        aM().DoSetVolumeBGM(v);
    }

    private void DoSetSFXVol(float v)
    {
        PlayerPrefs.SetFloat("volSFX", v);
    }

    private void SetSldSoundPref()
    {
        imgBtSoundGroup[1].transform.Find("sldMaster").GetComponent<Slider>().value = PlayerPrefs.GetFloat("volMaster");
        imgBtSoundGroup[2].transform.Find("sldBGM").GetComponent<Slider>().value = PlayerPrefs.GetFloat("volBGM");
        imgBtSoundGroup[3].transform.Find("sldSFX").GetComponent<Slider>().value = PlayerPrefs.GetFloat("volSFX");
    }
}
