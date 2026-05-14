using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager audioManager =
            FindFirstObjectByType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayMenuMusic();
        }
    }
}