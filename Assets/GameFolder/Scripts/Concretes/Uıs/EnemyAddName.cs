using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Controllers;
using TMPro;
using UnityEngine;

namespace SumoNS.Uis
{
    public class EnemyAddName : MonoBehaviour
    {
        public GameObject _enemy;
        private TMP_Text nameText;

        private void Awake()
        {
           
            nameText = GetComponent<TMP_Text>();
            
        }

        private void Update()
        {
            nameText.text = _enemy.name;
        }
    }
}