using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
    GameObject scriptController;
    public static UIHandler instance;
    public Transform BagUI;
    public Transform Questions;
    public GameObject toolbar;
    private bool gameComplete = false;
    public int LastSceneIndex = 2;

    private void Start()
    {
        if (instance == null)
            instance = this;

        scriptController = GameObject.Find("ScriptController");
    }
    public void OpenQuestion(int type){
        OpenQuestion((Rock.RockType)type);
    }
    public void OpenQuestion(Rock.RockType rockType)
    {
        LeftArmController._instance.enableRock(rockType, true);
        switch ((int)rockType)
        {
            case 0:
                Question1();
                break;
            case 1:
                Question2();
                break;
            case 2:
                Question3();
                break;
            case 3:
                Question4();
                break;
            case 4:
                Question5();
                break;
            case 5:
                Question6();
                break;
            case 6:
                Question7();
                break;
        }
    }
    public void CollectRockGroup(Rock.RockType type)
    {
        BagUI.GetChild((int)type + 1).gameObject.SetActive(true);
    }
    public bool CheckIfMined(Rock.RockType type){
        return (BagUI.GetChild((int)type + 1).gameObject.activeSelf);
    }
    public bool CheckRockComplete(Rock.RockType type)
    {
        return Questions.GetChild(6 - (int)type).GetComponent<QuestionHandler>().isQuestionFullyAnswered();
    }
    public bool checkAllComplete(){
        foreach (int rock in Enum.GetValues(typeof(Rock.RockType))){
            if(!CheckRockComplete((Rock.RockType)rock)){
                return false;
            }
        }
        return true;
    }
    public void enableToolbar(bool enabled){
        toolbar.SetActive(enabled);
    }
    public void Question1()
    {
        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 1
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.SetActive(true);
        //activate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Question2()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 2
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(true);
        //actiivate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Question3()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 3
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(true);
        //activate metamorphic UI panel
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void Question4()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 4
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        //activate metamorphic UI panel
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void Question5()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 5
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        //activate igneous UI panel
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Question6()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 6
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //activate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Question7()
    {

        //activate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        //deactivate Toolbar.
        enableToolbar(false);
        scriptController.GetComponent<MouseController>().IncrementFocusLevel();

        //activate question 7
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //activate igneous UI panel
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void CancelQuestion1()
    {

        //deactivate question 1
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.SetActive(false);
        //deactivate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(true);

        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);

    }

    public void CancelQuestion2()
    {

        //deactivate question 2
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(false);
        //deactivate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CancelQuestion3()
    {

        //deactivate question 3
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(false);
        //deactivate metamorphic UI panel
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CancelQuestion4()
    {

        //deactivate question 4
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(false);
        //deactivate metamorphic UI panel
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(4).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CancelQuestion5()
    {

        //deactivate question 5
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //deactivate igneous UI panel
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(5).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CancelQuestion6()
    {

        //deactivate question 6
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        //deactivate sedimentary UI panel
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(6).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CancelQuestion7()
    {

        //deactivate question 7
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //deactivate igneous UI panel
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        //activate rock inside of bag
        gameObject.transform.GetChild(4).gameObject.transform.GetChild(7).gameObject.SetActive(true);
        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
        enableToolbar(true);
    }

    public void CloseBag()
    {

        //deactivate Bag UI.
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        enableToolbar(true);

        scriptController.GetComponent<MouseController>().DecrementFocusLevel();
    }
    public void Update(){
        if(checkAllComplete() && !gameComplete){
            MouseController._instance.IncrementFocusLevel();
            gameComplete = true;
            SceneManager.LoadScene(LastSceneIndex, LoadSceneMode.Single);
        }
    }

}