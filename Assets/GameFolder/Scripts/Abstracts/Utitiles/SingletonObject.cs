using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SumoNS.Abstracts.Utitiles
{
    public abstract class SingletonMBObject<T> : MonoBehaviour where T:Component
    {
        public static T Instance { get; private set; }

        public void SingletonThisObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            
        }
    }
}
