using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private static ResourceManager _instance;

    public static ResourceManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private Dictionary<string, Resource<Map>> _maps;
    private Dictionary<string, Resource<Sound>> _sounds;
    private Dictionary<string, Resource<Texture2D>> _textures;
    private Dictionary<string, Resource<Tilemap>> _tilemaps;
    private Dictionary<string, Resource<Translation>> _translations;

    public ResourceManager()
    {
        _instance = this;

        this._maps = new Dictionary<string, Resource<Map>>();
        this._sounds = new Dictionary<string, Resource<Sound>>();
        this._textures = new Dictionary<string, Resource<Texture2D>>();
        this._tilemaps = new Dictionary<string, Resource<Tilemap>>();
        this._translations = new Dictionary<string, Resource<Translation>>();
    }

    public int LoadFromMod(Mod mod)
    {
        return ResourceLoader.ScanDirectory(this, mod.Descriptor.id, mod.Directory);
    }

    public void Register(Resource<Map> resource)
    {
        Debug.Log("[ResourceManager] Registered map: " + resource.ID);
        this._maps.Add(resource.ID, resource);
    }

    public int RegisterAll(List<Resource<Map>> resources)
    {
        foreach (Resource<Map> resource in resources)
        {
            this.Register(resource);
        }

        return resources.Count;
    }

    public void Register(Resource<Sound> resource)
    {
        Debug.Log("[ResourceManager] Registered sound: " + resource.ID);
        this._sounds.Add(resource.ID, resource);
    }

    public int RegisterAll(List<Resource<Sound>> resources)
    {
        foreach (Resource<Sound> resource in resources)
        {
            this.Register(resource);
        }

        return resources.Count;
    }

    public void Register(Resource<Texture2D> resource)
    {
        Debug.Log("[ResourceManager] Registered texture: " + resource.ID);
        this._textures.Add(resource.ID, resource);
    }

    public int RegisterAll(List<Resource<Texture2D>> resources)
    {
        foreach (Resource<Texture2D> resource in resources)
        {
            this.Register(resource);
        }

        return resources.Count;
    }

    public void Register(Resource<Tilemap> resource)
    {
        Debug.Log("[ResourceManager] Registered tilemap: " + resource.ID);
        this._tilemaps.Add(resource.ID, resource);
    }

    public int RegisterAll(List<Resource<Tilemap>> resources)
    {
        foreach (Resource<Tilemap> resource in resources)
        {
            this.Register(resource);
        }

        return resources.Count;
    }

    public void Register(Resource<Translation> resource)
    {
        Debug.Log("[ResourceManager] Registered translation: " + resource.ID);
        this._translations.Add(resource.ID, resource);
    }

    public int RegisterAll(List<Resource<Translation>> resources)
    {
        foreach (Resource<Translation> resource in resources)
        {
            this.Register(resource);
        }

        return resources.Count;
    }

    public Resource<Map> GetMap(string name)
    {
        Resource<Map> map;
        this._maps.TryGetValue(name, out map);
        return map;
    }

    public Resource<Sound> GetSound(string name)
    {
        Resource<Sound> sound;
        this._sounds.TryGetValue(name, out sound);
        return sound;
    }

    public Resource<Texture2D> GetTexture(string name)
    {
        Resource<Texture2D> texture;
        this._textures.TryGetValue(name, out texture);
        return texture;
    }

    public Resource<Tilemap> GetTilemap(string name)
    {
        Resource<Tilemap> tilemap;
        this._tilemaps.TryGetValue(name, out tilemap);
        return tilemap;
    }

    public Resource<Translation> GetTranslation(string lang)
    {
        Resource<Translation> translation;
        this._translations.TryGetValue(lang, out translation);
        return translation;
    }
}