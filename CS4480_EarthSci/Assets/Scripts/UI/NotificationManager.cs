using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject notification;
    public static NotificationManager _instance;
    void Start()
    {
        _instance = this;
    }
    public void Notify(string notificationStr)
    {
        GameObject notify = GameObject.Instantiate(notification);
        notify.GetComponent<Notification>().Initialize(notificationStr);
        notify.transform.SetParent(transform, false);
    }
}
