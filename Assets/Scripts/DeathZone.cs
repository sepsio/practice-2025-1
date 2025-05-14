using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Сохраняем имя текущей сцены
            PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();

            // Загружаем сцену проигрыша
            SceneManager.LoadScene("Lost");
        }
    }
}

