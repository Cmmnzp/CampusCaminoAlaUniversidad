using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class BarsUI : MonoBehaviour
{
    public static BarsUI instancia;

    public PlayerStats player;

    [Header("Barras")]
    public Image energiaFill;
    public Image conocimientoFill;
    public Image estresFill;
    public Image relacionesFill;

    [Header("Textos")] 
    public TextMeshProUGUI textoEnergia;
    public TextMeshProUGUI textoConocimiento;
    public TextMeshProUGUI textoEstres;
    public TextMeshProUGUI textoRelaciones;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        if (player != null)
        {
            ActualizarBarras(
                player.energia,
                player.conocimiento,
                player.estres,
                player.relaciones
            );
        }
    }

    public void ActualizarBarras(float energia, float conocimiento, float estres, float relaciones)
    {
        energiaFill.fillAmount = energia / 100f;
        conocimientoFill.fillAmount = conocimiento / 100f;
        estresFill.fillAmount = estres / 100f;
        relacionesFill.fillAmount = relaciones / 100f;

        if (textoEnergia != null)
            textoEnergia.text = Mathf.RoundToInt(energia) + "/100";

        if (textoConocimiento != null)
            textoConocimiento.text = Mathf.RoundToInt(conocimiento) + "/100";

        if (textoEstres != null)
            textoEstres.text = Mathf.RoundToInt(estres) + "/100";

        if (textoRelaciones != null)
            textoRelaciones.text = Mathf.RoundToInt(relaciones) + "/100";
    }

    void Update()
    {
        if (player == null) return;

        ActualizarBarras(
            player.energia,
            player.conocimiento,
            player.estres,
            player.relaciones
        );
    }
}