using System;
using UnityEngine;
using UnityEngine.UI;

public class AnalogClockTimeInstall : MonoBehaviour
{
    [SerializeField]
    private Transform HourArrow, MinutesArrow;
    private int h = 0, m = 0;
    private int AnalogHour = 0, AnalogMinute = 0;
    public InputField YY, Month, DD;
    public GameObject BellPanel, AnalogPanel;

    private bool ClockOrMinute;
    [SerializeField]
    private Push _push;

    private void Update()
    {
        AnalogTime();
    }
    public void HourArrowView()
    {
        HourArrow.gameObject.SetActive(true);
        MinutesArrow.gameObject.SetActive(false);
        ClockOrMinute = true;
    }
    public void MinuteArrowView()
    {
        HourArrow.gameObject.SetActive(false);
        MinutesArrow.gameObject.SetActive(true);
        ClockOrMinute = false;
    }
    public void AnalogTime()
    {
        if(ClockOrMinute == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                HourArrow.localRotation = Quaternion.Euler(0f, 0f, -1 * h);
                h += 1;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                MinutesArrow.localRotation = Quaternion.Euler(0f, 0f, -1 * m);
                m += 1;
            }
        }
        
        if (h > 360)
        {
            h = 0;
        }
        if(m > 360)
        {
            m = 0;
        }
        AnalogMinute = m / 6;
        switch (h)
        {
            case int n when n <= 30 && n >= 60:
                AnalogHour = 1;
                break;
            case int n when n >= 61 && n <= 90:
                AnalogHour = 2;
                break;
            case int n when n >= 91 && n <= 120:
                AnalogHour = 3;
                break;
            case int n when n >= 121 && n <= 150:
                AnalogHour = 4;
                break;
            case int n when n >= 151 && n <= 180:
                AnalogHour = 5;
                break;
            case int n when n >= 181 && n <= 210:
                AnalogHour = 6;
                break;
            case int n when n >= 211 && n <= 240:
                AnalogHour = 7;
                break;
            case int n when n >= 241 && n <= 270:
                AnalogHour = 8;
                break;
            case int n when n >= 271 && n <= 300:
                AnalogHour = 9;
                break;
            case int n when n >= 301 && n <= 330:
                AnalogHour = 10;
                break;
            case int n when n >= 331 && n <= 360:
                AnalogHour = 11;
                break;
            case int n when n >= 361 && n <= 29:
                AnalogHour = 12;
                break;
        }
        
    }
    public void DataCheck()
    {
        int date = DateTime.Now.Year;
        if(Int32.Parse(DD.text)>30 || Int32.Parse(Month.text) > 12){
            DD.text = ""; Month.text = "";
            _push.SetPush("ERROR", "Дата установлена неверно");
        }
        if (Int32.Parse(YY.text) < date)
        {
            YY.text = "";
            _push.SetPush("ERROR", "Дата установлена неверно");
        }
    }
    public void SetAnalogTime()
    {
        DataCheck();
        PlayerPrefs.SetInt("HH", AnalogHour);
        PlayerPrefs.SetInt("MM", AnalogMinute);
        PlayerPrefs.SetInt("DD", Int32.Parse(DD.text));
        PlayerPrefs.SetInt("Month", Int32.Parse(Month.text));
        PlayerPrefs.SetInt("YY", Int32.Parse(YY.text));
        PlayerPrefs.SetInt("CheckTimer", 1);
        PlayerPrefs.Save();
        BellPanel.SetActive(true);
        AnalogPanel.SetActive(false);
    }
}
