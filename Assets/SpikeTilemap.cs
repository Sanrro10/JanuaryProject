using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTilemap : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
                Debug.Log("Player died");
                other.gameObject.GetComponent<Player>().Die();
        }
    }
}
