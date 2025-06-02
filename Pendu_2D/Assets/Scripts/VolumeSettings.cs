using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    
    // Gestion de la musique et des bruitages de l'Audio Mixer avec sliders

    private void Start()
    {

        musicSlider.onValueChanged.AddListener((value) => SetVolume(value, "VolumeMusic", "musicVolume"));
        SFXSlider.onValueChanged.AddListener((value) => SetVolume(value, "VolumeSFX", "SFXVolume"));

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume(musicSlider.value, "VolumeMusic", "musicVolume");
            SetVolume(SFXSlider.value,"VolumeSFX", "SFXVolume");
        }
      
    }

    /* public void SetMusicVolume()
     
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("VolumeMusic", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("VolumeSFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    */

    public void SetVolume(float sliderValue, string mixerParameter, string playerPrefName)
    {
        float volume = sliderValue;
        myMixer.SetFloat(mixerParameter, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(playerPrefName, volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetVolume(musicSlider.value, "VolumeMusic", "musicVolume");
        SetVolume(SFXSlider.value, "VolumeSFX", "SFXVolume");
    }
}
