using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private MusicController musicController;
    [SerializeField] private AudioSource audioSource;

    private void UpdateCurrentClip()
    {
        audioSource.clip = musicController.CurrentClip;
        //audioSource.volume = musicValueChanged.VolumeAudio;
        audioSource.Play();
    }

    public void PlaySongByIndex(int index) // через индекс включать звук
    {
        musicController.SetSpecificClip(index);
        UpdateCurrentClip();
    }
    public void StopSongByIndex(int index)
    {
        if (audioSource.clip == musicController.GetClipByIndex(index))
        {
            audioSource.Stop();
        }
    }
}
