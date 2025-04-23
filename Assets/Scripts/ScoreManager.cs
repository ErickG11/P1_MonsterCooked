using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI mensajeNivelCompletado;

    public int scoreMaximo = 100;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ActualizarTexto();
        mensajeNivelCompletado.gameObject.SetActive(false); // Ocultar el mensaje al inicio
    }

    public void AgregarPuntos(int puntos)
    {
        score += puntos;
        ActualizarTexto();

        if (score >= scoreMaximo)
        {
            MostrarNivelCompletado();
        }
    }

    public int ObtenerScore()
    {
        return score;
    }

    private void ActualizarTexto()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    private void MostrarNivelCompletado()
    {
        if (mensajeNivelCompletado != null)
        {
            mensajeNivelCompletado.gameObject.SetActive(true);
            mensajeNivelCompletado.text = "¡Nivel Completado!";
        }
    }
}
