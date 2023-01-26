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
    private List<Sprite> spikeSprites;
    private List<Sprite> victorySprites;
    private Vector2 playerDirection;

    public void Jump()
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        else
        {
            if (leftColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.AddForce(Vector2.up * jumpForce);
                if (playerDirection == Vector2.right)
                {
                    playerDirection = Vector2.left;
                }
            }
            else if (rightColliderTrigger.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.AddForce(Vector2.up * jumpForce);
                if (playerDirection == Vector2.left)
                {
                    playerDirection = Vector2.right;
                }
            }

        }
    }
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
        rb = GetComponent<Rigidbody2D>();
        playerDirection = Vector2.right;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        List<Tile> spikeTiles = gameController.GetSpikeTiles();
        Debug.Log("Spikes: " + spikeTiles.Count);
        spikeSprites = new List<Sprite>();
        foreach (Tile tile in spikeTiles)
        {
            spikeSprites.Add(tile.sprite);
        }
        victorySprites = new List<Sprite>();
        foreach (Tile tile in gameController.GetVictoryTiles())
        {
            victorySprites.Add(tile.sprite);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        { 
            foreach (ContactPoint2D contact in collision.contacts)
            {
                try
                {
                    Tilemap map = contact.collider.GetComponent<Tilemap>();
                    Debug.Log("Point: " + contact.point);
                    Debug.Log("Cell" + map.layoutGrid.WorldToCell(contact.point));
                    Debug.Log("Sprite: " + map.GetSprite(map.layoutGrid.WorldToCell(contact.point)));
                    if (spikeSprites.Contains(map.GetSprite(map.layoutGrid.WorldToCell(contact.point))))
                    {   Debug.Log("Spike");
                        gameController.Die();
                    } else if (victorySprites.Contains(map.GetSprite(map.layoutGrid.WorldToCell(contact.point))))
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
    }



    void FixedUpdate()
    {

    }
}
