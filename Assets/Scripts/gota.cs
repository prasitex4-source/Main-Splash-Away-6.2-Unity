using System.Data;
using UnityEngine;

public class gota : MonoBehaviour
{
    [SerializeField] public GameObject gotaPrefab;
    [SerializeField] private string waterTag;
    private bool TouchWater = false;

    void Start()
    {

    }

    void Update()
    {
        if (TouchWater == true)
        {
            Destroy(gotaPrefab);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(waterTag))
            TouchWater = true;
    }
}
