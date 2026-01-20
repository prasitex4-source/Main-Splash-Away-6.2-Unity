using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public class BucketController : MonoBehaviour
{
    [Header("Dentro Cubo")]
    [SerializeField] private GameObject pez;
    [SerializeField] private GameObject positionFish;
    [SerializeField] private int timer;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject fishPlace;

    [Header("Tipocubo")]
    [SerializeField] private string cuboTipo;
    [SerializeField] public bool canFall = false;

    [SerializeField] private ultimoboton botoncito;
    [HideInInspector] public bool hasFallen = false;
    [HideInInspector] public bool waterActive = false;
    [HideInInspector] public Vector3 initialPosition;



    void Start()
    {
        if (water != null)
        {
            water.SetActive(false);
        }
        if (canFall)
        {
            initialPosition = transform.position;
        }      
    }

    public async void ReactivateCollider()
    {
        await Task.Delay(timer);
        GetComponent<Collider2D>().enabled = true;
    }

    public void PushRight()
    {
        if (cuboTipo == "derecha")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90.0f);
            if (water != null)
            {
                water.SetActive(true);
            }
            waterActive = true;
            hasFallen = true;
        }

        else if (cuboTipo == "final")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90.0f);

            if (botoncito.isOn == true)
            {
                if (water != null)
                {
                    water.SetActive(true);
                }
                waterActive = true;
            }

        }

        else if (cuboTipo == "izquierda")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90.0f);
            hasFallen = true;
        }
    }

    public void PushLeft()
    {

        if (cuboTipo == "izquierda")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
            if (water != null)
            {
                water.SetActive(true);
            }
            waterActive = true;
            hasFallen = true;
        }

        else if (cuboTipo == "derecha")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
            hasFallen = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pez.gameObject.GetComponent<FishMovement>().SetBucket(true);
            pez.gameObject.GetComponent<FishMovement>().SetBucket(gameObject);
            pez.gameObject.GetComponent<FishMovement>().SetFishPosition(fishPlace);
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void RestartBucket()
    {
        GetComponent<Collider2D>().enabled = true;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        hasFallen = false;
        waterActive = false;
        if (canFall)
        {
            transform.position = initialPosition;
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        }
        if (water != null)
        {
            water.SetActive(false);
        }
    }

}
