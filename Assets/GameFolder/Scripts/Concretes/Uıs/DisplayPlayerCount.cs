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
            _PlayerCountText.text = EnemyManager.Instance._enemyCount.ToString();
            
            if(EnemyManager.Instance._enemyCount<2)GameManager.Instance.Win();

        }
    }
}