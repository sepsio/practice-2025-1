using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLastScene : MonoBehaviour
{
    public void TryAgain()
    {
        if (PlayerPrefs.HasKey("lastScene"))
        {
            string lastScene = PlayerPrefs.GetString("lastScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("Предыдущая сцена не найдена в PlayerPrefs!");
        }
    }
}

