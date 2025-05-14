using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHome : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
