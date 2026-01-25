using UnityEngine;
using UnityEngine.SceneManagement;

public class curtainTriggerScript : MonoBehaviour
{

    [SerializeField] GameObject curtains;
    [SerializeField] Animator animator;
    private bool charOut = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = curtains.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("charOut", charOut);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            charOut = true;
        }
    }
}
