using System;
using System.Collections;
using UnityEngine;

namespace BattleShip
{
    public class TileEnemy : Tile
    {
        private Turret _playerTurret;


        private void Start()
        {
            _playerTurret = GameObject.FindGameObjectWithTag("TurretPlayer").GetComponent<Turret>();
        }

        private IEnumerator OnMouseDown()
        {
            if (ManagerBattleSystem._isTurnPlayer) {
                if (!GameManager._instance.isSelected) {
                    if (!isSelectedThisTile) {
                        _playerTurret._onFire += TargetEnemy;
                        _playerTurret._onFire.Invoke();
                        GameManager._instance.isSelected = true;
                        yield return new WaitForSeconds(3);
                        //Qui Fare lo sparo della torretta
                        if (ship != null && objectInTile == ObjectInTile.Ship) {
                            _playerTurret.isTargetShip = true;
                            ship._shipData._health--;
                            objectInTile = ObjectInTile.Water;
                            meshRenderer.material.color = Color.green;
                            colorSelect = Color.green;
                            isSelectedThisTile = true;
                            ManagerBattleSystem._isTurnPlayer = true;
                            // yield return new WaitForSeconds(1);
                            GameManager._instance.isSelected = false;
                        }
                        if (ship != null && objectInTile == ObjectInTile.PartOfShip) {
                            _playerTurret.isTargetShip = true;
                            ship._shipData._health--;
                            objectInTile = ObjectInTile.Water;
                            meshRenderer.material.color = Color.green;
                            colorSelect = Color.green;
                            isSelectedThisTile = true;
                            ManagerBattleSystem._isTurnPlayer = true;
                            // yield return new WaitForSeconds(1);
                            GameManager._instance.isSelected = false;
                        }
                        if (ship == null && objectInTile == ObjectInTile.Water){
                            meshRenderer.material.color = Color.blue;
                            colorSelect = Color.blue;
                            isSelectedThisTile = true;
                            ManagerBattleSystem._isTurnPlayer = false;
                            ManagerBattleSystem._isTurnEnemy = true;
                            // yield return new WaitForSeconds(2);
                            GameManager._instance.isSelected = false;
                        }
                    }
                }
            }
        }

        private void TargetEnemy()
        {
            _playerTurret.pivot.LookAt(new Vector3(transform.position.x, _playerTurret.pivot.position.y, transform.position.z));
            StartCoroutine(OnFire());
        }
        private IEnumerator OnFire()
        {
            yield return new WaitForSeconds(1);
            Bullet bul = _playerTurret.bullet.GetComponent<Bullet>();
            bul.startPosition = _playerTurret.shootPoint.position;
            GameManager._instance.destinationShoot = transform;
            var bullet = Instantiate(_playerTurret.bullet, _playerTurret.shootPoint);
            bullet.transform.SetParent(null);
            _playerTurret._onFire = null;
        }
        protected override void Init()
        {
            objectInTile = ObjectInTile.Water;
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = Color.cyan;
        }

        protected override void ChangeColor()
        {
            meshRenderer.material.color = Color.white;
        }
    }
}
