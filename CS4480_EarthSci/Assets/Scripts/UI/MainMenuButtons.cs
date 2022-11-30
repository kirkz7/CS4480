using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    GameObject instructionsPanel;

    [SerializeField]
    GameObject settingsPanel;

    [SerializeField]
    GameObject creditsPanel;
    public int sceneToLoad = 1;

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ToggleInstructions()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeInHierarchy);
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }

    public void ToggleCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeInHierarchy);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
