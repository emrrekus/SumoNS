using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SumoNS
{
    public class GameManagers : SingletonMBObject<GameManagers>
    {
        [Header("UI Panel Informations")]
        [SerializeField] GameObject[] _panels;


        private int _SceneIndex;
        private void Awake()
        {
            _SceneIndex = SceneManager.GetActiveScene().buildIndex;
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
                
                    SceneManager.LoadScene(_SceneIndex);
                    Time.timeScale = 1;
                    break;
                
            }
            
            
        }
    }
}
