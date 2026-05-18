using UnityEngine;
using TMPro;

public class RegisterUI : MonoBehaviour
{
    [Header("INPUTS")]
    public TMP_InputField nombreInput;

    public TMP_InputField apellidoInput;

    public TMP_InputField correoInput;

    public TMP_InputField passwordInput;

    [Header("API")]
    public ApiManager apiManager;

    public void Registrar()
    {
        if (
            nombreInput.text == "" ||
            apellidoInput.text == "" ||
            correoInput.text == "" ||
            passwordInput.text == ""
        )
        {
            Debug.LogWarning(
                "CAMPOS VACIOS"
            );

            return;
        }

        JugadorData jugador =
            new JugadorData();

        jugador.nombre =
            nombreInput.text;

        jugador.apellido =
            apellidoInput.text;

        jugador.correo =
            correoInput.text;

        jugador.password =
            passwordInput.text;

        StartCoroutine(
            apiManager.RegistrarJugador(
                jugador
            )
        );
    }
}