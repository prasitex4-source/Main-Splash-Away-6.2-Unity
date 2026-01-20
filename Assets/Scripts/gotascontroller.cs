using UnityEngine;
using UnityEngine.InputSystem;

public class gotascontroller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }


}
