using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [Tooltip("Si quieres reiniciar al llegar al último nivel, marca esto.")]
    public bool loopBackToFirst = false;

    /// <summary>
    /// Llamar desde el OnClick() del botón.
    /// </summary>
    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextIndex = currentIndex + 1;

        if (nextIndex < totalScenes)
        {
            SceneManager.LoadScene(nextIndex);
            Debug.Log($"🔘 Cargando nivel {nextIndex} (escena index)");
        }
        else if (loopBackToFirst)
        {
            SceneManager.LoadScene(0);
            Debug.Log("🔘 Último nivel, volviendo al primero (index 0).");
        }
        else
        {
            Debug.LogWarning("NextLevelLoader: no hay más niveles en Build Settings.");
        }
    }
}

