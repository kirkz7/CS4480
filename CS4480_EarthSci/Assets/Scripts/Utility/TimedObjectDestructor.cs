using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    public float timeToDestroy;
    private float currTime = 0;
    void Update()
    {
        currTime += Time.deltaTime;
        if(currTime >= timeToDestroy){
            GameObject.Destroy(gameObject);
        }
    }
}
