using UnityEngine;

public class SoundSystemAccessor
{
    public readonly static SoundSystemAccessor Instance = new SoundSystemAccessor();

    public void PlayBGM(AudioClip clip)
    {
        SoundSystem.PlayBGM(clip);
    }

    public void PlayBGM(Sound sound)
    {
        SoundSystem.PlayBGM(sound);
    }

    public void PlayBGM(Resource<Sound> sound)
    {
        SoundSystem.PlayBGM(sound);
    }


    public void PlaySFX(AudioClip clip)
    {
        SoundSystem.PlaySFX(clip);
    }
}