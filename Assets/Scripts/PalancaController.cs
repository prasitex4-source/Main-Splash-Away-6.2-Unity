using UnityEngine;

public class PalancaController : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private GameObject palanca;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        palanca.GetComponent<CapsuleCollider2D>().enabled = true;
          
=======
    [SerializeField] private GameObject puerta;
    [SerializeField] private Sprite palancaAbierta;
    [SerializeField] private Sprite puertaAbierta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puerta.GetComponent<CapsuleCollider2D>().enabled = true;
        puerta.GetComponent<SpriteRenderer>().sprite = puertaAbierta;

        gameObject.GetComponent<SpriteRenderer>().sprite = palancaAbierta;
>>>>>>> Stashed changes
    }
}
