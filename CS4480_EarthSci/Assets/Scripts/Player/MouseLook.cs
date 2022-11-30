using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float lookSpeed = 3f;
    public Vector2 xRotMax = new Vector2(-20,20); //values to clamp x to
    public Vector2 yRotMax = new Vector2(-360, 360); //values to clamp y to
    public bool onQuiz = false;
    // Update is called once per frame
    void Update()
    {
        if (!onQuiz)
        {
            //Input
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            //Clamping
            rotation.y = Mathf.Clamp(rotation.y, yRotMax.x, yRotMax.y);
            rotation.x = Mathf.Clamp(rotation.x, xRotMax.x, xRotMax.y);


            transform.localRotation = Quaternion.Euler((Vector2)rotation * lookSpeed);
        }
    }
}