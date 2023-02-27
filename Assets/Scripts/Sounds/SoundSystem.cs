using UnityEngine;

public class SoundSystem : MonoBehaviour
{

    [SerializeField]
    private AudioSource bgmSource;

    [SerializeField]
    private AudioSource sfxSource;

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void PlayBGM(Sound sound)
    {
        PlayBGM(sound.Clip);
    }

    public void PlayBGM(Resource<Sound> sound)
    {
        PlayBGM(sound.get());
    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}