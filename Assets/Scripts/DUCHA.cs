using Unity.VisualScripting;
using UnityEngine;

public class DUCHA : MonoBehaviour
{
    [SerializeField] public GameObject gotaPrefab;
    [SerializeField] private Transform puntoGoteo;
    [SerializeField] private float cadencia = 1f;

    void Start()
    {
        InvokeRepeating(nameof(Gotear), cadencia, cadencia);
    }

    void Update()
    {
        
    }

    private void Gotear()
    {
        Instantiate(gotaPrefab, transform.position, Quaternion.identity);
    }
}
