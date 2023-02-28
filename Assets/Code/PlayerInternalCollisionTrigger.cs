using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInternalCollisionTrigger : MonoBehaviour
{
    private CircleCollider2D circleColliderTrigger;
    private GameController gameController;
    private void Start()
    {
        circleColliderTrigger = GetComponent<CircleCollider2D>();
        gameController = FindObjectOfType<GameController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.Die();
    }
}
