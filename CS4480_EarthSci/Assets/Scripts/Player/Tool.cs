using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    //scene prefabs
    [SerializeField]
    protected GameObject toolModel;
    [SerializeField]
    protected GameObject toolMenu;

    //flags to differentiate different kinds of tools
    [SerializeField]
    protected bool hasModel = false;
    [SerializeField]
    protected bool hasMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //these enable/disable toggles don't seem to work yet
    void OnEnable()
    {
        //Debug.Log("enable");
        //if (hasModel) ToggleModel();
        //if (hasMenu) ToggleMenu();
    }

    void OnDisable()
    {
        //Debug.Log("disable");
        //if (hasModel) ToggleModel();
        //if (hasMenu) ToggleMenu();
    }

    void ToggleModel()
    {
        bool test = toolModel.activeInHierarchy;
        //Debug.Log("turning model " + test.ToString());
        toolModel.SetActive(toolModel.activeInHierarchy);
    }

    void ToggleMenu()
    {
        bool test = toolModel.activeInHierarchy;
        //Debug.Log("turning menu " + test.ToString());
        toolMenu.SetActive(toolMenu.activeInHierarchy);
    }

}
