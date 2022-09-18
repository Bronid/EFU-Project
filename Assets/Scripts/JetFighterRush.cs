using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFighterRush : MonoBehaviour
{
    [SerializeField] private float JetSpeed;
    public GameObject rocket;

    void Start()
    {
        GameObject p = Instantiate(rocket, transform.position, transform.rotation);
        p.transform.Rotate(-10.0f, 0.0f, 0.0f, Space.World);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * JetSpeed * Time.deltaTime);
    }
}