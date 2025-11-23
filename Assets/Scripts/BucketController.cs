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
            water.SetActive(true);
        }

        else if (cuboTipo == "izquierda")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90.0f);
        }

        else
        { }
       
    }

    public void PushLeft()
    {

        if (cuboTipo == "izquierda")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
            water.SetActive(true);
        }

        else if (cuboTipo == "derecha")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
        }

        else
        { }
    }


    void Start()
    {
        water.SetActive(false);
    }
}
