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
    
    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SOUND_VOLUME_KEY = "SoundVolume";
    private const float DEFAULT_VOLUME = 1f; // Значение по умолчанию
    
    private float musicVolume;
    private float soundVolume;

    private void Start()
    {
        // Загружаем сохраненные значения громкости или используем значения по умолчанию
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, DEFAULT_VOLUME);
        soundVolume = PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, DEFAULT_VOLUME);
        
        // Устанавливаем значения слайдеров
        volumeAudioMusic.value = musicVolume;
        volumeAudioSound.value = soundVolume;
        
        // Применяем громкость к аудио микшерам
        ApplyMusicVolume(musicVolume);
        ApplySoundVolume(soundVolume);
    }

    public void SetVolumeMusic(float newVolume)
    {
        musicVolume = Mathf.Clamp01(newVolume);
        ApplyMusicVolume(musicVolume);
        
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, musicVolume);
        PlayerPrefs.Save();
    }
    
    public void SetVolumeSound(float newVolume)
    {
        soundVolume = Mathf.Clamp01(newVolume);
        ApplySoundVolume(soundVolume);
        
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, soundVolume);
        PlayerPrefs.Save();
    }
    
    private void ApplyMusicVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixerMusic.SetFloat("MusicVolume", -80f); // Полная тишина
        }
        else
        {
            audioMixerMusic.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        }
    }
    
    private void ApplySoundVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixerSound.SetFloat("SoundVolume", -80f);
        }
        else
        {
            audioMixerSound.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
        }
    }
}