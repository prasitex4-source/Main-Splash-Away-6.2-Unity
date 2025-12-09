using UnityEngine;
using System.Collections;

public class charco : MonoBehaviour
{
    private float timerMaxTime = 2.5f;
    private float currentTime;
    private bool isOn;

    private Animator animator;
    private SpriteRenderer spr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentTime = timerMaxTime;
        animator.SetBool("isOn", isOn);
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= Time.deltaTime;
        if (currentTime < 0 )
        {
            if (GetComponent<Collider2D>().enabled == true)
            {
                isOn = false;
                GetComponent<Collider2D>().enabled = false;
                currentTime = timerMaxTime;
            }
            else
            {
                isOn = true;
                GetComponent<Collider2D>().enabled = true;
                currentTime = timerMaxTime;
            }
        }
    }

}
