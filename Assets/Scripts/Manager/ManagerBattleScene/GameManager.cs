using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        public SaveMatrixBattle matrixPlayer;
        private readonly Vector3 _cameraConstraintPosition = new Vector3(-0.0659999996f,11.8400002f,-9.8760004f);
        private readonly Quaternion _cameraConstraintRotation = new Quaternion(64.154007f,0,0, 0);
        private Animator _animator;

        private void Awake()
        {
            _animator = GameObject.Find("Main Camera").GetComponent<Animator>();
        }

        private void Start()
        {
            matrixPlayer = FindObjectOfType<SaveMatrixBattle>();
            mainCamera.transform.SetPositionAndRotation(_cameraConstraintPosition, _cameraConstraintRotation);
            StartCoroutine(SetAnimationCamera());
        }

        private IEnumerator SetAnimationCamera()
        {
            yield return new WaitForSeconds(0.5f);
            _animator.SetTrigger("Start");
        }
    }
}
