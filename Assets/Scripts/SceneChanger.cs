using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Метод для перехода на сцену по имени
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

