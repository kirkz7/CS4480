using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayer : MonoBehaviour
{
    public Transform vrMenu;
    public Transform testMenu;
    private bool prevFocused = false;



    // Update is called once per frame
    void Update()
    {
        if(MouseController._instance.isFocused() != prevFocused){
            BindMenu(testMenu, !MouseController._instance.isFocused());
            prevFocused = MouseController._instance.isFocused();
        }

        /* bool triggerValue;
         if (leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)
         {
             Debug.Log("Menu button is pressed.");
         }*/

    }
    public void BindMenu(Transform menu, bool enabled)
    {
        menu.SetParent(vrMenu, true);
        menu.transform.localPosition = new Vector3(0, 0, 0);
        menu.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Vector3 worldPos = menu.position;
        menu.SetParent(null, true);
        menu.position = worldPos;
       // menu.parent = null;
        //menu.gameObject.SetActive(enabled);
    }
}
