using UnityEngine;
using System.Collections;

public class Rockmovement : MonoBehaviour
{
    private float tumble = 5;
    private float speed = 20;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        GetComponent<Rigidbody>().velocity = transform.forward * -speed;
    }
}