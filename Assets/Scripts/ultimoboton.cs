using UnityEngine;

public class ultimoboton : MonoBehaviour
{
    [SerializeField] private GameObject puerta;
    [SerializeField] private Sprite buttonOn;
    public bool isOn;

    void Start()
    {
        if (puerta != null)
        {
            puerta.SetActive(true);
            isOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (puerta != null)
            {
                puerta.SetActive(false);
                isOn = true;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
        }


    }
}
