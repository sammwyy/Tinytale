using System.IO;
using UnityEngine;

public class IMG2Sprite
{
    public static Texture2D LoadTexture(string filepath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D texture;
        byte[] data;

        if (File.Exists(filepath))
        {
            data = File.ReadAllBytes(filepath);
            texture = new Texture2D(2, 2);           // Create new "empty" texture
            if (texture.LoadImage(data))           // Load the imagedata into the texture (size is set automatically)
                return texture;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    public static Sprite LoadNewSprite(Texture2D texture, float pixelsPerUnit = 100.0f)
    {
        //  Assign texture to a new sprite and return its reference.
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), pixelsPerUnit);
        return sprite;
    }

    public static Sprite LoadNewSprite(string filepath, float pixelsPerUnit = 100.0f)
    {
        // Load a PNG or JPG image from disk to a Texture2D.
        return LoadNewSprite(LoadTexture(filepath), pixelsPerUnit);
    }
}