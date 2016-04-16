using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour 
{
    public GameObject MenuPanel;

    public void Start()
    {
        MenuPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPanel.SetActive(!MenuPanel.activeSelf);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseMenu()
    {
        MenuPanel.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
