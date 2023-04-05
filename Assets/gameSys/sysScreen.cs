using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum setScreen
{
    h0360 = 360,
    h0540 = 540,
    h0720 = 720,
    h0900 = 900,
    h1080 = 1080
}

public class sysScreen
{
    private bool isFullScreen;
    private int sizeWidth;
    private int sizeHeight;

    public void Load()
    {
        isFullScreen = Screen.fullScreen;
        sizeWidth = Screen.width;
        sizeHeight = Screen.height;
    }

    public int ToHeight()
    {
        return sizeHeight;
    }

    public void SetScreenSize(setScreen e)
    {
        Screen.SetResolution((int)e / 9 * 16, (int)e, Screen.fullScreen);
    }

    public void SetFullScreen(bool b)
    {
        Screen.SetResolution(Screen.width, Screen.height, b);
    }
}
