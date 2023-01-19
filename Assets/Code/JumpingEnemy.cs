using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public float jumpForce;

    public float triggerDistance;
    public EdgeCollider2D edgeCollider;
    public Rigidbody2D rb;

    private GameController gameController;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = gameController.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(edgeCollider.IsTouching(player.GetPLayerCollider()))
        {
            gameController.Die();
        }
        if(edgeCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            if(Vector2.Distance(transform.position, player.transform.position) <= triggerDistance){
                
                if(Physics2D.Raycast(transform.position, -transform.position + player.transform.position).rigidbody == player.GetPlayerRigidbody()){
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
        }
    }
}
