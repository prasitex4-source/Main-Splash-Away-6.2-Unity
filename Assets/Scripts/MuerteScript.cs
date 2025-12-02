using UnityEngine;

public class MuerteScript : MonoBehaviour
{
    [SerializeField] public Collider2D muerte;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        muerte = GetComponent<Collider2D>();
    }
}
