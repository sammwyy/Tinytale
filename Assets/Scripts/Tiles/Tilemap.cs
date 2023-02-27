using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class Tilemap
{
    public Tile[] tiles;

    private Dictionary<string, Tile> _tiles;

    public Tilemap()
    {
        this._tiles = new Dictionary<string, Tile>();
    }

    public Tile GetTile(string id)
    {
        Tile value;
        this._tiles.TryGetValue(id, out value);
        return value;
    }

    protected void CacheTiles()
    {
        foreach (Tile tile in tiles)
        {
            this._tiles.Add(tile.id, tile);
        }
    }

    public static Tilemap LoadFromFile(string filepath)
    {
        string raw = File.ReadAllText(filepath);
        Tilemap tilemap = JsonConvert.DeserializeObject<Tilemap>(raw);
        tilemap.CacheTiles();
        return tilemap;
    }
}