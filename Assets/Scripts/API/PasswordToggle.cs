using UnityEngine;
using TMPro;

public class PasswordToggle : MonoBehaviour
{
    [Header("PASSWORD INPUT")]
    public TMP_InputField passwordInput;

    public void TogglePassword()
    {
        if (
            passwordInput.contentType ==
            TMP_InputField.ContentType.Password
        )
        {
            passwordInput.contentType =
                TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordInput.contentType =
                TMP_InputField.ContentType.Password;
        }

        passwordInput.ForceLabelUpdate();
    }
}