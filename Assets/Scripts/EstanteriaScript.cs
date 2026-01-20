using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstanteriaScript : MonoBehaviour
{
    [HideInInspector] public int Count = 0;
    private Rigidbody2D estanteriaRB;
    [HideInInspector] public Vector3 initialPosition;

    private void Start()
    {
        estanteriaRB = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
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

    public void Restart()
    {
        transform.position = initialPosition;
        GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        estanteriaRB.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Count = 0;
    }
}
