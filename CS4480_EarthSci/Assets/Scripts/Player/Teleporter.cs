using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Teleporter : MonoBehaviour
{
    public XRInteractorLineVisual xrInteractorLineVisual;
    public TeleportationArea area;
    public XRRayInteractor xrRayInteractor;
    public LayerMask maskToSet;
    private LayerMask prevMask;
    // Start is called before the first frame update
    void OnEnable()
    {
        prevMask = xrRayInteractor.raycastMask;
        xrInteractorLineVisual.enabled = true;
        area.enabled = true;
        xrRayInteractor.raycastMask = maskToSet;
    }
    void OnDisable(){
        xrInteractorLineVisual.enabled = false;
        xrRayInteractor.raycastMask = prevMask;
        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
