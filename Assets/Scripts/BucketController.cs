using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public class BucketController : MonoBehaviour
{
    [Header("Dentro Cubo")]
    [SerializeField] private GameObject pez;
    [SerializeField] private GameObject positionFish;
    [SerializeField] private int timer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pez.gameObject.GetComponent<FishMovement>().SetBucket(true);
            pez.gameObject.GetComponent<FishMovement>().SetBucket(gameObject);
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
        transform.rotation = Quaternion.Euler(0f, 0f, -90.0f);
    }

    public void PushLeft()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90.0f);
    }


}
