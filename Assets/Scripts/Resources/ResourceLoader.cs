using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceLoader
{
    public static List<Resource<T>> ScanDirectory<T>(string prefix, string directory, string pattern)
    {
        if (!directory.EndsWith("/")) directory = directory + "/";

        List<Resource<T>> list = new List<Resource<T>>();

        if (Directory.Exists(directory))
        {
            string[] files = Directory.GetFiles(directory, pattern, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string id = prefix + ":" + file.Replace(directory, "").Split(".")[0].Replace("\\", "/");
                Resource<T> resource = new Resource<T>(id, file);
                list.Add(resource);
            }
        }

        return list;
    }

    public static int ScanDirectory(ResourceManager manager, string prefix, string directory)
    {
        int added = 0;
        added += manager.RegisterAll(ScanDirectory<Map>(prefix, Path.Combine(directory, "maps"), "*.map"));
        added += manager.RegisterAll(ScanDirectory<Sound>(prefix, Path.Combine(directory, "sounds"), "*.wav"));
        added += manager.RegisterAll(ScanDirectory<Texture2D>(prefix, Path.Combine(directory, "textures"), "*.jpg"));
        added += manager.RegisterAll(ScanDirectory<Texture2D>(prefix, Path.Combine(directory, "textures"), "*.png"));
        added += manager.RegisterAll(ScanDirectory<Tilemap>(prefix, Path.Combine(directory, "tiles"), "*.tilemap"));
        added += manager.RegisterAll(ScanDirectory<Translation>(prefix, Path.Combine(directory, "i18n"), "*.lang"));
        return added;
    }
}