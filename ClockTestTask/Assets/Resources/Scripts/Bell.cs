using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Bell : MonoBehaviour
{
    [SerializeField]
    private Transform HourArrow, MinutesArrow;
    [SerializeField]
    private Sprite BellOn, BellOff;
    [SerializeField]
    private Image BellImage;
    [SerializeField]
    private Button BellButton;
    public GameObject BellPanel;

    public InputField HH, MM, YY, Month, DD;
    private int Day = 0, Year = 0, Hour = 0, Minute = 0, Second = 0;
    private int BellCheck = 0;

    [Header("Bell Types")]
    public GameObject AnalogPanel;
    public GameObject DigitalPanel;

    [Header("Current Bell info")]
    public GameObject CurrentBell;
    public Text CurrentBellText, TopicText;

    public Push _push;
    [SerializeField]
    private NoManager _noManager;
    public AudioSource BellSound;

    private void Start()
    {
        
        BellCheck = PlayerPrefs.GetInt("CheckTimer");
        if (BellCheck == 1)
            InstallBell();
    }
    private void Update()
    {
        BellOnOrOff();
    }
    public void BellPress()
    {
            BellPanel.SetActive(true);
    }
    public void AnalogChoose()
    {
        BellCheck = PlayerPrefs.GetInt("CheckTimer");
        if (BellCheck == 0)
        {
            BellPanel.SetActive(false);
            AnalogPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Bell is current active");
            _push.SetPush("ERROR", "Будильник уже установлен");
        }
    }
    public void DigitalChoose()
    {
        BellCheck = PlayerPrefs.GetInt("CheckTimer");
        if (BellCheck == 0)
        {
            BellPanel.SetActive(false);
            DigitalPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Bell is current active");
            _push.SetPush("ERROR", "Будильник уже установлен");
        }

    }

    public void SetDigitalTime()
    {

        PlayerPrefs.SetInt("HH", Int32.Parse(HH.text));
        PlayerPrefs.SetInt("MM", Int32.Parse(MM.text));

        PlayerPrefs.SetInt("DD", Int32.Parse(DD.text));
        PlayerPrefs.SetInt("Month", Int32.Parse(Month.text));
        PlayerPrefs.SetInt("YY", Int32.Parse(YY.text));
        PlayerPrefs.SetInt("CheckTimer", 1);
        PlayerPrefs.Save();
        BellPanel.SetActive(true);
        DigitalPanel.SetActive(false);
    }
    public void InstallBell()
    {
        CurrentBell.SetActive(true);
        TopicText.gameObject.SetActive(true);
        int month = PlayerPrefs.GetInt("Month");
        Hour = PlayerPrefs.GetInt("HH");
        Minute = PlayerPrefs.GetInt("MM");
        Day = PlayerPrefs.GetInt("DD"); 
        Year = PlayerPrefs.GetInt("YY");
        string monthText = "";
        switch (month)
        {
            case 1:
                    monthText = "Января";
                    break;
            case 2:
                monthText = "Февраля";
                break;
            case 3:
                monthText = "Марта";
                break;
            case 4:
                monthText = "Апреля";
                break;
            case 5:
                monthText = "Мая";
                break;
            case 6:
                monthText = "Июня";
                break;
            case 7:
                monthText = "Июля";
                break;
            case 8:
                monthText = "Августа";
                break;
            case 9:
                monthText = "Сентября";
                break;
            case 10:
                monthText = "Октября";
                break;
            case 11:
                monthText = "Ноября";
                break;
            case 12:
                monthText = "Декабря";
                break;
        }
        DateTime BellTime = new DateTime(Year,month,Day, Hour, Minute,Second);
        double BellTimeInSec = (BellTime - DateTime.Now).TotalSeconds;

        _noManager.BellStart("Будильник", "Пора просыпаться!", DateTime.Now.AddSeconds(BellTimeInSec));
        BellSound.PlayDelayed((float)BellTimeInSec);
        Invoke("ZeroTimer", (float)BellTimeInSec);
        
        CurrentBellText.text =  PlayerPrefs.GetInt("HH") +
                                ":" + PlayerPrefs.GetInt("MM") +
                                ":00\n" + 
                                PlayerPrefs.GetInt("DD") +
                                monthText + " " + PlayerPrefs.GetInt("YY");
    }
    public void DeleteBell()
    {
        CurrentBell.SetActive(false);
        TopicText.gameObject.SetActive(false);
        BellSound.Stop();
        PlayerPrefs.DeleteAll();
    }
    public void ZeroTimer()
    {
        BellPanel.SetActive(true);
        PlayerPrefs.SetInt("CheckTimer", 0);
    }
    public void BellOnOrOff()
    {
        int check = PlayerPrefs.GetInt("CheckTimer");
        switch (check)
        {
            case 0:
                BellImage.sprite = BellOff;
                break;
            case 1:
                BellImage.sprite = BellOn;
                break;
        }
    }
}
