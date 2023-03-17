using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        [SerializeField] private GameObject buttonSelectGoBattle;
        [SerializeField] private GameObject buttonRotateShip;

        public const int NMaxSmallShip = 4;
        public const int NMaxMediumShip = 3;
        public const int NMaxBigShip = 2;

        public int currentNSmallShip;
        public int currentNMediumShip;
        public int currentNBigShip;

        public bool isRotate;
        public bool isReadyGoBattle;
        private TextMeshProUGUI _textRotate;

        private void Start()
        {
            if (_instance == null) {
                _instance = this;
            }
            else {
                Destroy(this);
            }
            buttonSelectGoBattle.SetActive(false);
            isRotate = false;
            _textRotate = buttonRotateShip.GetComponentInChildren<TextMeshProUGUI>();
            _textRotate.text = "Rotate " + "Top";
            buttonRotateShip.SetActive(false);
        }

        private void Update()
        {
            countSmallShipUI.text = "Ship Small\n" + currentNSmallShip + "/" + NMaxSmallShip;
            countMediumShipUI.text = "Ship Medium\n" + currentNMediumShip + "/" + NMaxMediumShip;
            countBigShipUI.text = "Ship Big\n" + currentNBigShip + "/" + NMaxBigShip;

            if (currentNSmallShip == NMaxSmallShip && currentNMediumShip == NMaxMediumShip && currentNBigShip == NMaxBigShip) {
                buttonSelectGoBattle.SetActive(true);
                isReadyGoBattle = true;
            }
        }

        public void SelectGoBattleButton()
        {
            SceneManager.LoadScene("SceneBattle");
        }

        public void RotateShip()
        {
            if (isRotate) {
                _textRotate.text = "Rotate " + "Top";
                isRotate = false;
            }

            else {
                _textRotate.text = "Rotate " + "Right";
                isRotate = true;
            }
        }

        public void SelectShip(int sizeShipIndex)
        {
            foreach (Ship ship in shipList) {
                if (ship.sizeShip == sizeShipIndex) {
                    if (ship.sizeShip == 1) {
                        buttonRotateShip.SetActive(false);
                    }
                    else {
                        buttonRotateShip.SetActive(true);
                    }
                    _onSelect.Invoke(ship);
                }
            }
        }
    }
}
