using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject activado;
    [SerializeField] private GameObject desactivado;
    [SerializeField] private Sprite buttonOn;
    private Sprite buttonOff;
    [HideInInspector] public bool isOn = false;
    [HideInInspector] public bool isDoorActivated = false;
    [HideInInspector] public bool isdoorDeactivated = true;

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
        buttonOff = GetComponent<SpriteRenderer>().sprite;
    }

    public void RestartButton()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOff;
        if(activado != null)
        {
            activado.SetActive(true);
        }
        if(desactivado != null)
        {
            desactivado.SetActive(false);
        }      
        isOn = false;
        isDoorActivated = false;
        isdoorDeactivated = true;
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
