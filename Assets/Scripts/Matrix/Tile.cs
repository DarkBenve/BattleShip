using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace BattleShip
{
    public enum ObjectInTile
    {
        Water,
        PartOfShip,
        Ship
    }
    public class Tile: MonoBehaviour
    {
        public ManagerChooseOrderShip instanceManager;
        public ObjectInTile objectInTile;
        public MeshRenderer meshRenderer;
        public Ship ship;
        public bool isSelectedThisTile;
        public Color colorSelect;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            objectInTile = ObjectInTile.Water;
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            instanceManager = GameObject.Find("ManagerChoseOrder").GetComponent<ManagerChooseOrderShip>();
            meshRenderer.material.color = Color.cyan;
        }

        private void OnMouseEnter()
        {
            ChangeColor();
        }

        protected virtual void ChangeColor()
        {
            if (!isSelectedThisTile && SceneManager.GetActiveScene().name != "SceneBattle") {
                meshRenderer.material.color = instanceManager.shipSelected != null ? Color.green : Color.red;
            }else if (!isSelectedThisTile && SceneManager.GetActiveScene().name == "SceneBattle") {
                meshRenderer.material.color = Color.white;
            }
        }

        private void Update()
        {
            if (isSelectedThisTile) {
                meshRenderer.material.color = colorSelect;
            }
        }

        private void OnMouseExit()
        {
            meshRenderer.material.color = Color.cyan;
        }
    }
}
