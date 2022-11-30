using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarUI : MonoBehaviour
{

    static ToolbarUI _instance;

    //do we need to check if _instance is null?
    public static ToolbarUI Instance { get { return _instance; } }

    public List<Transform> tools;

    List<GameObject> glowBorders;

    public Transform activeToolBacking;

    //can later use this value as some sort of enum?
    //0 = pick, 1 = acid test, 2 = bag, ....?
    //or, if all our tools inherit some base class, could just have a public list of tools attached to this or another class
    //int current_tool;

    //tool controller who has authority on what the current tool is
    [SerializeField]
    ToolController toolController;

    void Start()
    {
        //Debug.Log("started");
        //current_tool = 0;
        _instance = this;
        activeToolBacking.position = tools[0].position;
        glowBorders = new List<GameObject>();
        foreach (Transform t in tools)
        {
            for (int i = 0; i < t.childCount; i++)
            {
                Transform child = t.GetChild(i);
                if (child.tag == "UI Glow")
                {
                    glowBorders.Add(child.gameObject);
                }
            }
        }
    }

    void Update()
    {
        /*
        if (Input.GetButtonDown("CycleToolLeft"))
        {
            current_tool--;
            if (current_tool < 0) current_tool += tools.Count;
            Debug.Log(current_tool);
        }
        else if (Input.GetButtonDown("CycleToolRight"))
        {
            current_tool++;
            if (current_tool >= tools.Count) current_tool -= tools.Count;
            Debug.Log(current_tool);
        }*/

        activeToolBacking.position = tools[toolController.getCurrentTool()].position;

        //code to change tool in hand and in code goes here? or is it better separated into another class?

    }

    public void HighlightUsableTools(bool[] toolFlags)
    {
        int limit = Mathf.Min(tools.Count, toolFlags.Length);
        for (int i = 0; i < limit; i++)
        {
            glowBorders[i].SetActive(toolFlags[i]);
        }

    }

    public void RemoveHighlights()
    {
        foreach (GameObject border in glowBorders)
        {
            border.SetActive(false);
        }
    }

}
