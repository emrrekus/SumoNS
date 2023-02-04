using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SumoNS.Uis
{
    public class DisplayTimeCounter : MonoBehaviour
    {
        public float timeLeft = 90.0f;
        private TMP_Text  text;

        void Start() {
            text.text = GetTimeString(timeLeft);
        }

        void Update() {
            timeLeft -= Time.deltaTime;
            text.text = GetTimeString(timeLeft);

            if (timeLeft < 0) {
                text.text = "00:00";
                Debug.Log("Time is up!");
            }
        }

        string GetTimeString(float time) {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }
}
