using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Managers;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SumoNS.Uis
{
    public class DisplayPlayerCount : MonoBehaviour
    {
        private TMP_Text _PlayerCountText;

        private void Awake()
        {
            _PlayerCountText = GetComponent<TMP_Text>();
        }

        private void FixedUpdate()
        {
            // Gets the number of available players in the game from Enemy manager and transfers them to UI text
            _PlayerCountText.text = EnemyManager.Instance._enemyCount.ToString();
        }
    }
}