using UnityEngine;
using UnityEngine.InputSystem;

public class gotascontroller : MonoBehaviour
{
    GameObject pez;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            pez = collision.gameObject;
        }
        else
        {
            pez.GetComponent<FishMovement>().SetDrops(false);
            pez.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }


}
