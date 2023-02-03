using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Controllers;
using SumoNS.Points;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace SumoNS.Uis
{
    public class DisplayPoint : MonoBehaviour
    {
        private TMP_Text _PointText;

        private void Awake()
        {
            _PointText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            Point point = GetComponentInParent<Point>();
            point.OnTakePoint += HandleTakePoint;
        }

        private void HandleTakePoint(int obj)
        {
            _PointText.text = obj.ToString();
        }
    }
}
