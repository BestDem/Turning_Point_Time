using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private MovementController movementController;
    [SerializeField] private PlayerUpheaval playerUpheaval;
    [SerializeField] private CheackPointController cheackPoint;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health.SpawnPlayer();
            cheackPoint.SpawnPlayer();
            playerUpheaval.SpawnPlayerGravity();
        }

    }

    public void OnButtonRestart()
    {
        health.SpawnPlayer();
        movementController.SetCanMove(true);
        playerUpheaval.SpawnPlayerGravity();
        cheackPoint.SpawnPlayer();
    }
    public void OnButtonRestartLevel()
    {
        cheackPoint.ResetPoints();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnButtonNext()
    {
        cheackPoint.ResetPoints();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
