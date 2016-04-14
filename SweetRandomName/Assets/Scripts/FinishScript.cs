using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishScript : WorldObject
{
    public int sceneIndex;

    void Start()
    {
        GeneralStart();
    }

    void OnTriggerEnter2D(Component other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
