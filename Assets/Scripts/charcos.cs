using System;
using System.Collections;
using UnityEngine;

public class charcos : MonoBehaviour
{
    [SerializeField] private GameObject charco;

    private bool isOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Timer()
    {
        charco.SetActive(true);
        yield return new WaitForSeconds(5);
        charco.SetActive(true);

    }
}
