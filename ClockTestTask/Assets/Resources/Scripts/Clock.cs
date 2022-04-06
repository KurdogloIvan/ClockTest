using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using DefaultNamespase;
using System.Web;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] private string url, country, city;
    private string Time;


    public int Hour = 0;
    public int Minutes = 0;
    public int Secundes = 0;

    void Awake()
    {
        country = "Europe";
        city = "Moscow";
        url = "http://worldtimeapi.org/api/timezone/" + country + "/" + city;
        Request();

    }
    private void Update()
    {
        
    }
    public void Request()
    {
        StartCoroutine(SendRequest());
    }
    public IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);
        yield return request.SendWebRequest();
        string json = "{\"time\":" + request.downloadHandler.text + "}";
        Response responce = JsonUtility.FromJson<Response>(json);

        Time = responce.time.datetime;
        int tIndex = Time.IndexOf("T");
        Hour = Int32.Parse(Time.Substring(tIndex + 1, 2));
        Minutes = Int32.Parse(Time.Substring(tIndex + 4, 2));
        Secundes = Int32.Parse(Time.Substring(tIndex + 7, 2));
        Debug.Log("Hour: " + Hour + 
                    "Minutes: " + Minutes+ 
                    "Secundes: " + Secundes);
    }

    
}
