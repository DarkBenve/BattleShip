using System;
using UnityEngine;
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
        public SpriteRenderer spriteRenderer;
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
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            instanceManager = GameObject.Find("ManagerChoseOrder").GetComponent<ManagerChooseOrderShip>();
        }

        private void OnMouseEnter()
        {
            ChangeColor();
        }

        protected virtual void ChangeColor()
        {
            if (!isSelectedThisTile) {
                spriteRenderer.color = instanceManager.shipSelected != null ? Color.green : Color.red;
            }
        }

        private void Update()
        {
            if (isSelectedThisTile) {
                spriteRenderer.color = colorSelect;
            }
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = Color.white;
        }
    }
}
