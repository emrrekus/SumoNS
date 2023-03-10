using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Points;
using SumoNS.ScriptableObjects;
using UnityEngine;

namespace SumoNS.Points
{
    public class Point : MonoBehaviour, IPoint
    {
        
        [SerializeField] private PointSO _pointInfo;

        private int _currentPoint;

        public int CurrentPoint => _currentPoint;

        // The event we created to get our current score and show it in the UI
        public event System.Action<int> OnTakePoint;

        private void Awake()
        {
            //Scriptable objectten current pointe ulaşıyoruz
            _currentPoint = _pointInfo.CurrentPoint;
        }

        public void TakePoint(int point)
        {
            _currentPoint += point;
            OnTakePoint?.Invoke(_currentPoint);
        }
    }
}