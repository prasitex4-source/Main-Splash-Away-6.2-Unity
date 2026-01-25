using UnityEngine;

public class curtainTriggerScript : MonoBehaviour
{

    [SerializeField] GameObject curtains;
    [SerializeField] Animator animator;

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
}
