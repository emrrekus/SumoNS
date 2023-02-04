using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SumoNS.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Point Info",menuName = "Point Information/Create New",order = 51)]
    public class PointSO : ScriptableObject
    {
        //We keep dynamically scores of Players and Enemys

        [SerializeField] private int _currentPoint;

        public int CurrentPoint => _currentPoint;

    }
}
