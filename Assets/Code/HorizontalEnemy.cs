using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class HorizontalEnemy : MonoBehaviour
{
    [SerializeField] private StartingPosition startingPosition;
    [SerializeField] private int size;
    [SerializeField] private float speed;
    [SerializeField] private Tile leftLimitTile;
    [SerializeField] private Tile rightLimitTile;
    [SerializeField] private Tile oddRightRightTile;
    [SerializeField] private Tile oddRightLeftTile;
    [SerializeField] private Tile oddLeftRightTile;
    [SerializeField] private Tile oddLeftLeftTile;
    [SerializeField] private Tile centralTile;
    private Tilemap tilemap;
    private enum StartingPosition
    {
        Left,
        Right
    }
    private SpriteRenderer spriteRenderer;
    private Vector3 center;
    private Vector3 leftlimit;
    private Vector3 rightlimit;
    [SerializeField] private EdgeCollider2D leftCollider;
    [SerializeField] private EdgeCollider2D rightCollider;
    private Rigidbody2D rb;

    private GameController gameController;
    private Player player;
    private bool moving;
    private bool changingColor;
    private bool isLeft;
    [SerializeField] private float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = gameController.GetPlayer();
        tilemap = GameObject.Find("MainTilemap").GetComponent<Tilemap>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        center = transform.position;
        float halfSize = (float) size / (float) 2;
        leftlimit = new Vector3(center.x - halfSize, center.y, center.z);
        rightlimit = new Vector3(center.x + halfSize, center.y, center.z);
        tilemap.SetTile(tilemap.WorldToCell(center), centralTile);
        if (size % 2 == 0)
        {
            tilemap.SetTile(tilemap.WorldToCell(new Vector3(leftlimit.x - 1, center.y, leftlimit.z)), oddLeftLeftTile);
            tilemap.SetTile(tilemap.WorldToCell(new Vector3(leftlimit.x, center.y, leftlimit.z)), oddLeftRightTile);
            tilemap.SetTile(tilemap.WorldToCell(new Vector3(rightlimit.x - 1, rightlimit.y, center.z)), oddRightLeftTile);
            tilemap.SetTile(tilemap.WorldToCell(new Vector3(rightlimit.x, rightlimit.y, center.z)), oddRightRightTile);
            for (int i = 1; i < (halfSize) - 1; i++)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x - i, center.y, center.z)), centralTile);
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x + i, center.y, center.z)), centralTile);
            }
            if(size>=5){
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(leftlimit.x + 1, center.y, leftlimit.z)), centralTile);
            }
        }
        else
        {
            tilemap.SetTile(tilemap.WorldToCell(leftlimit), leftLimitTile);
            tilemap.SetTile(tilemap.WorldToCell(rightlimit), rightLimitTile);
            for (int i = 1; i < halfSize -1; i++)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x - i, center.y, center.z)), centralTile);
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x + i, center.y, center.z)), centralTile);
            }
            if (size >= 5)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(leftlimit.x + 1, center.y, leftlimit.z)), centralTile);
            }

        }
        if (startingPosition == StartingPosition.Left)
        {
            transform.position = leftlimit;
            leftCollider.enabled = false;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
            isLeft = true;
        }
        else
        {
            transform.position = rightlimit;
            rightCollider.enabled = false;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
            isLeft = false;
        }
    }
    IEnumerator Move()
    {
        Vector3 target;
        if (isLeft)
        {
            target = rightlimit;
        }
        else
        {
            target = leftlimit;
        }
        while (moving)
        {
            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                transform.position = target;
                isLeft = !isLeft;
                changingColor = true;
                moving = false;
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        rightCollider.enabled = true;
        leftCollider.enabled = true;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (changingColor)
        {
            if (isLeft)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + (Time.deltaTime / fadeOutTime));
                if (spriteRenderer.color.a >= 1)
                {
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
                    leftCollider.enabled = false;
                    changingColor = false;
                }
                yield return null;
            }
            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - (Time.deltaTime / fadeOutTime));
                if (spriteRenderer.color.a <= 0)
                {
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                    rightCollider.enabled = false;
                    changingColor = false;
                }
                yield return null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftCollider.IsTouching(player.GetPLayerCollider()) || rightCollider.IsTouching(player.GetPLayerCollider()))
        {
            gameController.Die();
        }
        if (!moving && !changingColor)
        {
            if (Vector2.Distance(center, player.transform.position) <= (((float) size / 2) + 1))
            {
                if (Physics2D.Raycast(transform.position, -transform.position + player.transform.position).rigidbody == player.GetPlayerRigidbody())
                {
                    moving = true;
                    StartCoroutine(Move());
                }
            }
        }
    }
}
