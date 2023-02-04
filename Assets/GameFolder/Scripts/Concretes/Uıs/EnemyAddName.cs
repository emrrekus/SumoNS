using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SumoNS.Uis
{
    public class EnemyAddName : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        private TMP_Text nameText;

        void Start()
        {
            nameText = GetComponent<TMP_Text>();
            nameText.text = _gameObject.name;
        }
    }
}
