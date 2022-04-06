using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitClock : MonoBehaviour
{
    [SerializeField]
    private Text HourText;
    private Clock _clock;
    // Start is called before the first frame update
    void Start()
    {
        _clock = GameObject.FindObjectOfType<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        HourText.text = _clock.Hour.ToString() + ":" +
                        _clock.Minutes.ToString() + ":" +
                        _clock.Secundes.ToString();
        
        HourText.text = DateTime.Now.ToString("hh:mm:ss");
    }
}
