using UnityEngine;
using System.Collections;

public class BackgroundScript : Changable
{   
    public GameObject mainCamera;
    private CameraMovingScript cameraMovingScript;

    private Vector3 baseOffset;

    public Sprite[] worldSprites;

    public void Start()
    {
        cameraMovingScript = mainCamera.GetComponent<CameraMovingScript>();
        PreStart();
        ChangeWorld();
        baseOffset = transform.position - mainCamera.transform.position;
    }

    protected override void ChangeWorld()
    {
        sprites[0].sprite = worldSprites[(int)world.CurWorld - 8];
    }

    void Update()
    {
        transform.position = mainCamera.transform.position - cameraMovingScript.baseOffset;
        ChangeWorld();
    }

    public override void Reset()
    {
        transform.localPosition = mainCamera.transform.position + baseOffset;
    }
}
