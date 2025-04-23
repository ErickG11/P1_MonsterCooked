using TMPro; // Asegúrate de importar el espacio de nombres de TextMeshPro
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float tiempoTotal = 300f; // 5 minutos = 300 segundos
    private float tiempoRestante;
    public TextMeshProUGUI textoTiempo; // Cambié esto a TextMeshProUGUI

    private bool tiempoTerminado = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;
    }

    void Update()
    {
        if (!tiempoTerminado)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                tiempoTerminado = true;
                FinDelTiempo();
            }

            ActualizarTextoTiempo();
        }
    }

    void ActualizarTextoTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTiempo.text = string.Format("Tiempo restante: {0:00}:{1:00}", minutos, segundos);
    }

    void FinDelTiempo()
    {
        // Aquí puedes cambiar de escena, mostrar panel, etc.
        Debug.Log("¡Tiempo terminado!");
        // SceneManager.LoadScene("GameOverScene"); // Si quieres cargar otra escena
    }
}
