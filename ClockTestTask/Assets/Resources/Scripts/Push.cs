using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push : MonoBehaviour
{
    public GameObject pushPanel;
    public Text MainText, ContentText;

    public void SetPush(string mainText, string contentText)
    {
        pushPanel.SetActive(true);
        MainText.text = mainText;
        ContentText.text = contentText;
    }
}
