using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager audioManager =
            FindFirstObjectByType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.PlayGameMusic();
        }
    }
}