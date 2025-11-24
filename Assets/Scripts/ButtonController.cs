using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject activado;
    [SerializeField] private Sprite buttonOn;

    void Start()
    {
        activado.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activado.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
        }
        

    }
}
