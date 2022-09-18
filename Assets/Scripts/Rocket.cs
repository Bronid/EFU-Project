using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float RocketSpeed;
    public GameObject explosion;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * RocketSpeed * Time.deltaTime);
        if (this.gameObject.transform.position.y < 0)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

}
