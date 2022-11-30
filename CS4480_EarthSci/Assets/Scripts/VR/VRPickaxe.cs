using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPickaxe : RockMiner
{
    // Start is called before the first frame update
    Vector3 lastPos;
    public bool reset = true;
    void OnEnable()
    {
     lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
        if(velocity.magnitude > 5f && reset){
         canMine = true;
        }
        if(velocity.magnitude < 1.5f){
            reset = true;
            canMine = false;
        }
    }
    public override void Mine()
    {
        reset = false;
        canMine = false;
    }
}
