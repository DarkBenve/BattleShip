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
            objectInTile = ObjectInTile.Water;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            instanceManager = GameObject.Find("ManagerChoseOrder").GetComponent<ManagerChooseOrderShip>();
        }

        private void OnMouseEnter()
        {
            spriteRenderer.color = instanceManager.shipSelected != null ? Color.green : Color.red;
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = Color.white;
        }
    }
}
