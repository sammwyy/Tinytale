using System;
using UnityEngine;

public class Resource<S>
{
    private string _id;
    private string _path;

    private S _unwrapped;
    private bool _allocated;

    public Resource(string id, string path)
    {
        this._id = id;
        this._path = path;
        this._allocated = false;
    }

    public string ID
    {
        get
        {
            return this._id;
        }
    }

    public void Unalloc()
    {
        this._unwrapped = default(S);
        this._allocated = false;
    }

    public S convert()
    {
        Type target = typeof(S);
        object value = null;

        if (target == typeof(Translation))
        {
            value = Translation.LoadFromFile(this._path);
        }
        else if (target == typeof(Map))
        {
            value = Map.LoadFromFile(this._path);
        }
        else if (target == typeof(Sound))
        {
            value = Sound.LoadFromFile(this._path);
        }
        else if (target == typeof(Sprite))
        {
            value = IMG2Sprite.instance.LoadNewSprite(this._path, 15);
        }
        else if (target == typeof(Texture2D))
        {
            value = IMG2Sprite.instance.LoadTexture(this._path);
        }

        return (S)Convert.ChangeType(value, typeof(S));
    }

    public S get()
    {
        if (!this._allocated || this._unwrapped == null)
        {
            this._unwrapped = this.convert();
            this._allocated = true;
        }

        return this._unwrapped;
    }
}