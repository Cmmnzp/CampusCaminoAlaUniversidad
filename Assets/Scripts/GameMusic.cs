using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayGameMusic();
        }
    }
}