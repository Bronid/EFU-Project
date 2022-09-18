using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuglasRush : MonoBehaviour
{
    [SerializeField] private float DuglasSpeed;
    public GameObject rocket;

    void Start()
    {
        GameObject p = Instantiate(rocket, transform.position, transform.rotation);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * DuglasSpeed * Time.deltaTime);
    }
}