using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text textTimer;
    [SerializeField] private Health health;
    [SerializeField] private float timeMax;
    private float currenttime;
    private bool isCount = true;

    private void Start()
    {
        currenttime = timeMax;
    }
    private void Update()
    {
        if (isCount)
        {
            currenttime -= Time.deltaTime;

            int time = Mathf.RoundToInt(currenttime);
            textTimer.text = time.ToString();

            if (currenttime < 0)
            {
                isCount = false;
                health.GetDamage(100);
            }
        }  
    }
}
