using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController _instance;
    public GameObject player;
    public GameObject playerCam;
    public GameObject pickaxe;
    private int focusLevel = 0; //a focus level of 0 means that the game is focused (i.e. no mouse shown, locked to center of screen)
    private void Start()
    {
        _instance = this;
        /*player = GameObject.Find("Player");
        playerCam = GameObject.Find("Player Cam");
        pickaxe = GameObject.Find("Pickaxe");*/
    }
    //Used to let the game know to show the mouse to the player
    public void IncrementFocusLevel()
    {

        if (focusLevel < 1)
            focusLevel = 1;
        player.GetComponent<MouseLook>().onQuiz = true;
        player.GetComponent<Move>().onQuiz = true;
        playerCam.GetComponent<MouseLook>().onQuiz = true;
        if (pickaxe.GetComponent<Pickaxe>())
        {
            pickaxe.GetComponent<Pickaxe>().onQuiz = true;
        }
        if (!isFocused())
        {
            Cursor.lockState = CursorLockMode.None; //show the cursor
            Cursor.visible = true;
        }
        else
        {
            //otherwise, hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    //once the player is done, resume game play by decrementing the focus level
    public void DecrementFocusLevel()
    {
        if (focusLevel > 0)
            focusLevel = 0;
        player.GetComponent<MouseLook>().onQuiz = false;
        player.GetComponent<Move>().onQuiz = false;
        playerCam.GetComponent<MouseLook>().onQuiz = false;
        if (pickaxe.GetComponent<Pickaxe>())
        {

            pickaxe.GetComponent<Pickaxe>().onQuiz = false;
        }
        if (!isFocused())
        {
            Cursor.lockState = CursorLockMode.None; //show the cursor
            Cursor.visible = true;
        }
        else
        {
            //otherwise, hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public bool isFocused()
    {
        return focusLevel == 0;
    }
    public int getFocusLevel()
    {
        return focusLevel;
    }
    private void Update()
    {
        //if we're not focused
        if (!isFocused())
        {
            Cursor.lockState = CursorLockMode.None; //show the cursor
            Cursor.visible = true;
        }
        else
        {
            //otherwise, hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
