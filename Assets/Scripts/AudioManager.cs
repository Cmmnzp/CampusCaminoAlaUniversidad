using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Header("UI")]
    public Slider sliderVolumen;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        float volumen =
            PlayerPrefs.GetFloat("Volumen", 1f);

        audioSource.volume = volumen;

        if (sliderVolumen != null)
        {
            sliderVolumen.value = volumen;

            sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        }
    }

    public void CambiarVolumen(float volumen)
    {
        audioSource.volume = volumen;

        PlayerPrefs.SetFloat("Volumen", volumen);

        PlayerPrefs.Save();
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