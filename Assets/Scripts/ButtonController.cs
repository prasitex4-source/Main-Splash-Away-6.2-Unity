using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject activado;
    [SerializeField] private GameObject desactivado;
    [SerializeField] private Sprite buttonOn;

    void Start()
    {
        if(activado != null)
        {
            activado.SetActive(true);
        }
        
        if(desactivado != null) 
        {
            desactivado.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(activado != null)
            {
                activado.SetActive(false);
            }
            if(desactivado != null)
            {
                desactivado.SetActive(true);
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
        }
        

    }
}
