using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundButton : MonoBehaviour
{
    [SerializeField] private int index;
    public void PlaySoundIndex()
    {
        SoundManager.singltonSound.PlaySongByIndex(index);
    }
}
