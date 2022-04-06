using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrows : MonoBehaviour
{
    [SerializeField]
    private Transform HourArrow, MinutesArrow, SecundesArrow;
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;
    private Clock _clock;
    private int hour = 0, minute = 0, secunde = 0;

    private void Start()
    {
        _clock = GameObject.FindObjectOfType<Clock>();
        HourArrow.localRotation = Quaternion.Euler(0f, 0f, _clock.Hour * -hoursToDegrees);
        MinutesArrow.localRotation = Quaternion.Euler(0f, 0f, _clock.Minutes * -minutesToDegrees);
        SecundesArrow.localRotation = Quaternion.Euler(0f, 0f, _clock.Secundes * -secondsToDegrees);

        InvokeRepeating("TimeTic", 3600, 3600);
    }
    private void Update()
    {
        DateTime time = DateTime.Now;
        HourArrow.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        MinutesArrow.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        SecundesArrow.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
    public void TimeTic()
    {
        Debug.Log("Start TimeTic");
        _clock.Request();
        DateTime time = DateTime.Now;
        if (time.Hour > _clock.Hour || time.Hour < _clock.Hour)
        {
            hour = _clock.Hour;
            HourArrow.localRotation = Quaternion.Euler(0f, 0f, hour * -hoursToDegrees);
        }
        if (time.Minute > _clock.Minutes || time.Minute < _clock.Minutes)
        {
            minute = _clock.Minutes;
            MinutesArrow.localRotation = Quaternion.Euler(0f, 0f, minute * -minutesToDegrees);
        }
        if (time.Second > _clock.Secundes || time.Second < _clock.Secundes)
        {
            secunde = _clock.Secundes;
            SecundesArrow.localRotation = Quaternion.Euler(0f, 0f, secunde * -secondsToDegrees);
        }
        else
        {
            hour = time.Hour;
            minute = time.Minute;
            secunde = time.Second;
            HourArrow.localRotation = Quaternion.Euler(0f, 0f, hour * -hoursToDegrees);
            MinutesArrow.localRotation = Quaternion.Euler(0f, 0f, minute * -minutesToDegrees);
            SecundesArrow.localRotation = Quaternion.Euler(0f, 0f, secunde * -secondsToDegrees);
        }
    }
}
