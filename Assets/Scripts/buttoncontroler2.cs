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


    void Start()
    {
        activado.SetActive(true);
        temporizado.SetActive(false);
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

    private IEnumerator Temporizar()
    {
        audiomanager.PlaySFX(audiomanager.timer);
        yield return new WaitForSeconds(20);
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff;
        temporizado.SetActive(false);
        audiomanager.StopSFX(audiomanager.timer);

    }
}
