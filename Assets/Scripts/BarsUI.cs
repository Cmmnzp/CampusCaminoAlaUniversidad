using UnityEngine;
using UnityEngine.UI;

public class BarsUI : MonoBehaviour
{
    public PlayerStats player;

    [Header("Barras")]
    public Image energiaFill;
    public Image conocimientoFill;
    public Image estresFill;
    public Image relacionesFill; 

    void Update()
    {
        if (player == null) return;

        energiaFill.fillAmount = player.energia / 100f;
        conocimientoFill.fillAmount = player.conocimiento / 100f;
        estresFill.fillAmount = player.estres / 100f;
        relacionesFill.fillAmount = player.relaciones / 100f; 
    }
}