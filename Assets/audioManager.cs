using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class audioManager : MonoBehaviour
{
    [SerializeField] private GameObject objBGM;
    [SerializeField] private GameObject objSFX;
    private AudioSource BGM() { return objBGM.GetComponent<AudioSource>(); }
    private AudioSource SFX() { return objSFX.GetComponent<AudioSource>(); }

    [SerializeField] private List<AudioClip> SFXGroup;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("volSet") != 1)
        {
            SetPref();
        }
    }

    private void SetPref()
    {
        PlayerPrefs.SetInt("volSet", 1);
        PlayerPrefs.SetFloat("volMaster", 1);
        PlayerPrefs.SetFloat("volBGM", 1);
        PlayerPrefs.SetFloat("volSFX", 1);
    }

    public void DoPlayClicked(bool b)
    {
        switch (b)
        {
            case true:
                SFX().clip = SFXGroup[0];
                DoSetVolumeSFX(1.0f);
                break;
            case false:
                SFX().clip = SFXGroup[1];
                DoSetVolumeSFX(0.5f);
                break;
        }

        SFX().Play();
    }

    public void DoPlayBGM(AudioClip ac, float n)
    {
        BGM().clip = ac;
        DoSetVolumeBGM(n);
        BGM().Play();
    }

    public void DoSetVolumeMaster(float n)
    {
        DoSetVolumeBGM(n);
        DoSetVolumeSFX(n);
    }

    public void DoSetVolumeBGM(float n)
    {
        BGM().volume = n * PlayerPrefs.GetFloat("volMaster") * PlayerPrefs.GetFloat("volBGM");
    }

    public void DoSetVolumeSFX(float n)
    {
        SFX().volume = n * PlayerPrefs.GetFloat("volMaster") * PlayerPrefs.GetFloat("volSFX");
    }
}
