using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public int startScene = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }
}
