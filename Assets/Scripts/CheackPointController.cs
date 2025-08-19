using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackPointController : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkPoints;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform camera;
    private int activePoint = 0;
    public int ActiveCheackPoint => activePoint;

    private void Awake()
    {
        PlayerPrefs.SetInt("CheackPoint", 0);
        player.transform.position = checkPoints[activePoint].transform.position;
    }

    public void SpawnPlayer()
    {
        activePoint = PlayerPrefs.GetInt("CheackPoint", 0);
        player.transform.position = checkPoints[activePoint].transform.position;
    }

    public void ActivateNextCheckPoint(int numberCheackPoint)
    {
        if (numberCheackPoint != PlayerPrefs.GetInt("CheackPoint"))
        {
            activePoint = numberCheackPoint;

            PlayerPrefs.SetInt("CheackPoint", numberCheackPoint);
        }
    }

    public void TpCheackPoint(int numberCheackPoint)
    {
        player.transform.position = checkPoints[numberCheackPoint].transform.position;
    }

    public void ResetPoints()
    {
        PlayerPrefs.SetInt("CheackPoint", 0);
        activePoint = 0;
    }
}
