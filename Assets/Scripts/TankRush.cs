using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRush : MonoBehaviour
{
    [SerializeField] private int tankSpeed;
    void Start()
    {

    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime);
    }
}
