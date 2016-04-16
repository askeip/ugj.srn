using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    public int startScene = 1;

    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject chooseLevelPanel;
    public GameObject[] inactiveObjects;

    public Animator[] animators;

    public bool buttonPressed;



    void Start()
    {
        animators = gameObject.GetComponentsInChildren<Animator>();  
    }

    public void Update()
    {
        if (Input.anyKey && !buttonPressed)
        {
            buttonPressed = true;
            foreach (var anim in animators)
                anim.SetBool("ButtonPressed", buttonPressed);
            firstPanel.SetActive(false);
            Invoke("ActivateEverything", 1.1f);
        }

    }

    void ActivateEverything()
    {
        foreach (var anim in animators)
            anim.SetBool("Active", buttonPressed);
        secondPanel.SetActive(true);
        foreach (var inactive in inactiveObjects)
            inactive.SetActive(true);
    }

    public void StartGame(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void ChooseLevel()
    {
        secondPanel.SetActive(false);
        chooseLevelPanel.SetActive(true);
    }

    public void BackFromChoosingLevel()
    {
        chooseLevelPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
