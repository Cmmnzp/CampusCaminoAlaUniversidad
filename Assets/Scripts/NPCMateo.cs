using UnityEngine;

public class NPCMateo : MonoBehaviour
{
    public GameObject panelDialogo;

    public void Interactuar()
    {
        panelDialogo.SetActive(true);
        Time.timeScale = 0f;
    }
}