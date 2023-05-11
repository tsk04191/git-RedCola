using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum gameState
{
    playing,
    pause
}

public enum setLang
{
    Kr,
    En
}


public class gameManager : MonoBehaviour
{
    private static gameManager selfcheck;

    private sysScreen _Screen;
    private sysPreferences _Preferences;

    public gameState game;
    public setLang langSelected;
    public setScreen screenSelected;

    public float gameTime { get; private set; }

    [SerializeField] private List<string> strScene;

    private void Awake()
    {
        if(selfcheck == null)
        {
            selfcheck = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadScreen();
        LoadPreferencesPref();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        switch (game)
        {
            case gameState.playing:
                gameTime = Time.deltaTime;
                break;
            case gameState.pause:
                gameTime = 0f;
                break;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("preferencesLang", (int)langSelected);
    }

    public void LoadPreferences(sysLang[] l, List<Image> img, List<Canvas> cav, Text t, Image f, Image i, Image ds, Image us, Image dl, Image ul)
    {
        _Preferences = new sysPreferences();
        _Preferences._sysPreferencesPage = new sysPreferencesPage(gameObject, l, img, cav, t, f, i, ds, us, dl, ul);

        SetPreferences();
        SetTextScreenSize();
    }

    private void SetPreferences()
    {
        _Preferences._sysPreferencesPage.SetButtonPreferencesPage();
    }

    private void LoadScreen()
    {
        _Screen = new sysScreen();
        _Screen.Load();
        screenSelected = (setScreen)_Screen.ToHeight();
    }

    private void SetTextScreenSize()
    {
        _Preferences._sysPreferencesPage.SetTextScreenSize(screenSelected);
    }

    public void LoadLang(sysLang[] l)
    {
        _Preferences._sysPreferencesPage.SetLang(l, -1);
    }

    public void DoOpenSecne(int i)
    {
        SceneManager.LoadScene(strScene[i]);
    }

    private void LoadPreferencesPref()
    {
        langSelected = (setLang)PlayerPrefs.GetInt("preferencesLang");
    }
}

public enum playerState
{
    inRoom,
    inPlayBattle,
    inPlayEvent
}