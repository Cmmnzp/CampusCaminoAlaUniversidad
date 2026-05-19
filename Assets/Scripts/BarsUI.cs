using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BarsUI : MonoBehaviour
{
    public static BarsUI instancia;

    public PlayerStats player;

    [Header("API")]
    public ApiManager apiManager;

    [Header("Jugador")]
    public int idJugador = 1;

    [Header("Día")]
    public int diaActual = 1;

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

    public void ActualizarBarras(
        float energia,
        float conocimiento,
        float estres,
        float relaciones
    )
    {
        energiaFill.fillAmount = energia / 100f;

        conocimientoFill.fillAmount =
            conocimiento / 100f;

        estresFill.fillAmount =
            estres / 100f;

        relacionesFill.fillAmount =
            relaciones / 100f;

        if (textoEnergia != null)
            textoEnergia.text =
                Mathf.RoundToInt(energia) + "/100";

        if (textoConocimiento != null)
            textoConocimiento.text =
                Mathf.RoundToInt(conocimiento) + "/100";

        if (textoEstres != null)
            textoEstres.text =
                Mathf.RoundToInt(estres) + "/100";

        if (textoRelaciones != null)
            textoRelaciones.text =
                Mathf.RoundToInt(relaciones) + "/100";
    }

    public void GuardarEstado()
    {
        if (player == null) return;

        PartidaData partida =
            new PartidaData();

        partida.idJugador =
            idJugador;

        partida.fechaInicio =
            DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

        partida.diaActual =
            diaActual;

        partida.energia =
            Mathf.RoundToInt(player.energia);

        partida.conocimiento =
            Mathf.RoundToInt(player.conocimiento);

        partida.estres =
            Mathf.RoundToInt(player.estres);

        partida.relaciones =
            Mathf.RoundToInt(player.relaciones);

        partida.estado =
            "Jugando";

        StartCoroutine(
            apiManager.GuardarPartida(partida)
        );

        Debug.Log("ESTADO GUARDADO");
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

        //-----------------------------------
        // GUARDAR PARTIDA
        //-----------------------------------
        if (Input.GetKeyDown(KeyCode.P))
        {
            GuardarEstado();
        }
    }
}