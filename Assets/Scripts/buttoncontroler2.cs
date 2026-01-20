using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttoncontroler2 : MonoBehaviour
{
    [SerializeField] private GameObject activado;
    [SerializeField] private GameObject temporizado;
    [SerializeField] private Sprite buttonOn;
    [SerializeField] private Sprite buttonOff;

    [Header("Audio")]
    [SerializeField] audiomanager audiomanager;

    [HideInInspector] public bool isPressed = false;
    [HideInInspector] public bool isActiveDoor = false;
    [HideInInspector] public bool isActiveTimer = false;


    void Start()
    {
        activado.SetActive(true);
        temporizado.SetActive(false);
    }

    public void RestartTimerButton()
    {
        StopAllCoroutines();
        StartCoroutine(Temporizar());
        if(audiomanager != null)
        {
           audiomanager.StopSFX(audiomanager.timer); 
        }  
        temporizado.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff;
        activado.SetActive(true);
        isPressed = false;
        isActiveDoor = false;
        isActiveTimer = false;
    }
    private IEnumerator Temporizar()
    {
        if(audiomanager != null)
        {
            audiomanager.PlaySFX(audiomanager.timer);
        }            
        yield return new WaitForSeconds(20);
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff;
        temporizado.SetActive(false);
        if(audiomanager != null)
        {
           audiomanager.StopSFX(audiomanager.timer); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            temporizado.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
            activado.SetActive(false);
            StartCoroutine(Temporizar());
        }
    }

}
