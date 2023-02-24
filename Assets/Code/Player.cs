using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    private GameController gameController;
    private Vector2 playerDirection;

    //JumpButton
    [SerializeField] private JumpButtonHandler jumpButtonHandler;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    //Sound
    private bool isJumpingAudio = false;
    public OptionsMenu optionsM;

    //public void Jump()
    //{
    //    if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //    {
    //        rb.AddForce(Vector2.up * jumpForce);
    //    }
    //    else
    //    {
    //        if (leftColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //        {
    //            rb.AddForce(Vector2.up * jumpForce);
    //            if (playerDirection == Vector2.right)
    //            {
    //                playerDirection = Vector2.left;
    //            }
    //        }
    //        else if (rightColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //        {
    //            rb.AddForce(Vector2.up * jumpForce);
    //            if (playerDirection == Vector2.left)
    //            {
    //                playerDirection = Vector2.right;
    //            }
    //        }

    //    }
    //}
    public Vector2 GetPlayerDirection()
    {
        return playerDirection;
    }
    public CircleCollider2D GetPLayerCollider()
    {
        return circleCollider;
    }
    public Rigidbody2D GetPlayerRigidbody()
    {
        return rb;
    }
    // Start is called before the first frame update
    void Start()
    {
        optionsM.Inizialice();
        rb = GetComponent<Rigidbody2D>();
        playerDirection = Vector2.right;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                try
                {
                    Tilemap map = contact.collider.GetComponent<Tilemap>();
                    if (map == gameController.GetSpikeTilemap())
                    {
                        gameController.Die();
                    }
                    else if (map == gameController.GetVictoryTilemap())
                    {
                        gameController.Win();
                    }
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (rightCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                playerDirection = Vector2.left;
            }
            else if (leftCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                playerDirection = Vector2.right;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);
        /*
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")) && isJumping==false)
        {
            isJumpingAudio = false;
        }
        */
        if (jumpButtonHandler.GetIsPressed() || Input.GetKey(KeyCode.Space))
        {
            if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
                if (isJumpingAudio == false)
                {
                    AudioManager.Instance.PlaySFX("player_jump");
                    isJumpingAudio = true;
                }
            }
            else
            {
                if (leftColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")) && playerDirection == Vector2.left)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    if (playerDirection == Vector2.right)
                    {
                        playerDirection = Vector2.left;
                    }
                }
                else if (rightColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")) && playerDirection == Vector2.right)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    if (playerDirection == Vector2.left)
                    {
                        playerDirection = Vector2.right;
                    }
                }
            }
        }
        if (jumpButtonHandler.GetIsHold() && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                isJumpingAudio = false;
            }
        }

        if (!jumpButtonHandler.GetIsPressed())
        {
            isJumping = false;
            isJumpingAudio = false;
        }
    }
}
