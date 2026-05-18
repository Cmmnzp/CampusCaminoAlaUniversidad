using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;

public class ApiManager : MonoBehaviour
{
    private string baseUrl =
        "http://ingenieriadesoftware.somee.com/api/";

    public IEnumerator RegistrarJugador(
        JugadorData jugador
    )
    {
        string json =
            JsonUtility.ToJson(jugador);

        Debug.Log(json);

        UnityWebRequest request =
            new UnityWebRequest(
                baseUrl + "Jugadores",
                "POST"
            );

        byte[] bodyRaw =
            Encoding.UTF8.GetBytes(json);

        request.uploadHandler =
            new UploadHandlerRaw(bodyRaw);

        request.downloadHandler =
            new DownloadHandlerBuffer();

        request.SetRequestHeader(
            "Content-Type",
            "application/json"
        );

        yield return request.SendWebRequest();

        if (request.result ==
            UnityWebRequest.Result.Success)
        {
            Debug.Log("REGISTRO EXITOSO");

            FindObjectOfType<SceneManagerGame>()
                .RegistroExitoso();
        }
        else
        {
            Debug.LogError(
                "ERROR EN REGISTRO"
            );

            Debug.LogError(
                request.responseCode
            );

            Debug.LogError(
                request.error
            );

            Debug.LogError(
                request.downloadHandler.text
            );
        }
    }

    public IEnumerator Login(
        string correo,
        string password
    )
    {
        LoginData loginData =
            new LoginData();

        loginData.correo = correo;

        loginData.password = password;

        string json =
            JsonUtility.ToJson(loginData);

        Debug.Log(json);

        UnityWebRequest request =
            new UnityWebRequest(
                baseUrl + "Jugadores/login",
                "POST"
            );

        byte[] bodyRaw =
            Encoding.UTF8.GetBytes(json);

        request.uploadHandler =
            new UploadHandlerRaw(bodyRaw);

        request.downloadHandler =
            new DownloadHandlerBuffer();

        request.SetRequestHeader(
            "Content-Type",
            "application/json"
        );

        yield return request.SendWebRequest();

        if (request.result ==
            UnityWebRequest.Result.Success)
        {
            Debug.Log("LOGIN EXITOSO");

            SceneManager.LoadScene(
                "IntroGameplay"
            );
        }
        else
        {
            Debug.LogError(
                "ERROR LOGIN"
            );

            Debug.LogError(
                request.responseCode
            );

            Debug.LogError(
                request.error
            );

            Debug.LogError(
                request.downloadHandler.text
            );
        }
    }
}

[System.Serializable]
public class LoginData
{
    public string correo;

    public string password;
}