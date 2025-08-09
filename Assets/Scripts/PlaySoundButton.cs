using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundButton : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private int index;
    public void PlaySoundIndex()
    {
        soundManager.PlaySongByIndex(index);
    }
}
