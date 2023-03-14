using UnityEngine;

namespace BattleShip
{
    public class TileEnemy : Tile
    {
        protected override void Init()
        {
            objectInTile = ObjectInTile.Water;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        protected override void ChangeColor()
        {
            spriteRenderer.color = Color.blue;
        }
    }
}
