using UnityEngine;

public class Sound
{
    private AudioClip _clip;

    public Sound(AudioClip clip)
    {
        this._clip = clip;
    }

    public AudioClip Clip
    {
        get
        {
            return this._clip;
        }
    }

    public static Sound LoadFromFile(string filepath)
    {
        return new Sound(AudioLoader.LoadClip(filepath));
    }
}