using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeControler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _minutes;
    [SerializeField] private TextMeshProUGUI _seconds;
    [SerializeField] private GameObject DefeatPanel;

    public float countdownDuration = 180f; 
    private float currentTime;


    private void Start()
    {
        currentTime = countdownDuration;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            TimerEnded();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        _minutes.text = minutes.ToString();
        _seconds.text = seconds.ToString();
    }

    private void TimerEnded()
    {

        DefeatPanel.SetActive(true);
    }
}
