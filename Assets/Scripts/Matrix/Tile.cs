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
            spriteRenderer.color = instanceManager.shipSelected != null ? Color.green : Color.red;
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = Color.white;
        }
    }
}
