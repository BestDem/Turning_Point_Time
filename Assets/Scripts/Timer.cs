using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image gas;
    [SerializeField] private Text textTimer;
    [SerializeField] private Health health;
    [SerializeField] private float timeMax;
    [SerializeField] private float timeToGas;
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

            if (currenttime < timeToGas)
            {
                float alpha = Mathf.Lerp(0.3f, 0f, currenttime / timeToGas);
                Color newColor = gas.color;
                newColor.a = alpha;
                gas.color = newColor;
            }
            if (currenttime < 0)
            {
                health.GetDamage(100);
                isCount = false;
            }
        }
    }

    public void TimerGo(bool canCount)
    {
        isCount = canCount;
    }

    public void ResetTimer()
    {
        currenttime = timeMax;
    }
}
