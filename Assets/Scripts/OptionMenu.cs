using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionMenu : MonoBehaviour
{
    public static float sensitivity=100f;
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log("dgdf");
    }
     public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetSensitivity(float s)
    {
        sensitivity=s;
        Debug.Log(sensitivity);
    }
}
