using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : Tool
{
    public GameObject acid;
    public Transform dropPoint;
    public AudioSource drop;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            DropAcid();
        }
    }
    public void DropAcid(){
        drop.Play();
        GameObject go = GameObject.Instantiate(acid);
        go.transform.position = dropPoint.position;
    }
}
