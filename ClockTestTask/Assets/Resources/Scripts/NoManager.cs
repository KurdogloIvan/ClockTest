using UnityEngine;

using System;
using Unity.Notifications.Android;

public class NoManager : MonoBehaviour
{
    [SerializeField]
    private Bell _bell;

    // Start is called before the first frame update
    void Start()
    {
        InitializeNotifications();
    }
    public void InitializeNotifications()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
    public void BellStart(String title, string text, DateTime deliveryTime)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = deliveryTime;

        AndroidNotificationCenter.SendNotification(notification, "channel_id");    
    }
/*    private void OnApplicationPause(bool pause)
    {
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotification notif = new AndroidNotification()
            {
                Title = "Будильник-", 
                Text = "Пора просыпаться!-",
                FireTime = System.DateTime.Now,
            };
        AndroidNotificationCenter.UpdateScheduledNotification(id, notif, "channel_id");
        }
        else if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Delivered)
        {
            AndroidNotificationCenter.CancelNotification(id);
        }
        else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Unknown)
        {
            AndroidNotification notif = new AndroidNotification()
            {
                Title = "Будильник-",
                Text = "Пора просыпаться!-",
                FireTime = System.DateTime.Now,
            };
           id = AndroidNotificationCenter.SendNotification(notif, "channel_id");
        }
    }*/
}
