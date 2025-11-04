using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private Sprite buttonOn;

    void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        water.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;

    }
}
