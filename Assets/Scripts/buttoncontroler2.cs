using System.Collections;
using UnityEngine;

public class buttoncontroler2 : MonoBehaviour
{
    [Header("Puertas")]
    [SerializeField] private GameObject activar;
    [SerializeField] private GameObject temporizado;

    [Header("Sprites")]
    [SerializeField] private Sprite buttonOn;
    [SerializeField] private Sprite buttonOff;

    [Header("Audio")]
    [SerializeField] audiomanager audiomanager;
    private bool sound = true;

    void Start()
    {
        activar.SetActive(true);
        temporizado.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activar.SetActive(false);
            temporizado.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
            audiomanager.PlaySFX(audiomanager.timer);
            StartCoroutine(Timer());
        }

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(20);
        audiomanager.StopSFX(audiomanager.timer);
        temporizado.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff;
    }


}
