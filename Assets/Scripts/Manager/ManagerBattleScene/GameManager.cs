﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private TextMeshProUGUI textDebugTurn;
        [SerializeField] private TextMeshProUGUI textDebugShipHitPlayer;
        [SerializeField] private TextMeshProUGUI textDebugShipHitEnemy;
        [SerializeField] private GameObject panelEndGame;
        public static GameManager _instance;
        public SaveMatrixBattle matrixPlayer;
        private readonly Vector3 _cameraConstraintPosition = new Vector3(-0.0659999996f,11.8400002f,-9.8760004f);
        private readonly Quaternion _cameraConstraintRotation = new Quaternion(64.154007f,0,0, 0);
        private Animator _animator;

        public int nShipDeathEnemy;
        public int nShipDeathPlayer;

        private void Awake()
        {
            _animator = GameObject.Find("Main Camera").GetComponent<Animator>();
            if (_instance == null) {
                _instance = this;
            }
            else {
                Destroy(this);
            }
            panelEndGame.SetActive(false);
            textDebugShipHitEnemy.text = "Player1: \nNavi nemiche affondate = " + nShipDeathEnemy;
            textDebugShipHitPlayer.text = "Player2: \nNavi nemiche affondate = "+ nShipDeathPlayer;
        }

        private void Start()
        {
            matrixPlayer = FindObjectOfType<SaveMatrixBattle>();
            mainCamera.transform.SetPositionAndRotation(_cameraConstraintPosition, _cameraConstraintRotation);
            StartCoroutine(SetAnimationCamera());
            ManagerBattleSystem._isTurnEnemy = true;
        }

        private void Update()
        {
            if (nShipDeathEnemy >= 10) {
                textDebugTurn.text = "Hai Vinto";
                panelEndGame.SetActive(true);
            }
            else if (nShipDeathPlayer >= 10) {
                textDebugTurn.text = "Hai Perso";
                panelEndGame.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            if (ManagerBattleSystem._isTurnEnemy) {
                if (nShipDeathEnemy < 10) {
                    textDebugTurn.text = "Is Turn of Enemy";
                    textDebugShipHitEnemy.text = "Player1: \nNavi nemiche affondate = " + nShipDeathEnemy;
                    StartCoroutine(ManagerBattleSystem.TurnEnemy());
                }
            }

            if (ManagerBattleSystem._isTurnPlayer) {
                textDebugTurn.text = "Is Turn of Player";
                textDebugShipHitPlayer.text = "Player2: \nNavi nemiche affondate = "+ nShipDeathPlayer;
            }
        }

        private IEnumerator SetAnimationCamera()
        {
            _animator.SetTrigger("Start");
            yield return null;
        }
    }
}
