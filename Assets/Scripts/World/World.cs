using UnityEngine;

public class World : MonoBehaviour
{
    private Map _map;

    [SerializeField]
    private GameObject _tilePrefab;

    public void KillChildren()
    {
        foreach (GameObject child in this.transform)
        {
            Destroy(child);
        }
    }

    public void LoadMap(Map map)
    {
        this.KillChildren();

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