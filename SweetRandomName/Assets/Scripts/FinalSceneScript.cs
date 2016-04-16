using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneScript : MonoBehaviour 
{
    public GameObject Girl;
    public GameObject Kiss;
    public Image panelImage;

    private float startTime;
    public float EndingLatency;
    private float endingTimeStart;

    void Start()
    {
        endingTimeStart = EndingLatency;
    }

    public void OnTriggerEnter2D(Component other)
    {
        var rot = Girl.transform.rotation;
        rot.y = 0f;
        Girl.transform.rotation = rot;
        Kiss.SetActive(true);
        startTime = Time.time;
        EndGame();
    }

    void EndGame()
    {
        StartCoroutine(End());
        Invoke("ExitToMainMenu", EndingLatency);
    }

    IEnumerator End()
    {
        while(startTime + EndingLatency > Time.time)
        {
            var clr = panelImage.color;
            clr.a = (Time.time - startTime) / EndingLatency;
            panelImage.color = clr;
            yield return null;
        }
            
    }
    void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
