using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModManager
{
    private Dictionary<string, Mod> mods;

    public ModManager()
    {
        this.mods = new Dictionary<string, Mod>();
    }

    public Mod GetMod(string id)
    {
        Mod mod;
        this.mods.TryGetValue(id, out mod);
        return mod;
    }

    public Mod Load(string path)
    {
        Mod mod = new Mod(path);
        Debug.Log("Preparing mod load of " + path);
        mod.Load();
        this.mods.Add(mod.Descriptor.id, mod);
        Debug.Log("Loaded mod " + mod.Descriptor.id + " under " + path);
        return mod;
    }

    public int ScanDirectory(string path)
    {
        int loaded = 0;

        string[] subdirs = Directory.GetDirectories(path);
        foreach (string dir in subdirs)
        {
            this.Load(dir);
            loaded++;
        }

        return loaded;
    }

    public int LoadResources(ResourceManager resources)
    {
        int loaded = 0;

        foreach (Mod mod in this.mods.Values)
        {
            loaded += resources.LoadFromMod(mod);
        }

        return loaded;
    }
}