using UnityEngine;

public class Tile
{
    public string id;
    public string texture;
    public bool collision;

    public Resource<Texture2D> GetTexture2D()
    {
        return ResourceManager.Instance.GetTexture(this.texture);
    }

    public Sprite ToSprite()
    {
        Texture2D texture = ResourceManager.Instance.GetTexture(this.texture).get();
        texture.filterMode = FilterMode.Point;
        return IMG2Sprite.LoadNewSprite(texture, texture.width);
    }
}