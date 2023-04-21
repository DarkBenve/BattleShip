using System;
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
        [SerializeField] private SpriteRenderer textDebug;
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
        public Transform destinationShoot;
        public bool isSelected;

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
            textDebugShipHitEnemy.text = "Player1: \nNavi nemiche affondate = " + nShipDeathEnemy;
            textDebugShipHitPlayer.text = "Player2: \nNavi nemiche affondate = "+ nShipDeathPlayer;
            if (nShipDeathEnemy >= 9) {
                Debug.Log("You Win");
                panelEndGame.SetActive(true);
            }
            else if (nShipDeathPlayer >= 9) {
                Debug.Log("You Lose");
                panelEndGame.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            if (ManagerBattleSystem._isTurnEnemy) {
                if (nShipDeathEnemy < 10) {
                    textDebug.flipX = false;
                    StartCoroutine(ManagerBattleSystem.TurnEnemy());
                }
            }

            if (ManagerBattleSystem._isTurnPlayer) {
                StopCoroutine(ManagerBattleSystem.TurnEnemy());
                textDebug.flipX = true;
            }
        }

        private IEnumerator SetAnimationCamera()
        {
            _animator.SetTrigger("Start");
            yield return null;
        }
    }
}
