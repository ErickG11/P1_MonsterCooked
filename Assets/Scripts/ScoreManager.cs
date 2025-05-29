using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Configuración de Puntuación")]
    public int score = 0;
    public int scoreMaximo = 100;            // ← Aquí lo añadimos
    public TextMeshProUGUI scoreText;        // Arrastra tu TextMeshProUGUI

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AgregarPuntos(int puntos)
    {
        score += puntos;
        UpdateScoreUI();
    }

    public int ObtenerScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
