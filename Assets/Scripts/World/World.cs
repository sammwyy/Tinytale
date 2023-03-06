using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private Map _map;

    [SerializeField]
    private List<WorldTile> _tiles;
    [SerializeField]
    private GameObject _tilePrefab;

    public void Start()
    {
        this._tiles = new List<WorldTile>();
    }

    public void UnloadMap()
    {
        foreach (WorldTile tile in this._tiles)
        {
            Destroy(tile.gameObject);
        }

        this._tiles.Clear();
    }

    public void LoadMap(Map map)
    {
        this.UnloadMap();
        this._map = map;

        foreach (MapLayer layer in map.layers)
        {
            foreach (MapLayerItem item in layer.content)
            {
                if (item.IsTile())
                {
                    GameObject go = Instantiate(_tilePrefab);
                    go.transform.parent = this.transform;

                    WorldTile worldTile = go.GetComponent<WorldTile>();
                    worldTile.SetLayer(layer.id);
                    worldTile.SetPosition(item.x, item.y);
                    worldTile.SetTile(item.GetTile());

                    this._tiles.Add(worldTile);
                }
            }

        }
    }

    public void LoadMap(Resource<Map> map)
    {
        this.LoadMap(map.get());
    }

    public void LoadMap(string mapname)
    {
        Resource<Map> map = ResourceManager.Instance.GetMap(mapname);
        this.LoadMap(map);
    }
}