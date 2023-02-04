using System;
using System.Collections;
using System.Collections.Generic;
using SumoNS.Abstracts.Utitiles;
using UnityEngine;

namespace SumoNS
{
    public class Buttons : SingletonMBObject<Buttons>
    {
        // Start is called before the first frame update
        private void Awake()
        {
            SingletonThisObject(this);
        }
    }
}
