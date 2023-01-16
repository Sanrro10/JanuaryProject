using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CapsuleCollider2D leftCollider;
    [SerializeField] private CapsuleCollider2D rightCollider;
    [SerializeField] private CapsuleCollider2D leftColliderTrigger;
    [SerializeField] private CapsuleCollider2D rightColliderTrigger;

    private Vector2 playerDirection;

    public void Jump(){
        Debug.Log("Jump");
        if(rb.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            rb.AddForce(Vector2.up * jumpForce);
        }else{
            if(leftColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground"))){
                rb.AddForce(Vector2.up * jumpForce);
                if(playerDirection == Vector2.right){
                    playerDirection = Vector2.left;
                }
                }else if(rightColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground"))){
                    rb.AddForce(Vector2.up * jumpForce);
                    if(playerDirection == Vector2.left){
                    playerDirection = Vector2.right;
                    }
                }

        }
    }
    public Vector2 GetPlayerDirection(){
        return playerDirection;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDirection = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {  
        if(rightCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            playerDirection = Vector2.left;
        }else if(leftCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            playerDirection = Vector2.right;
        }

        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);
    }

    

    void FixedUpdate(){
        
    }
}
