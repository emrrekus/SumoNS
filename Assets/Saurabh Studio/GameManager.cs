using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMBObject<GameManager>
{
    [Header("UI Panel Informations")] [SerializeField]
    GameObject[] _panels;


    private int _SceneIndex;

    private void Awake()
    {
        SingletonThisObject(this);
        _SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
   

    public void Win()
    {
        Time.timeScale = 0;
        PanelOpen(1);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        PanelOpen(2);
    }

    public void TimeOut()
    {
        Time.timeScale = 0;
        PanelOpen(3);
    }

    private void PanelOpen(int Index)
    {
        _panels[Index].SetActive(true);
    }
    private void PanelClose(int Index)
    {
        _panels[Index].SetActive(false);
    }

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