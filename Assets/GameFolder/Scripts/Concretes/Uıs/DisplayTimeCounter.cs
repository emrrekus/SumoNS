using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Managers;
using TMPro;
using UnityEngine;

namespace SumoNS.Uis
{
    public class DisplayTimeCounter : MonoBehaviour
    {
        private TMP_Text _timeCounterText;
        public float timeLeft;

        public int counter;
        private void Awake()
        {
            _timeCounterText = GetComponent<TMP_Text>();    
        }

        //Countdown timer in minutes and seconds on UI screen

        void Update() {
            timeLeft -= Time.deltaTime;
            
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);

            _timeCounterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            //If the countdown timer is 0, the time out screen is displayed.

            if (timeLeft < 0) {
                GameManager.Instance.TimeOut();
                timeLeft = 60;
            }
        }
    }
}
