using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] protected AudioMixer _audioMixer;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Slider _sliderSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolumeMusic();
            SetVolumeSFX();
        }
    }
    public void SetVolumeSFX()
    {
        float volume = _sliderSFX.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetVolumeMusic()
    {
        float volume = _slider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume );
    }

    protected void LoadVolume()
    {
        _slider.value = PlayerPrefs.GetFloat("MusicVolume");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");

        SetVolumeMusic();
        SetVolumeSFX();
    }
}
