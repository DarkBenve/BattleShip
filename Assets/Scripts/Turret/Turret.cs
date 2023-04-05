using System;
using System.Collections;
using UnityEngine;

namespace BattleShip
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform spawnBullet;


        public IEnumerator ShootTurret(GameObject target)
        {
            Instantiate(bullet, spawnBullet);
            // instantiateBullet.MovePosition(target.transform.position);
            yield return new WaitForSeconds(10f);
        }
    }
}
