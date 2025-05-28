using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Puntuación")]
    public int score = 0;                    // tu puntuación actual
    public TextMeshProUGUI scoreText;        // referencia al texto en pantalla

    void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    /// <summary>
    /// Llamar desde tu PedidoManager u otro lugar para sumar puntos.
    /// </summary>
    public void AgregarPuntos(int puntos)
    {
        score += puntos;
        UpdateScoreUI();
    }

    /// <summary>
    /// Permite al TimerManager saber cuántos puntos llevas.
    /// </summary>
    public int ObtenerScore()
    {
        return score;
    }

    /// <summary>
    /// Actualiza el texto de la UI.
    /// </summary>
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
