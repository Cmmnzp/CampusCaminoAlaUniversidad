using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayMenuMusic();
        }
    }
}