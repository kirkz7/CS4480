using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRInput : MonoBehaviour
{
    public static VRInput _instance;
    private List<InputDevice> leftHandedDevices;
    private List<InputDevice> rightHandedDevices;
    private InputDevice leftHand;
    private InputDevice rightHand;
    private bool isMenuDown = false;
    private bool wasMenuUp = true;
    private bool isMenuTrigger = false;
    void Start()
    {
        _instance = this;
        leftHandedDevices = new List<InputDevice>();
        rightHandedDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandedDevices);
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandedDevices);
        leftHand = leftHandedDevices[0];
        rightHand = rightHandedDevices[0];
    }

    // Update is called once per frame
    void Update()
    {
        bool menuTriggerValue;
        leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out menuTriggerValue);
        isMenuDown = menuTriggerValue;
        if(isMenuDown){
            isMenuTrigger = wasMenuUp;
            wasMenuUp = false;
        }else{
            wasMenuUp = true;
        }
    }
    public bool IsMenuDown(){
        return isMenuDown;
    }
    public bool IsMenuTrigger(){
        return isMenuTrigger && isMenuDown;
    }
}
