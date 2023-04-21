using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BattleShip
{
    public class ManagerSelectionShip : MonoBehaviour
    {
        public static ManagerSelectionShip _instance;
        public Func<Ship, Ship> _onSelect;
        public List<Ship> shipList;

        [SerializeField] private GameObject panelSelectionShip;
        [SerializeField] private TextMeshProUGUI countSmallShipUI;
        [SerializeField] private TextMeshProUGUI countMediumShipUI;
        [SerializeField] private TextMeshProUGUI countBigShipUI;
        [SerializeField] private GameObject buttonOpenPanel;
        [SerializeField] private GameObject buttonSelectGoBattle;
        [SerializeField] private GameObject buttonRotateShip;
        [SerializeField] private Image previewShip;
        [SerializeField] private int sizeShipIndex;

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
            sizeShipIndex = 1;
        }

        private void Update()
        {
            previewShip.sprite = shipList[sizeShipIndex - 1].previewShip;

            countSmallShipUI.text = "StormBriger\n" + currentNSmallShip + "/" + NMaxSmallShip;
            countMediumShipUI.text = "Goliath\n" + currentNMediumShip + "/" + NMaxMediumShip;
            countBigShipUI.text = "Colossus\n" + currentNBigShip + "/" + NMaxBigShip;

            if (currentNSmallShip == NMaxSmallShip && currentNMediumShip == NMaxMediumShip && currentNBigShip == NMaxBigShip) {
                buttonSelectGoBattle.SetActive(true);
                isReadyGoBattle = true;
            }
        }

        #region OpenPanelSelectionAnimation

        public void OpenPanelSelection()
        {
            buttonOpenPanel.SetActive(false);
            Animator animator = panelSelectionShip.GetComponent<Animator>();
            animator.SetBool("IsOpen", true);
        }

        public void ClosePanelSelection()
        {
            StartCoroutine(ClosePanelAnimation());
        }

        private IEnumerator ClosePanelAnimation()
        {
            Animator animator = panelSelectionShip.GetComponent<Animator>();
            animator.SetBool("IsOpen", false);
            yield return new WaitForSeconds(0.8f);
            buttonOpenPanel.SetActive(true);
        }

        #endregion

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

        public void NextShip()
        {
            sizeShipIndex++;
            if (sizeShipIndex > shipList.Count) {
                sizeShipIndex = 1;
            }
        }

        public void PrevShip()
        {
            sizeShipIndex--;
            if (sizeShipIndex <= 0) {
                sizeShipIndex = 3;
            }
        }

        public void SelectShip()
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
