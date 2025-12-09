using UnityEngine;

public class spawnerdrops : MonoBehaviour
{

    [SerializeField] GameObject dropInstance;
    [SerializeField] float timeToInstance = 5f;

    private float currentTime;

    void Start()
    {
        currentTime = timeToInstance;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Instantiate(dropInstance, transform.position, Quaternion.identity);
            currentTime = timeToInstance;
        }
    }
}
