using UnityEngine;

public class PalancaController : MonoBehaviour
{
    [SerializeField] private GameObject palanca;
    [SerializeField] private GameObject switched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        palanca.GetComponent<CapsuleCollider2D>().enabled = true;
        ActivateForm(switched);
        
    }
}
