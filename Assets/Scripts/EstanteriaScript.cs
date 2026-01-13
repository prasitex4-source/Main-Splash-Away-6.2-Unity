using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstanteriaScript : MonoBehaviour
{
    private int Count = 0;
    private Rigidbody2D estanteriaRB;

    private void Start()
    {
        estanteriaRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Count ++;
        }
    }


    private void Update()
    {
        if (Count >= 2)
        {
            estanteriaRB.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
