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

        private int count;


        private void Awake()
        {
            _PlayerCountText = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _PlayerCountText.text = EnemyManager.Instance._enemyCount.ToString();

            count = EnemyManager.Instance._enemyCount;
            
            Debug.Log("Enemy Count"+count);


        }
    }
}