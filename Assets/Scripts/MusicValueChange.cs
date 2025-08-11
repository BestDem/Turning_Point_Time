using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicValueChange : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerMusic;
    [SerializeField] private AudioMixer audioMixerSound;
    [SerializeField] private Slider volumeAudioMusic;
    [SerializeField] private Slider volumeAudioSound;
    private float musicVolume = 1f;
    private float soundVolume = 1f;

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        soundVolume = PlayerPrefs.GetFloat("SoundVolume");
        volumeAudioMusic.value = musicVolume;
        volumeAudioSound.value = soundVolume;
        audioMixerMusic.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixerMusic.SetFloat("SoundVolume", PlayerPrefs.GetFloat("SoundVolume"));
    }

    public void SetVolumeMusic(float newVolume)
    {
        musicVolume = Mathf.Clamp01(newVolume);
        audioMixerMusic.SetFloat("MusicVolume", Mathf.Log10(newVolume) * 20);

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
    public void SetVolumeSound(float newVolume)
    {
        soundVolume = Mathf.Clamp01(newVolume);
        audioMixerSound.SetFloat("SoundVolume", Mathf.Log10(newVolume) * 20);

        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}