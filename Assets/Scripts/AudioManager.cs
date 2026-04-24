using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}