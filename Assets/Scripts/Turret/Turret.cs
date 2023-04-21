using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class Turret : MonoBehaviour
    {
        public GameObject bullet;
        public Transform shootPoint;
        public Transform pivot;
        public bool isTargetShip;
        public Action _onFire;
    }
}
