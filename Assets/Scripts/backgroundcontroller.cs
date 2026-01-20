using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPosX;
    private float camStartPosX;


    public GameObject cam;
    public float parallaxEffect;


    private void Start()
    {
        startPosX = transform.position.x;
        camStartPosX = cam.transform.position.x;
    }


    private void Update()
    {
        float camOffset = cam.transform.position.x - camStartPosX;
        float distance = camOffset * parallaxEffect;


        transform.position = new Vector3(
            startPosX + distance,
            transform.position.y,
            transform.position.z
        );
    }
}
