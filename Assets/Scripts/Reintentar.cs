using UnityEngine;
using UnityEngine.SceneManagement;

public class Reintentar : MonoBehaviour
{
   
    public void LoadLevel()
    {
        string nivelARetry = PlayerPrefs.GetString("LastLevelName", "");
        if (!string.IsNullOrEmpty(nivelARetry))
        {
            SceneManager.LoadScene(nivelARetry);
        }
        else
        {
            Debug.LogWarning("RetryLevelLoader: no se encontró 'LastLevelName' en PlayerPrefs.");
        }
    }
}
