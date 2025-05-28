using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float tiempoTotal = 300f;
    private float tiempoRestante;
    public TextMeshProUGUI textoTiempo;

    private bool tiempoTerminado = false;
    public int puntuacionMinima = 70;       // mínimo para superar
    public string escenaNivelSuperado = "PantallaNextLevel";
    public string escenaGameOver = "GameOver";

    void Start()
    {
        tiempoRestante = tiempoTotal;
    }

    void Update()
    {
        if (tiempoTerminado) return;

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            tiempoTerminado = true;
            FinDelTiempo();
        }
        ActualizarTextoTiempo();
    }

    void ActualizarTextoTiempo()
    {
        int min = Mathf.FloorToInt(tiempoRestante / 60f);
        int sec = Mathf.FloorToInt(tiempoRestante % 60f);
        textoTiempo.text = $"Tiempo: {min:00}:{sec:00}";
    }

    void FinDelTiempo()
    {
        string nivelActual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevelName", nivelActual);
        PlayerPrefs.Save();

        int finalScore = ScoreManager.Instance.ObtenerScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        int score = ScoreManager.Instance.ObtenerScore();
        if (score >= puntuacionMinima)
            SceneManager.LoadScene(escenaNivelSuperado);
        else
            SceneManager.LoadScene(escenaGameOver);
    }
}

