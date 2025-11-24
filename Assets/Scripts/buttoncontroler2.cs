using UnityEngine;

public class buttoncontroler2 : MonoBehaviour
{
    [SerializeField] private GameObject activado1;
    [SerializeField] private GameObject activado2;
    [SerializeField] private Sprite buttonOn;

    private bool isOn = true;

    void Start()
    {
        activado1.SetActive(true);
        activado2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isOn)
            {
                activado2.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
            }

            else
            {
                activado1.SetActive(false);
                isOn = false;
            }
        }

    }
}
