using UnityEngine;
using UnityEngine.UI;

public class IndicadorAlex : MonoBehaviour
{
    public Transform jugador;
    public PlayerStats stats;

    public Image icono;

    public Sprite iconoNormal;
    public Sprite iconoCansado;
    public Sprite iconoEstresado;
    public Sprite iconoFeliz;

    public Vector3 offset = new Vector3(0, 2f, 0);

    void Update()
    {
        if (jugador != null && Camera.main != null)
        {
            Vector3 worldPos = jugador.position + offset;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            transform.position = screenPos;
        }

        if (stats != null && icono != null)
        {
            if (stats.energia < 20)
                icono.sprite = iconoCansado;
            else if (stats.estres > 70)
                icono.sprite = iconoEstresado;
            else if (stats.relaciones > 50)
                icono.sprite = iconoFeliz;
            else
                icono.sprite = iconoNormal;
        }
    }
}