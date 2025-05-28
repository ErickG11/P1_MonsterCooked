using UnityEngine;
using TMPro;

public class NivelSuperadoUI : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_Text finalScoreText;   // Tu TextMeshProUGUI en la escena

    void Start()
    {
        // 1) Recupera el score guardado
        int score = PlayerPrefs.GetInt("LastScore", 0);

        // 2) Muestra el score en pantalla
        if (finalScoreText != null)
            finalScoreText.text = "Puntaje final: " + score;
    }
}
