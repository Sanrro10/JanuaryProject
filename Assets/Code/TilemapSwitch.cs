using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSwitch : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D tilemapCollider2D;
    [SerializeField] private Tile mediumLeft;
    [SerializeField] private Tile mediumMiddle;
    [SerializeField] private Tile mediumRight;
    [SerializeField] private Tile smallLeft;
    [SerializeField] private Tile smallMiddle;
    [SerializeField] private Tile smallRight;
    [SerializeField] private Tile bigTopLeft;
    [SerializeField] private Tile bigTopMiddle;
    [SerializeField] private Tile bigTopRight;
    [SerializeField] private Tile bigMiddleLeft;
    [SerializeField] private Tile bigMiddleMiddle;
    [SerializeField] private Tile bigMiddleRight;
    [SerializeField] private Tile bigBottomLeft;
    [SerializeField] private Tile bigBottomMiddle;
    [SerializeField] private Tile bigBottomRight;
    [SerializeField] private Tile topSpikes;
    [SerializeField] private Tile leftSpikes;
    [SerializeField] private Tile rightSpikes;
    [SerializeField] private Tile bottomSpikes;
    [SerializeField] private Tile mediumLeftAlt;
    [SerializeField] private Tile mediumMiddleAlt;
    [SerializeField] private Tile mediumRightAlt;
    [SerializeField] private Tile smallLeftAlt;
    [SerializeField] private Tile smallMiddleAlt;
    [SerializeField] private Tile smallRightAlt;
    [SerializeField] private Tile bigTopLeftAlt;
    [SerializeField] private Tile bigTopMiddleAlt;
    [SerializeField] private Tile bigTopRightAlt;
    [SerializeField] private Tile bigMiddleLeftAlt;
    [SerializeField] private Tile bigMiddleMiddleAlt;
    [SerializeField] private Tile bigMiddleRightAlt;
    [SerializeField] private Tile bigBottomLeftAlt;
    [SerializeField] private Tile bigBottomMiddleAlt;
    [SerializeField] private Tile bigBottomRightAlt;
    [SerializeField] private Tile topSpikesAlt;
    [SerializeField] private Tile leftSpikesAlt;
    [SerializeField] private Tile rightSpikesAlt;
    [SerializeField] private Tile bottomSpikesAlt;

    public void Swap(bool active)
    {
        if (!active)
        {
            tilemap.SwapTile(mediumLeft, mediumLeftAlt);
            tilemap.SwapTile(mediumMiddle, mediumMiddleAlt);
            tilemap.SwapTile(mediumRight, mediumRightAlt);
            tilemap.SwapTile(smallLeft, smallLeftAlt);
            tilemap.SwapTile(smallMiddle, smallMiddleAlt);
            tilemap.SwapTile(smallRight, smallRightAlt);
            tilemap.SwapTile(bigTopLeft, bigTopLeftAlt);
            tilemap.SwapTile(bigTopMiddle, bigTopMiddleAlt);
            tilemap.SwapTile(bigTopRight, bigTopRightAlt);
            tilemap.SwapTile(bigMiddleLeft, bigMiddleLeftAlt);
            tilemap.SwapTile(bigMiddleMiddle, bigMiddleMiddleAlt);
            tilemap.SwapTile(bigMiddleRight, bigMiddleRightAlt);
            tilemap.SwapTile(bigBottomLeft, bigBottomLeftAlt);
            tilemap.SwapTile(bigBottomMiddle, bigBottomMiddleAlt);
            tilemap.SwapTile(bigBottomRight, bigBottomRightAlt);
            tilemap.SwapTile(topSpikes, topSpikesAlt);
            tilemap.SwapTile(leftSpikes, leftSpikesAlt);
            tilemap.SwapTile(rightSpikes, rightSpikesAlt);
            tilemap.SwapTile(bottomSpikes, bottomSpikesAlt);
        }else{
            tilemap.SwapTile(mediumLeftAlt, mediumLeft);
            tilemap.SwapTile(mediumMiddleAlt, mediumMiddle);
            tilemap.SwapTile(mediumRightAlt, mediumRight);
            tilemap.SwapTile(smallLeftAlt, smallLeft);
            tilemap.SwapTile(smallMiddleAlt, smallMiddle);
            tilemap.SwapTile(smallRightAlt, smallRight);
            tilemap.SwapTile(bigTopLeftAlt, bigTopLeft);
            tilemap.SwapTile(bigTopMiddleAlt, bigTopMiddle);
            tilemap.SwapTile(bigTopRightAlt, bigTopRight);
            tilemap.SwapTile(bigMiddleLeftAlt, bigMiddleLeft);
            tilemap.SwapTile(bigMiddleMiddleAlt, bigMiddleMiddle);
            tilemap.SwapTile(bigMiddleRightAlt, bigMiddleRight);
            tilemap.SwapTile(bigBottomLeftAlt, bigBottomLeft);
            tilemap.SwapTile(bigBottomMiddleAlt, bigBottomMiddle);
            tilemap.SwapTile(bigBottomRightAlt, bigBottomRight);
            tilemap.SwapTile(topSpikesAlt, topSpikes);
            tilemap.SwapTile(leftSpikesAlt, leftSpikes);
            tilemap.SwapTile(rightSpikesAlt, rightSpikes);
            tilemap.SwapTile(bottomSpikesAlt, bottomSpikes);
        }
        tilemapCollider2D.enabled = active;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
