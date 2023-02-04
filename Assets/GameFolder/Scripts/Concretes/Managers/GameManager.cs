using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMBObject<GameManager>
{
    [Header("UI Panel Informations")] [SerializeField]
    GameObject[] _panels;
   
    private void Awake()
    {
        SingletonThisObject(this);
        
    }


    // UI when you win
    public void Win()
    {
        Time.timeScale = 0;
        PanelOpen(1);
    }
    // UI when you lose

    public void Lose()
    {
        Time.timeScale = 0;
        PanelOpen(2);
    }
    //screen when time out
    public void TimeOut()
    {
        Time.timeScale = 0;
        PanelOpen(3);
    }

    //We open the panel with the index number from the parameter

    private void PanelOpen(int Index)
    {
        _panels[Index].SetActive(true);
    }
    //We close the panel with the index number from the parameter
    private void PanelClose(int Index)
    {
        _panels[Index].SetActive(false);
    }

    //We can do stop, restart, continue and exit operations according to UI Buttons.

    public void UIButton(string process)
    {
        switch (process)
        {
            case "Pause":
                PanelOpen(0);
                Time.timeScale = 0;
                break;
            case "continue":
                PanelClose(0);
                Time.timeScale = 1;
                break;
            case "try":
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
                break;
            case "exit":
                Application.Quit();
                break;
            case "yes":
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
                break;
            case "no":
                Application.Quit();
                break;
        }
    }
}