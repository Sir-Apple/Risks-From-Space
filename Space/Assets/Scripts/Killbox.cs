using UnityEngine;
using System.Collections;

public class Killbox : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}

