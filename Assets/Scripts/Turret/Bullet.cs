using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private AnimationCurve heightCurve;
        [SerializeField] private GameObject destroyShip;
        [SerializeField] private GameObject destroyWater;
        private Turret _playerTurret;
        public Vector3 startPosition;
        private Vector3 _endPosition;

        private void Awake()
        {
            _endPosition = GameManager._instance.destinationShoot.position;
            _playerTurret = GameObject.FindGameObjectWithTag("TurretPlayer").GetComponent<Turret>();
        }

        private void Update()
        {
            StartCoroutine(Moving());
            StartCoroutine(DestroyBullet());
        }

        private IEnumerator Moving()
        {
            float t = 0, a;
            while(t < 2)
            {
                t += Time.deltaTime;
                a = t / 2;

                transform.position = Vector3.Lerp(startPosition, _endPosition, a);
                transform.position += Vector3.up * heightCurve.Evaluate(a);
                //transform.rotation = Quaternion.Lerp(startPosition, stepTargetRotation, a);

                yield return null;
            }

        }

        private void OnDestroy()
        {
            if (_playerTurret.isTargetShip) {
                Instantiate(destroyShip, transform.position, Quaternion.identity);
                _playerTurret.isTargetShip = false;
                return;
            }
            else {
                Instantiate(destroyWater, new Vector3(_endPosition.x, _endPosition.y + 0.25f, _endPosition.z), Quaternion.Euler(90, 0 ,0));
            }
        }

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2);
            StopCoroutine(Moving());
            DestroyImmediate(gameObject);
        }
    }
}
