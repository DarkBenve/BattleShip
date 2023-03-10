using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class ManagerSelectionShip : MonoBehaviour
    {
        public static ManagerSelectionShip _instance;
        public Func<Ship, Ship> _onSelect;
        public List<Ship> shipList;

        [SerializeField] private TextMeshProUGUI countSmallShipUI;
        [SerializeField] private TextMeshProUGUI countMediumShipUI;
        [SerializeField] private TextMeshProUGUI countBigShipUI;

        public const int NMaxSmallShip = 4;
        public const int NMaxMediumShip = 3;
        public const int NMaxBigShip = 2;

        public int currentNSmallShip;
        public int currentNMediumShip;
        public int currentNBigShip;

        private void Start()
        {
            if (_instance == null) {
                _instance = this;
            }
            else {
                Destroy(this);
            }
        }

        private void Update()
        {
            countSmallShipUI.text = currentNSmallShip + "/" + NMaxSmallShip;
            countMediumShipUI.text = currentNMediumShip + "/" + NMaxMediumShip;
            countBigShipUI.text = currentNBigShip + "/" + NMaxBigShip;
        }

        public void SelectShip(int sizeShipIndex)
        {
            foreach (Ship ship in shipList) {
                if (ship.sizeShip == sizeShipIndex) {
                    _onSelect.Invoke(ship);
                }
            }
        }
    }
}
