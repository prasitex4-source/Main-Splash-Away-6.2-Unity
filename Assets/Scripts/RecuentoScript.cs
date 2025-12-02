using UnityEngine;
using UnityEngine.InputSystem;

public class RecuentoScript : MonoBehaviour
{
    [SerializeField] private FishMovement jumps;
    private Animator animator;

    [Header("Seguimiento Player")]
    [SerializeField] private GameObject playerPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("saltos", jumps.jumpCount);
        transform.position = playerPos.transform.position;

    }
}
