using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WorldTile : MonoBehaviour
{
    private Tile _tile;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;

    public void SetPosition(int x, int y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        this.transform.position = pos;
    }

    public void SetLayer(int layer)
    {
        this._renderer.sortingOrder = layer;
    }

    public void SetTile(Tile tile)
    {
        this._tile = tile;
        this._renderer.sprite = tile.ToSprite();
        this._collider.enabled = tile.collision;
    }

    void Awake()
    {
        this._collider = this.GetComponent<BoxCollider2D>();
        this._renderer = this.GetComponent<SpriteRenderer>();
    }
}
