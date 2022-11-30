using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Tool
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && MouseController._instance.isFocused())
        {
            OpenBag(true);
        }
    }
    public void OpenBag(bool enabled)
    {
        if (enabled)
        {
            MouseController._instance.IncrementFocusLevel();
        }
        else
        {
            if (!MouseController._instance.isFocused())
            {
                MouseController._instance.DecrementFocusLevel();
            }
        }
        UIHandler.instance.enableToolbar(!enabled); //disable hotbar
        toolMenu.SetActive(enabled);
    }
    public void OnDisable()
    {
        if(transform.parent.gameObject.activeSelf){ //just.... trust me
        OpenBag(false);
        }
    }
}
