using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstanteriaScript : MonoBehaviour
{
    private int jumpCount = 0;
    private Rigidbody2D estanteriaRB;

    private void Start()
    {
        estanteriaRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jumpCount ++;
        }
    }


    private void Update()
    {
        if (jumpCount == 2)
        {
            estanteriaRB.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
