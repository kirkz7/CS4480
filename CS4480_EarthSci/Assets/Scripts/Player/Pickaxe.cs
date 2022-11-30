using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : Tool
{
    GameObject playerCam;
    float zRot = 0f;
    public bool onQuiz = false;
    float reset = 0f;
    public static Dictionary<Rock.RockType, GameObject> dic;
    public GameObject rockChecker;
    void Start()
    {
        dic = new Dictionary<Rock.RockType, GameObject>();
        GameObject left_arm = GameObject.Find("Left-arm");
        Transform[] trs = left_arm.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == "cleaned1")
                dic[Rock.RockType.Group1] = t.gameObject;
            if (t.name == "cleaned2")
                dic[Rock.RockType.Group2] = t.gameObject;
            if (t.name == "cleaned3")
                dic[Rock.RockType.Group3] = t.gameObject;
            if (t.name == "cleaned4")
                dic[Rock.RockType.Group4] = t.gameObject;
            if (t.name == "cleaned5")
                dic[Rock.RockType.Group5] = t.gameObject;
            if (t.name == "cleaned6")
                dic[Rock.RockType.Group6] = t.gameObject;
            if (t.name == "cleaned7")
                dic[Rock.RockType.Group7] = t.gameObject;
        }

        hasModel = true;
        playerCam = GameObject.Find("Player Cam");
    }

    void Update()
    {
        float mineSpeed = 500f;
        if (Input.GetMouseButtonDown(0) && zRot <= 0f && reset <= 0f && !onQuiz)
        { 
            zRot = 90f;
            reset = 90f;
        }
        if (zRot > 0f)
        {
            toolModel.transform.Rotate(0f, 0f, 1f * Time.deltaTime * mineSpeed);
            zRot -= 1f * Time.deltaTime * mineSpeed;
         } 
        if(zRot <= 0f && reset == 90f)
        {
            RaycastHit hit;
            Vector3 target = playerCam.transform.forward;
            if (Physics.Raycast(transform.position, target, out hit, 10, LayerMask.GetMask("Rocks")))
            {
                
                Rock rock = hit.transform.GetComponent<Rock>();
                rock.Mine();
               // rock.OpenUI();
            }else{
                 if (Physics.Raycast(transform.position, target, out hit, 10)){
                     GameObject checker = GameObject.Instantiate(rockChecker);
                     checker.transform.position = hit.point;
                 }
            }
        }
        if (zRot <= 0f && reset > 0f)
        {
            toolModel.transform.Rotate(0f, 0f, -1f * Time.deltaTime * mineSpeed);
            reset -= 1f * Time.deltaTime * mineSpeed;
        }
    }
}
