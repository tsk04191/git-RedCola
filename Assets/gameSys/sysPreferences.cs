using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sysPreferences
{
    public sysPreferencesPage _sysPreferencesPage { get; set; }
}

public class sysPreferencesPage
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }

    private sysLang[] _Lang;
    private sysPreferences _sysPreferences;

    private List<Image> img;
    private List<Canvas> cav;
    private Text txtScreenSize;

    private Image imgFullScreen;
    private Image imgButtonFullScreen;
    private Image imgButtonScreenDown;
    private Image imgButtonScreenUp;

    private Image imgButtonLangDown;
    private Image imgButtonLangUp;

    public sysPreferencesPage(GameObject g, sysLang[] l, List<Image> i, List<Canvas> c, Text t, Image full, Image icon, Image ds, Image us, Image dl, Image ul)
    {
        GM = g;

        _Lang = l;
        _sysPreferences = new sysPreferences();

        img = i;
        cav = c;
        txtScreenSize = t;

        imgFullScreen = icon;
        imgButtonFullScreen = full;
        imgButtonScreenDown = ds;
        imgButtonScreenUp = us;

        imgButtonLangDown = dl;
        imgButtonLangUp = ul;

        i[0].GetComponent<sysOnMousePointer>().Clicked = true;
    }

    public void SetButtonPreferencesPage()
    {
        img[0].GetComponent<Button>().onClick.AddListener(() => OnClickButtonPreferences(img[0], cav[0]));
        img[1].GetComponent<Button>().onClick.AddListener(() => OnClickButtonPreferences(img[1], cav[1]));
        img[2].GetComponent<Button>().onClick.AddListener(() => OnClickButtonPreferences(img[2], cav[2]));

        imgButtonFullScreen.GetComponent<Button>().onClick.AddListener(() => SetShiftFullScreen(imgFullScreen));
        imgButtonScreenDown.GetComponent<Button>().onClick.AddListener(() => SetScreenSize(false, ref gM().screenSelected));
        imgButtonScreenDown.GetComponent<Button>().onClick.AddListener(() => SetTextScreenSize(gM().screenSelected));
        imgButtonScreenUp.GetComponent<Button>().onClick.AddListener(() => SetScreenSize(true, ref gM().screenSelected));
        imgButtonScreenUp.GetComponent<Button>().onClick.AddListener(() => SetTextScreenSize(gM().screenSelected));

        imgButtonLangDown.GetComponent<Button>().onClick.AddListener(() => SetLang(_Lang, 0));
        imgButtonLangUp.GetComponent<Button>().onClick.AddListener(() => SetLang(_Lang, 1));

        SetImgFullScreen();
    }

    private void OnClickButtonPreferences(Image s, Canvas p)
    {
        ConPreferencesSelected(s);
        ConPreferencesPage(p);
    }

    private void ConPreferencesSelected(Image b)
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

    private void ConPreferencesPage(Canvas m)
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

    private void SetImgFullScreen()
    {
        imgFullScreen.gameObject.SetActive(Screen.fullScreen);
    }

    public void SetShiftFullScreen(Image i)
    {
        i.gameObject.SetActive(!Screen.fullScreen);
        Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
    }

    public void SetScreenSize(bool b, ref setScreen s)
    {
        int selected = ((int)s / 180);

        switch (b)
        {
            case true:
                if (selected != Enum.GetNames(typeof(setScreen)).Length + 1)
                {
                    selected++;
                }
                break;
            case false:
                if (selected != 2)
                {
                    selected--;
                }
                break;
        }
        int height = selected * 180;
        int width = height / 9 * 16;
        s = (setScreen)height;

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetTextScreenSize(setScreen e)
    {
        txtScreenSize.text = ((int)e / 9 * 16).ToString() + " * " + ((int)e).ToString();
    }

    public void SetLang(sysLang[] l, int b)
    {
        int selected = (int)gM().langSelected;

        switch (b)
        {
            case 0:
                if (selected != Enum.GetNames(typeof(setLang)).Length - 1)
                {
                    selected++;
                }
                break;
            case 1:
                if (selected != 0)
                {
                    selected--;
                }
                break;
        }

        gM().langSelected = (setLang)selected;

        foreach (sysLang t in l)
        {
            t.DoSet(gM().langSelected);
        }
    }
}
