using UnityEngine;

public class MissionMarkerManager : MonoBehaviour
{
    [Header("Dia 1")]
    public GameObject markerMateoD1;
    public GameObject markerProfesorD1;

    [Header("Dia 2")]
    public GameObject markerLibroD2;
    public GameObject markerPuzzleD2;
    public GameObject markerMateoD2;

    [Header("Dia 3")]
    public GameObject markerLauraD3;
    public GameObject markerLibroD3;
    public GameObject markerPuzzleD3;

    [Header("Dia 4")]
    public GameObject markerFelipeD4;
    public GameObject markerLibroD4;
    public GameObject markerPuzzleD4;
    public GameObject markerMateoD4;

    [Header("Dia 5")]
    public GameObject markerCarlosD5;
    public GameObject markerLibroD5;
    public GameObject markerParcialD5;

    [Header("Dia 6")]
    public GameObject markerLauraD6;
    public GameObject markerLaptopD6;
    public GameObject markerDirectorD6;

    void Update()
    {
        ActualizarMarkers();
    }

    void ActualizarMarkers()
    {
        DesactivarTodos();

        if (DayManager.instancia == null)
            return;

        if (MissionManager.instancia == null)
            return;

        int dia = DayManager.instancia.diaActual;

        int estado = MissionManager.instancia.GetEstado();

        if (dia == 1)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerMateoD1);

                    break;

                case 3:

                    Activar(markerProfesorD1);

                    break;
            }
        }

        if (dia == 2)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerLibroD2);

                    break;

                case 1:

                    Activar(markerPuzzleD2);

                    break;

                case 2:

                    Activar(markerMateoD2);

                    break;
            }
        }

        if (dia == 3)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerLauraD3);

                    break;

                case 1:

                    Activar(markerLibroD3);

                    break;

                case 2:

                    Activar(markerPuzzleD3);

                    break;
            }
        }

        if (dia == 4)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerFelipeD4);

                    break;

                case 1:

                    Activar(markerLibroD4);

                    break;

                case 2:

                    Activar(markerPuzzleD4);

                    break;

                case 3:

                    Activar(markerMateoD4);

                    break;
            }
        }

        if (dia == 5)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerCarlosD5);

                    break;

                case 1:

                    Activar(markerLibroD5);

                    break;

                case 2:

                    Activar(markerParcialD5);

                    break;
            }
        }

        if (dia == 6)
        {
            switch (estado)
            {
                case 0:

                    Activar(markerLauraD6);

                    break;

                case 2:

                    Activar(markerLaptopD6);

                    break;

                case 4:

                    Activar(markerDirectorD6);

                    break;
            }
        }
    }

    void Activar(GameObject marker)
    {
        if (marker != null)
        {
            marker.SetActive(true);
        }
    }

    void DesactivarTodos()
    {
        GameObject[] todos =
        {
            markerMateoD1,
            markerProfesorD1,

            markerLibroD2,
            markerPuzzleD2,
            markerMateoD2,

            markerLauraD3,
            markerLibroD3,
            markerPuzzleD3,

            markerFelipeD4,
            markerLibroD4,
            markerPuzzleD4,
            markerMateoD4,

            markerCarlosD5,
            markerLibroD5,
            markerParcialD5,

            markerLauraD6,
            markerLaptopD6,
            markerDirectorD6
        };

        foreach (GameObject marker in todos)
        {
            if (marker != null)
            {
                marker.SetActive(false);
            }
        }
    }
}