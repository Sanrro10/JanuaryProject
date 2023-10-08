using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class VerticalEnemy : MonoBehaviour
{
    [SerializeField] private StartingPosition startingPosition;
    [SerializeField] private int size;
    [SerializeField] private float speed;
    [SerializeField] private Tile centralTile;
    [SerializeField] private Tile upLimitTile;
    [SerializeField] private Tile downLimitTile;
    [SerializeField] private Tile oddUpUpTile;
    [SerializeField] private Tile oddUpDownTile;
    [SerializeField] private Tile oddDownUpTile;
    [SerializeField] private Tile oddDownDownTile;
    private Tilemap tilemap;
    private enum StartingPosition
    {
        Up,
        Down
    }
    private SpriteRenderer spriteRenderer;
    private Vector3 center;
    private Vector3 upperLimit;
    private Vector3 lowerLimit;
    [SerializeField] private EdgeCollider2D upperCollider;
    [SerializeField] private EdgeCollider2D lowerCollider;
    private Rigidbody2D rb;

    private GameController gameController;
    private Player player;
    private bool moving;
    private bool changingColor;
    private bool isUp;
    [SerializeField] private float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = gameController.GetPlayer();
        tilemap = GameObject.Find("MainTilemap").GetComponent<Tilemap>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeEnemyTiles();
    }

    private void InitializeEnemyTiles()
    {
        center = transform.position;
        float halfSize = (float)size / (float)2;
            upperLimit = new Vector3(center.x, center.y + halfSize, center.z);
            lowerLimit = new Vector3(center.x, center.y - halfSize, center.z);
            tilemap.SetTile(tilemap.WorldToCell(center), centralTile);
            if (size % 2 == 0)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, upperLimit.y - 1, upperLimit.z)), oddUpDownTile);
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, upperLimit.y, upperLimit.z)), oddUpUpTile);
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, lowerLimit.y, lowerLimit.z)), oddDownUpTile);
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, lowerLimit.y -1, lowerLimit.z)), oddDownDownTile);
                for (int i = 1; i < (halfSize) - 1; i++)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, center.y - i, center.z)), centralTile);
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, center.y + i, center.z)), centralTile);
                }
                if (size > 3)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, lowerLimit.y + 1, upperLimit.z)), centralTile);
                }
            }
            else
            {
                tilemap.SetTile(tilemap.WorldToCell(upperLimit), upLimitTile);
                tilemap.SetTile(tilemap.WorldToCell(lowerLimit), downLimitTile);
                for (int i = 1; i < halfSize - 1; i++)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, center.y - i, center.z)), centralTile);
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, center.y + i, center.z)), centralTile);
                }
                if (size >= 5)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, lowerLimit.y + 1, upperLimit.z)), centralTile);
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(center.x, upperLimit.y - 1, upperLimit.z)), centralTile);
                }
            }
            if(startingPosition == StartingPosition.Up)
            {
                transform.position = upperLimit;
                upperCollider.enabled = false;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
                isUp = true;
            }
            else
            {
                transform.position = lowerLimit;
                lowerCollider.enabled = false;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                isUp = false;
            }
    }
    IEnumerator Move()
    {
        Vector3 target;
        if (isUp)
        {
            target = lowerLimit;
        }
        else
        {
            target = upperLimit;
        }
        while (moving)
        {
            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                transform.position = target;
                isUp = !isUp;
                changingColor = true;
                moving = false;
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        upperCollider.enabled = true;
        lowerCollider.enabled = true;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (changingColor)
        {
            if (isUp)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + (Time.deltaTime / fadeOutTime));
                if (spriteRenderer.color.a >= 1)
                {
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
                    upperCollider.enabled = false;
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
                    lowerCollider.enabled = false;
                    changingColor = false;
                }
                yield return null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (upperCollider.IsTouching(player.GetPlayerCollider()) || lowerCollider.IsTouching(player.GetPlayerCollider()))
        {
            gameController.Die();
        }
        if (!moving && !changingColor)
        {           
            if (Vector2.Distance(center, player.transform.position) <= (((float) size / 2) + 1))
            {
                Debug.Log(Vector2.Distance(center, player.transform.position));
                if (Physics2D.Raycast(transform.position, -transform.position + player.transform.position).rigidbody == player.GetPlayerRigidbody())
                {
                    moving = true;
                    StartCoroutine(Move());
                }
            }
        }
    }
}
