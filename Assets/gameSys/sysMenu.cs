using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class sysMenu : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }

    private sysMenuPage _menuPage;
    [HideInInspector] public sysLang[] _sysLang;

    [SerializeField] private Image imgButtonMenu;
    [SerializeField] private Canvas cavButtonMenu;
    [SerializeField] private Canvas cavMenuPage;

    [Header("button on mouse to reveal selected text")]
    public List<Image> imgButtonMenuPage;
    public List<Image> imgButtonPreferences;

    [Header("page in scene")]
    public List<Canvas> cavPageMenuPage;
    public List<Canvas> cavPagePreferences;

    [Header("name in page")]
    public Text txtPageMenuNameDefualt;
    public List<Text> txtPageMenuName;

    [Header("preferances set")]
    [SerializeField] private Image imgFullScreen;
    [SerializeField] private Text txtScreenSize;

    [Space(5f)]
    [SerializeField] private Image imgButtonFullScreen;
    [SerializeField] private Image imgButtonScreenSizeDown;
    [SerializeField] private Image imgButtonScreenSizeUp;

    [Space(5f)]
    [SerializeField] private Image imgButtonLangDown;
    [SerializeField] private Image imgButtonLangUp;

    [Header("etc button")]
    [SerializeField] private Image[] imgButtonCancel;
    [SerializeField] private Image imgButtonReturnTitle;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");

        _menuPage = new sysMenuPage(imgButtonMenuPage, cavPageMenuPage, cavMenuPage);
    }

    private void Start()
    {
        _menuPage.SetButtonTitle();

        gM().LoadPreferences(_sysLang, imgButtonPreferences, cavPagePreferences, txtScreenSize, imgButtonFullScreen, imgFullScreen, imgButtonScreenSizeDown, imgButtonScreenSizeUp, imgButtonLangDown, imgButtonLangUp);
        gM().LoadLang(_sysLang);

        imgButtonReturnTitle.GetComponent<Button>().onClick.AddListener(() => gM().DoOpenSecne(0));
    }

    public void DoOpenMenuPage(bool i)
    {
        cavButtonMenu.gameObject.SetActive(!i);
        cavMenuPage.gameObject.SetActive(i);
    }

    public void OnClickBackReturn()
    {
        cavMenuPage.gameObject.SetActive(true);

        imgButtonPreferences[0].GetComponent<sysOnMousePointer>().Clicked = true;
        imgButtonPreferences[0].transform.GetChild(0).gameObject.SetActive(true);
        imgButtonPreferences[1].GetComponent<sysOnMousePointer>().Clicked = false;
        imgButtonPreferences[1].transform.GetChild(0).gameObject.SetActive(false);
        imgButtonPreferences[2].GetComponent<sysOnMousePointer>().Clicked = false;
        imgButtonPreferences[2].transform.GetChild(0).gameObject.SetActive(false);

        cavPagePreferences[0].gameObject.SetActive(true);
        cavPagePreferences[1].gameObject.SetActive(false);
        cavPagePreferences[2].gameObject.SetActive(false);

        cavPageMenuPage[0].gameObject.SetActive(false);
        
        txtPageMenuNameDefualt.gameObject.SetActive(true);

        foreach (Text t in txtPageMenuName)
        {
            t.gameObject.SetActive(false);
        }

        DoReturnMenuPage();
    }

    public void DoReturnMenuPage()
    {

        txtPageMenuNameDefualt.gameObject.SetActive(true);
        cavMenuPage.gameObject.SetActive(true);

        foreach (Image i in imgButtonCancel)
        {
            i.GetComponent<sysOnMousePointer>().Clicked = false;
            i.GetComponent<sysOnMousePointer>().SetSelected(false);
        }
        foreach (Text t in txtPageMenuName)
        {
            t.gameObject.SetActive(false);
        }
        foreach (Canvas c in cavPageMenuPage)
        {
            c.gameObject.SetActive(false);
        }
    }
}

public class sysMenuPage
{
    private List<Image> img;
    private List<Canvas> cav;
    private Canvas menu;

    public sysMenuPage(List<Image> i, List<Canvas> c, Canvas m)
    {
        img = i;
        cav = c;
        menu = m;
    }

    public void SetButtonTitle()
    {
        img[0].GetComponent<Button>().onClick.AddListener(() => OnClickButtonMenu(cav[0]));
        img[1].GetComponent<Button>().onClick.AddListener(() => OnClickButtonMenu(cav[1]));
        img[2].GetComponent<Button>().onClick.AddListener(() => OnClickButtonMenu(cav[2]));
        //img[3].GetComponent<Button>().onClick.AddListener(() => OnClickButtonMenu(cav[3]));
        //img[3].GetComponent<Button>().onClick.AddListener(() => OnClickButtonMenu(cav[3]));
    }

    private void OnClickButtonMenu(Canvas m)
    {
        menu.gameObject.SetActive(false);

        foreach (Canvas c in cav)
        {
            c.gameObject.SetActive(false);

            if (c == m)
            {
                c.gameObject.SetActive(true);
            }
        }
    }
}