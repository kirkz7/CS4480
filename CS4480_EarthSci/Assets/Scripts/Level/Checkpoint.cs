using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Tooltip("The default colour when not selected")]
    public Color defaultColor;
    [Tooltip("The checkpoint's colour when hovered over")]
    public Color hoverColor;
    private Material mat;
    private void Start(){
        mat = GetComponent<MeshRenderer>().materials[0]; //material we are going to modify
    }
    void OnMouseOver()
    {
        mat.color = hoverColor;
    }
    void Update(){
        //transform.LookAt(Camera.main.transform); //so it always looks at the camera
    }

    void OnMouseExit()
    {
        mat.color = defaultColor;
    }
    void OnMouseDown()
    {
        CheckpointController._instance.SelectCheckpoint(this);
    }
}
