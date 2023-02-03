using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Points;
using SumoNS.ScriptableObjects;
using UnityEngine;

namespace SumoNS.Points
{
    public class Point : MonoBehaviour,IPoint
    {
        [SerializeField] private PointSO _pointInfo;

        private int _currentPoint;
        private void Awake()
        {
            _currentPoint = _pointInfo.CurrentPoint;
        }

        public void TakePoint(int point)
        {
            point += _currentPoint;
        }
    }
}
