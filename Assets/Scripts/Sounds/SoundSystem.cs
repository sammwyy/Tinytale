using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private static SoundSystem _instance;

    public static SoundSystem Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    private AudioSource bgmSource;

    [SerializeField]
    private AudioSource sfxSource;

    void Awake()
    {
        _instance = this;
    }

    public static void PlayBGM(AudioClip clip)
    {
        _instance.bgmSource.clip = clip;
        _instance.bgmSource.Play();
    }

    public static void PlayBGM(Sound sound)
    {
        PlayBGM(sound.Clip);
    }

    public static void PlayBGM(Resource<Sound> sound)
    {
        PlayBGM(sound.get());
    }


    public static void PlaySFX(AudioClip clip)
    {
        _instance.sfxSource.PlayOneShot(clip);
    }
}