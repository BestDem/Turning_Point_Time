using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveTrigger : MonoBehaviour
{
    public UnityEvent triggerEnter;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject gameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            soundManager.PlaySongByIndex(2);
            gameObject.SetActive(true);
            triggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            gameObject.SetActive(false);
    }
}
