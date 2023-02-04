using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SumoNS.Uis
{
    public class DisplayTimeCounter : MonoBehaviour
    {
        private TMP_Text _timeCounterText;
        public float timeLeft = 70.0f;

        private void Awake()
        {
            _timeCounterText = GetComponent<TMP_Text>();    
        }

        void Update() {
            timeLeft -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);

            _timeCounterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            

            if (timeLeft < 0) {
                Debug.Log("Time is up!");
            }
        }
    }
}
