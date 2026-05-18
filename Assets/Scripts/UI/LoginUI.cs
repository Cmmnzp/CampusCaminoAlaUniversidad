using UnityEngine;
using TMPro;

public class LoginUI : MonoBehaviour
{
    [Header("INPUTS")]
    public TMP_InputField correoInput;

    public TMP_InputField passwordInput;

    [Header("API")]
    public ApiManager apiManager;

    public void Login()
    {
        if (
            correoInput.text == "" ||
            passwordInput.text == ""
        )
        {
            Debug.LogWarning(
                "CAMPOS VACIOS"
            );

            return;
        }

        StartCoroutine(
            apiManager.Login(
                correoInput.text,
                passwordInput.text
            )
        );
    }
}