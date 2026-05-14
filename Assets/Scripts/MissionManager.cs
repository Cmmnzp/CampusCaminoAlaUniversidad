using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instancia;

    private int estado = 0;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        ActualizarMisionPorDia();
    }

    public void SiguienteMision()
    {
        estado++;

        int dia = DayManager.instancia != null
            ? DayManager.instancia.diaActual
            : 1;

        switch (dia)
        {
            case 1:
                MisionesDia1();
                break;

            case 2:
                MisionesDia2();
                break;

            case 3:
                MisionesDia3();
                break;

            case 4:
                MisionesDia4();
                break;

            case 5:
                MisionesDia5();
                break;

            case 6:
                MisionesDia6();
                break;

            case 7:
                MisionesDia7();
                break;
        }
    }

    void MisionesDia1()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Encuentra a Mateo en el campus");
                break;

            case 1:
                AsignarMision("Completa el entrenamiento de movimiento");
                break;

            case 2:
                AsignarMision("Sigue a Mateo hasta el aula");
                break;

            case 3:
                AsignarMision("Habla con el profesor para iniciar la clase");
                break;

            case 4:
                AsignarMision("Dia 1 completado");
                break;
        }
    }

    void MisionesDia2()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Estudia la teoria del libro");
                break;

            case 1:
                AsignarMision("Organiza correctamente el algoritmo");
                break;

            case 2:
                AsignarMision("Define tu estrategia de estudio con Mateo");
                break;

            case 3:
                AsignarMision("Dia 2 completado");
                break;
        }
    }

    void MisionesDia3()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Habla con Laura para iniciar la actividad");
                break;

            case 1:
                AsignarMision("Estudia las secuencias matematicas");
                break;

            case 2:
                AsignarMision("Resuelve la secuencia matematica");
                break;

            case 3:
                AsignarMision("Toma una decision Biblioteca o Cafeteria");
                break;

            case 4:
                AsignarMision("Dia 3 completado");
                break;
        }
    }

    void MisionesDia4()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Habla con Felipe en direccion");
                break;

            case 1:
                AsignarMision("Estudia la teoria de algoritmos");
                break;

            case 2:
                AsignarMision("Organiza correctamente el algoritmo");
                break;

            case 3:
                AsignarMision("Habla con Mateo sobre el proximo proyecto");
                break;

            case 4:
                AsignarMision("Decide como trabajar el proximo proyecto");
                break;

            case 5:
                AsignarMision("Dia 4 completado");
                break;
        }
    }

    void MisionesDia5()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Habla con Carlos para iniciar el parcial");
                break;

            case 1:
                AsignarMision("Estudia la teoria del parcial");
                break;

            case 2:
                AsignarMision("Responde correctamente el parcial");
                break;

            case 3:
                AsignarMision("Decide si estudiar o descansar");
                break;

            case 4:
                AsignarMision("Dia 5 completado");
                break;
        }
    }

    void MisionesDia6()
    {
        switch (estado)
        {
            case 0:
                AsignarMision(
                    "Habla con Laura sobre tu rendimiento academico"
                );
                break;

            case 1:
                AsignarMision(
                    "Revisa cuidadosamente tu reporte academico"
                );
                break;

            case 2:
                AsignarMision(
                    "Dirigete a la biblioteca principal"
                );
                break;

            case 3:
                AsignarMision(
                    "Revisa los apuntes finales en el libro"
                );
                break;

            case 4:
                AsignarMision(
                    "Habla con el profesor antes del examen final"
                );
                break;

            case 5:
                AsignarMision(
                    "Toma tu decision final para prepararte"
                );
                break;

            case 6:
                AsignarMision(
                    "Dia 6 completado"
                );
                break;
        }
    }

    void MisionesDia7()
    {
        switch (estado)
        {
            case 0:
                AsignarMision(
                    "Habla con el director para iniciar el examen final"
                );
                break;

            case 1:
                AsignarMision(
                    "Lee cuidadosamente la teoria del examen"
                );
                break;

            case 2:
                AsignarMision(
                    "Completa correctamente el examen final"
                );
                break;

            case 3:
                AsignarMision(
                    "Revisa tu resultado final del semestre"
                );
                break;

            case 4:
                AsignarMision(
                    "Fin del juego"
                );
                break;
        }
    }

    
    public void AsignarMision(string texto)
    {
        if (MissionUI.instancia != null)
        {
            MissionUI.instancia.ActualizarMision(texto);
        }
    }

    
    public void ActualizarMisionPorDia()
    {
        int dia = DayManager.instancia != null
            ? DayManager.instancia.diaActual
            : 1;

        estado = 0;

        switch (dia)
        {
            case 1:
                MisionesDia1();
                break;

            case 2:
                MisionesDia2();
                break;

            case 3:
                MisionesDia3();
                break;

            case 4:
                MisionesDia4();
                break;

            case 5:
                MisionesDia5();
                break;

            case 6:
                MisionesDia6();
                break;

            case 7:
                MisionesDia7();
                break;
        }
    }

    public void SetEstado(int nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public int GetEstado()
    {
        return estado;
    }
}