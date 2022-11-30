using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    public void Initialize(string notificationStr){
        text.text = notificationStr;
    }
    public void CompleteAnimation(){
        GameObject.Destroy(gameObject);
    }
}
