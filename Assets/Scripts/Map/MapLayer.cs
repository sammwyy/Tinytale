using UnityEngine;

public class MapLayerItem
{
    public int x;
    public int y;
    public string tile;
    public string npc;

    public Tile GetTile()
    {
        string[] parts = this.tile.Split(":");
        string tilemapName = parts[0] + ":" + parts[1];
        string tileid = parts[2];

        Resource<Tilemap> tilemapRes = ResourceManager.Instance.GetTilemap(tilemapName);
        Tilemap tilemap = tilemapRes.get();

        Tile tile = tilemap.GetTile(tileid);
        return tile;
    }

    public bool IsNPC()
    {
        return this.npc != null;
    }
    public bool IsTile()
    {
        return this.tile != null;
    }
}

public class MapLayer
{
    public int id;
    public MapLayerItem[] content;
}