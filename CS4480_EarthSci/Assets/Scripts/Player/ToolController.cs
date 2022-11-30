using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] GameObject scriptController;
    [SerializeField] GameObject VisualTestUI;
    public List<GameObject> tools;

    List<Tool> toolScripts;

    GameObject currentTool;

    private int current_tool;

    public int getCurrentTool()
    {
        return current_tool;
    }

    void Start()
    {
        
        current_tool = 0;

        toolScripts = new List<Tool>();
        currentTool = tools[0];
        for (int i = 0; i < tools.Count; i++)
        {
            toolScripts.Add(tools[i].GetComponent<Tool>());
        }
        currentTool.SetActive(true);
        toolScripts[0].enabled = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("CycleToolLeft"))
        {


            //Debug.Log("turning model off thru tool controller script");
            tools[current_tool].SetActive(false);
            //toolScripts[current_tool].enabled = false;

            current_tool--;
            if (current_tool < 0) current_tool += tools.Count;

            tools[current_tool].SetActive(true);
            //toolScripts[current_tool].enabled = true;
            //Debug.Log("turning model on thru tool controller script");

            //If scrolling to bag tool
            /*if (tools[current_tool].layer == 11)
            {
                scriptController.GetComponent<MouseController>().IncrementFocusLevel();
                VisualTestUI.transform.GetChild(5).gameObject.SetActive(false);
            }*/

        }
        else if (Input.GetButtonDown("CycleToolRight"))
        {
            //if scrolling off of bag tool.

            //Debug.Log("turning model off thru tool controller script");
            tools[current_tool].SetActive(false);
            //toolScripts[current_tool].enabled = false;

            current_tool++;
            if (current_tool >= tools.Count) current_tool -= tools.Count;

            //Debug.Log("turning model on thru tool controller script");
            tools[current_tool].SetActive(true);
            //toolScripts[current_tool].enabled = true;

        }
    }
}
