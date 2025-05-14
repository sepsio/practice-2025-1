using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text coinCounterText;   // UI текст для счётчика монет
    private int totalCoins;
    private int collectedCoins = 0;

    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCoinCounter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collectedCoins++;
            UpdateCoinCounter();
            Destroy(collision.gameObject);

            if (collectedCoins >= totalCoins)
            {
                SaveProgressAndLoadNextLevel();
            }
        }
    }

    void UpdateCoinCounter()
    {
        coinCounterText.text = collectedCoins + " / " + totalCoins;
    }

    void SaveProgressAndLoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("CurrentLevel", nextLevelIndex);
            PlayerPrefs.Save();

            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("Последний уровень пройден!");
            // Можно загрузить меню или показать экран окончания игры
        }
    }
}



