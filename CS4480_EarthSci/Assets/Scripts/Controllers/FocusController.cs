using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FocusController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject focusGO;
    public GameObject unfocusedGO;
    public XRInteractorLineVisual lineVisual;
    private bool prevFocused = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prevFocused != MouseController._instance.isFocused()){
        focusGO.SetActive(MouseController._instance.isFocused());
        unfocusedGO.SetActive(!MouseController._instance.isFocused());
        lineVisual.enabled = !MouseController._instance.isFocused();
        prevFocused = MouseController._instance.isFocused();
        
        }
    }
}
