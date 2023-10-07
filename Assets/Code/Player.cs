using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    // Player properties
    public float playerSpeed;
    public float jumpForce;
    private Vector2 playerDirection = Vector2.right;

    // References
    private Rigidbody2D rb;
    private GameController gameController;

    [Header("Colliders")]
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CapsuleCollider2D leftCollider;
    [SerializeField] private CapsuleCollider2D rightCollider;
    [SerializeField] private CapsuleCollider2D leftColliderTrigger;
    [SerializeField] private CapsuleCollider2D rightColliderTrigger;
    [SerializeField] private CapsuleCollider2D upperCollider;

    [Header("Jump Handling")]
    [SerializeField] private JumpButtonHandler jumpButtonHandler;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    [Header("Sound")]
    public OptionsMenu optionsM;
    private bool isJumpingAudio = false;

    // Constants
    private const string GroundLayer = "Ground";
    private const string PlayerJumpSound = "player_jump";

    private void Start()
    {
        optionsM.Initialize();
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rightColliderTrigger.enabled = true;
        leftColliderTrigger.enabled = false;
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        HandleJump();
    }
    
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, rb.velocity.y);
    }
    
    private float holdDelay = 0.1f;  // Add this delay variable
    private float timeSinceJumpPressed = 0;  // To track the time since the jump button was pressed.

    private void HandleJump()
    {
        if (jumpButtonHandler.GetIsPressed() && !isJumping)
        {
            StartJump();
            timeSinceJumpPressed = 0;  // Reset the timer when the jump is pressed.
        }

        timeSinceJumpPressed += Time.deltaTime;  // Increment the timer.
    
        // Only allow continuous jump if the hold delay has passed.
        if (jumpButtonHandler.GetIsHold() && isJumping && timeSinceJumpPressed > holdDelay)
        {
            ContinueJump();
        }

        if (!jumpButtonHandler.GetIsHold())
        {
            isJumping = false;
            isJumpingAudio = false;
        }
    }


    private void StartJump()
    {
        if (CanJumpFromGround() || CanJumpFromSide())
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            if (!isJumpingAudio)
            {
                AudioManager.Instance.PlaySFX(PlayerJumpSound);
                isJumpingAudio = true;
            }
        }
    }

    private void ContinueJump()
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

    private bool CanJumpFromGround()
    {
        return rb.IsTouchingLayers(LayerMask.GetMask(GroundLayer)) && !upperCollider.IsTouchingLayers(LayerMask.GetMask(GroundLayer));
    }

    private bool CanJumpFromSide()
    {
        if (leftColliderTrigger.IsTouchingLayers(LayerMask.GetMask(GroundLayer)) && playerDirection == Vector2.left)
        {
            SwitchDirectionToLeft();
            return true;
        }
        else if (rightColliderTrigger.IsTouchingLayers(LayerMask.GetMask(GroundLayer)) && playerDirection == Vector2.right)
        {
            SwitchDirectionToRight();
            return true;
        }
        return false;
    }

    private void SwitchDirectionToLeft()
    {
        playerDirection = Vector2.left;
        leftColliderTrigger.enabled = false;
        rightColliderTrigger.enabled = true;
    }

    private void SwitchDirectionToRight()
    {
        playerDirection = Vector2.right;
        rightColliderTrigger.enabled = false;
        leftColliderTrigger.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GroundLayer))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Tilemap map = contact.collider.GetComponent<Tilemap>();
                if(map == null) continue;
                if (map == gameController.GetVictoryTilemap() && !upperCollider.IsTouchingLayers(LayerMask.GetMask(GroundLayer)))
                {
                    gameController.Win();
                }
                else if(map == gameController.GetSpikeTilemap())
                {
                    Die();
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GroundLayer))
        {
            Tilemap map = collision.GetComponent<Tilemap>();
            if(map != null)
            {
                if (map == gameController.GetSpikeTilemap())
                {
                    Die();
                }
            }

            if (rightCollider.IsTouchingLayers(LayerMask.GetMask(GroundLayer)))
            {
                SwitchDirectionToLeft();
            }
            else if (leftCollider.IsTouchingLayers(LayerMask.GetMask(GroundLayer)))
            {
                SwitchDirectionToRight();
            }
        }
    }



    public void Die()
    {
        gameController.Die();
    }

    // Utility methods
    public Vector2 GetPlayerDirection()
    {
        return playerDirection;
    }

    public CircleCollider2D GetPlayerCollider()
    {
        return circleCollider;
    }

    public Rigidbody2D GetPlayerRigidbody()
    {
        return rb;
    }

}
