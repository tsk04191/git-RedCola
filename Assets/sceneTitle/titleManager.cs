using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class titleManager : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }

    private sysTitlePage _titlePage;

    [Header("button on mouse to reveal selected img")]
    public List<Image> imgButtonTitle;
    public List<Image> imgButtonPreferences;

    [Header("page in title scene")]
    public List<Canvas> cavPageTitle;
    public List<Canvas> cavPagePreferences;

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
    [SerializeField] private Image imgButtonClassic;

    [Header("language")]
    [SerializeField] private sysLang[] _titleLang;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");

        _titlePage = new sysTitlePage(imgButtonTitle, cavPageTitle);
    }

    private void Start()
    {
        _titlePage.SetButtonTitle();

        gM().LoadPreferences(_titleLang, imgButtonPreferences, cavPagePreferences, txtScreenSize, imgButtonFullScreen, imgFullScreen, imgButtonScreenSizeDown, imgButtonScreenSizeUp, imgButtonLangDown, imgButtonLangUp);
        gM().LoadLang(_titleLang);

        imgButtonClassic.GetComponent<Button>().onClick.AddListener(() => gM().DoOpenSecne(1));
    }
}

public class sysTitlePage
{
    private List<Image> img;
    private List<Canvas> cav;

    public sysTitlePage(List<Image> i, List<Canvas> c)
    {
        img = i;
        cav = c;
    }

    public void SetButtonTitle()
    {
        img[0].GetComponent<Button>().onClick.AddListener(() => OnClickButtonTitle(img[0], cav[0]));
        img[1].GetComponent<Button>().onClick.AddListener(() => OnClickButtonTitle(img[1], cav[1]));
        img[2].GetComponent<Button>().onClick.AddListener(() => OnClickButtonTitle(img[2], cav[2]));
        img[3].GetComponent<Button>().onClick.AddListener(() => OnClickButtonTitle(img[3], cav[3]));
    }

    private void OnClickButtonTitle(Image i, Canvas c)
    {
        ConTitleSelected(i);
        ConTitleCanvas(c);
    }

    private void ConTitleSelected(Image b)
    {
        foreach (Image i in img)
        {
            i.GetComponent<sysOnMousePointer>().Clicked = false;
            i.GetComponent<sysOnMousePointer>().SetSelected(false);

            if (i == b)
            {
                i.GetComponent<sysOnMousePointer>().Clicked = true;
                i.GetComponent<sysOnMousePointer>().SetSelected(true);
            }
        }
    }

    private void ConTitleCanvas(Canvas m)
    {
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
