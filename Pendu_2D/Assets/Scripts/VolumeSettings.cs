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

        // Verifie si une cle de donnees existe deja
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
        // Recupere la derniere valeur sauvegardee du volume de la musique lorsque le joueur quitte le jeu
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        // Recupere la derniere valeur sauvegardee du volume des bruits lorsque le joueur quitte le jeu
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        // Charge la derniere valeur du volume de la musique lorsque le joueur retourne dans le jeu
        SetVolume(musicSlider.value, "VolumeMusic", "musicVolume");
        // Charge la derniere valeur du volume des bruits lorsque le joueur retourne dans le jeu
        SetVolume(SFXSlider.value, "VolumeSFX", "SFXVolume");
    }
}
