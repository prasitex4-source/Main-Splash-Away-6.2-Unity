using UnityEngine;

public class PalancaController : MonoBehaviour
{
    [SerializeField] private GameObject palanca;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        palanca.GetComponent<CapsuleCollider2D>().enabled = true;
          
    }
}
