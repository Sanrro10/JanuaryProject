using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSwitch : MonoBehaviour
{
    public enum TilemapType
    {
        Spikes,
        Terrain
    }
    public TilemapType tilemapType;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile blueMediumLeft;
    [SerializeField] private Tile blueMediumMiddle;
    [SerializeField] private Tile blueMediumRight;
    [SerializeField] private Tile blueSmallLeft;
    [SerializeField] private Tile blueSmallMiddle;
    [SerializeField] private Tile blueSmallRight;
    [SerializeField] private Tile blueBigTopLeft;
    [SerializeField] private Tile blueBigTopMiddle;
    [SerializeField] private Tile blueBigTopRight;
    [SerializeField] private Tile blueBigMiddleLeft;
    [SerializeField] private Tile blueBigMiddleMiddle;
    [SerializeField] private Tile blueBigMiddleRight;
    [SerializeField] private Tile blueBigBottomLeft;
    [SerializeField] private Tile blueBigBottomMiddle;
    [SerializeField] private Tile blueBigBottomRight;
    [SerializeField] private Tile blueTopSpikes;
    [SerializeField] private Tile blueLeftSpikes;
    [SerializeField] private Tile blueRightSpikes;
    [SerializeField] private Tile blueBottomSpikes;
    [SerializeField] private Tile blueMediumLeftAlt;
    [SerializeField] private Tile blueMediumMiddleAlt;
    [SerializeField] private Tile blueMediumRightAlt;
    [SerializeField] private Tile blueSmallLeftAlt;
    [SerializeField] private Tile blueSmallMiddleAlt;
    [SerializeField] private Tile blueSmallRightAlt;
    [SerializeField] private Tile blueBigTopLeftAlt;
    [SerializeField] private Tile blueBigTopMiddleAlt;
    [SerializeField] private Tile blueBigTopRightAlt;
    [SerializeField] private Tile blueBigMiddleLeftAlt;
    [SerializeField] private Tile blueBigMiddleMiddleAlt;
    [SerializeField] private Tile blueBigMiddleRightAlt;
    [SerializeField] private Tile blueBigBottomLeftAlt;
    [SerializeField] private Tile blueBigBottomMiddleAlt;
    [SerializeField] private Tile blueBigBottomRightAlt;
    [SerializeField] private Tile blueTopSpikesAlt;
    [SerializeField] private Tile blueLeftSpikesAlt;
    [SerializeField] private Tile blueRightSpikesAlt;
    [SerializeField] private Tile blueBottomSpikesAlt;
    [SerializeField] private Tile orangeMediumLeft;
    [SerializeField] private Tile orangeMediumMiddle;
    [SerializeField] private Tile orangeMediumRight;
    [SerializeField] private Tile orangeSmallLeft;
    [SerializeField] private Tile orangeSmallMiddle;
    [SerializeField] private Tile orangeSmallRight;
    [SerializeField] private Tile orangeBigTopLeft;
    [SerializeField] private Tile orangeBigTopMiddle;
    [SerializeField] private Tile orangeBigTopRight;
    [SerializeField] private Tile orangeBigMiddleLeft;
    [SerializeField] private Tile orangeBigMiddleMiddle;
    [SerializeField] private Tile orangeBigMiddleRight;
    [SerializeField] private Tile orangeBigBottomLeft;
    [SerializeField] private Tile orangeBigBottomMiddle;
    [SerializeField] private Tile orangeBigBottomRight;
    [SerializeField] private Tile orangeTopSpikes;
    [SerializeField] private Tile orangeLeftSpikes;
    [SerializeField] private Tile orangeRightSpikes;
    [SerializeField] private Tile orangeBottomSpikes;
    [SerializeField] private Tile orangeMediumLeftAlt;
    [SerializeField] private Tile orangeMediumMiddleAlt;
    [SerializeField] private Tile orangeMediumRightAlt;
    [SerializeField] private Tile orangeSmallLeftAlt;
    [SerializeField] private Tile orangeSmallMiddleAlt;
    [SerializeField] private Tile orangeSmallRightAlt;
    [SerializeField] private Tile orangeBigTopLeftAlt;
    [SerializeField] private Tile orangeBigTopMiddleAlt;
    [SerializeField] private Tile orangeBigTopRightAlt;
    [SerializeField] private Tile orangeBigMiddleLeftAlt;
    [SerializeField] private Tile orangeBigMiddleMiddleAlt;
    [SerializeField] private Tile orangeBigMiddleRightAlt;
    [SerializeField] private Tile orangeBigBottomLeftAlt;
    [SerializeField] private Tile orangeBigBottomMiddleAlt;
    [SerializeField] private Tile orangeBigBottomRightAlt;
    [SerializeField] private Tile orangeTopSpikesAlt;
    [SerializeField] private Tile orangeLeftSpikesAlt;
    [SerializeField] private Tile orangeRightSpikesAlt;
    [SerializeField] private Tile orangeBottomSpikesAlt;

    public void Swap(bool activateOrange)
    {
        if (activateOrange)
        {
            if (tilemapType.Equals(TilemapType.Spikes))
            {
                tilemap.SwapTile(blueTopSpikes, blueTopSpikesAlt);
                tilemap.SwapTile(blueLeftSpikes, blueLeftSpikesAlt);
                tilemap.SwapTile(blueRightSpikes, blueRightSpikesAlt);
                tilemap.SwapTile(blueBottomSpikes, blueBottomSpikesAlt);
                tilemap.SwapTile(orangeTopSpikesAlt, orangeTopSpikes);
                tilemap.SwapTile(orangeLeftSpikesAlt, orangeLeftSpikes);
                tilemap.SwapTile(orangeRightSpikesAlt, orangeRightSpikes);
                tilemap.SwapTile(orangeBottomSpikesAlt, orangeBottomSpikes);
            }
            else
            {
                tilemap.SwapTile(blueMediumLeft, blueMediumLeftAlt);
                tilemap.SwapTile(blueMediumMiddle, blueMediumMiddleAlt);
                tilemap.SwapTile(blueMediumRight, blueMediumRightAlt);
                tilemap.SwapTile(blueSmallLeft, blueSmallLeftAlt);
                tilemap.SwapTile(blueSmallMiddle, blueSmallMiddleAlt);
                tilemap.SwapTile(blueSmallRight, blueSmallRightAlt);
                tilemap.SwapTile(blueBigTopLeft, blueBigTopLeftAlt);
                tilemap.SwapTile(blueBigTopMiddle, blueBigTopMiddleAlt);
                tilemap.SwapTile(blueBigTopRight, blueBigTopRightAlt);
                tilemap.SwapTile(blueBigMiddleLeft, blueBigMiddleLeftAlt);
                tilemap.SwapTile(blueBigMiddleMiddle, blueBigMiddleMiddleAlt);
                tilemap.SwapTile(blueBigMiddleRight, blueBigMiddleRightAlt);
                tilemap.SwapTile(blueBigBottomLeft, blueBigBottomLeftAlt);
                tilemap.SwapTile(blueBigBottomMiddle, blueBigBottomMiddleAlt);
                tilemap.SwapTile(blueBigBottomRight, blueBigBottomRightAlt);
                tilemap.SwapTile(orangeMediumLeftAlt, orangeMediumLeft);
                tilemap.SwapTile(orangeMediumMiddleAlt, orangeMediumMiddle);
                tilemap.SwapTile(orangeMediumRightAlt, orangeMediumRight);
                tilemap.SwapTile(orangeSmallLeftAlt, orangeSmallLeft);
                tilemap.SwapTile(orangeSmallMiddleAlt, orangeSmallMiddle);
                tilemap.SwapTile(orangeSmallRightAlt, orangeSmallRight);
                tilemap.SwapTile(orangeBigTopLeftAlt, orangeBigTopLeft);
                tilemap.SwapTile(orangeBigTopMiddleAlt, orangeBigTopMiddle);
                tilemap.SwapTile(orangeBigTopRightAlt, orangeBigTopRight);
                tilemap.SwapTile(orangeBigMiddleLeftAlt, orangeBigMiddleLeft);
                tilemap.SwapTile(orangeBigMiddleMiddleAlt, orangeBigMiddleMiddle);
                tilemap.SwapTile(orangeBigMiddleRightAlt, orangeBigMiddleRight);
                tilemap.SwapTile(orangeBigBottomLeftAlt, orangeBigBottomLeft);
                tilemap.SwapTile(orangeBigBottomMiddleAlt, orangeBigBottomMiddle);
                tilemap.SwapTile(orangeBigBottomRightAlt, orangeBigBottomRight);
            }
        }
        else
        {
            if (tilemapType.Equals(TilemapType.Spikes))
            {
                tilemap.SwapTile(orangeTopSpikes, orangeTopSpikesAlt);
                tilemap.SwapTile(orangeLeftSpikes, orangeLeftSpikesAlt);
                tilemap.SwapTile(orangeRightSpikes, orangeRightSpikesAlt);
                tilemap.SwapTile(orangeBottomSpikes, orangeBottomSpikesAlt);
                tilemap.SwapTile(blueTopSpikesAlt, blueTopSpikes);
                tilemap.SwapTile(blueLeftSpikesAlt, blueLeftSpikes);
                tilemap.SwapTile(blueRightSpikesAlt, blueRightSpikes);
                tilemap.SwapTile(blueBottomSpikesAlt, blueBottomSpikes);
            }
            else
            {
                tilemap.SwapTile(orangeMediumLeft, orangeMediumLeftAlt);
                tilemap.SwapTile(orangeMediumMiddle, orangeMediumMiddleAlt);
                tilemap.SwapTile(orangeMediumRight, orangeMediumRightAlt);
                tilemap.SwapTile(orangeSmallLeft, orangeSmallLeftAlt);
                tilemap.SwapTile(orangeSmallMiddle, orangeSmallMiddleAlt);
                tilemap.SwapTile(orangeSmallRight, orangeSmallRightAlt);
                tilemap.SwapTile(orangeBigTopLeft, orangeBigTopLeftAlt);
                tilemap.SwapTile(orangeBigTopMiddle, orangeBigTopMiddleAlt);
                tilemap.SwapTile(orangeBigTopRight, orangeBigTopRightAlt);
                tilemap.SwapTile(orangeBigMiddleLeft, orangeBigMiddleLeftAlt);
                tilemap.SwapTile(orangeBigMiddleMiddle, orangeBigMiddleMiddleAlt);
                tilemap.SwapTile(orangeBigMiddleRight, orangeBigMiddleRightAlt);
                tilemap.SwapTile(orangeBigBottomLeft, orangeBigBottomLeftAlt);
                tilemap.SwapTile(orangeBigBottomMiddle, orangeBigBottomMiddleAlt);
                tilemap.SwapTile(orangeBigBottomRight, orangeBigBottomRightAlt);
                tilemap.SwapTile(blueMediumLeftAlt, blueMediumLeft);
                tilemap.SwapTile(blueMediumMiddleAlt, blueMediumMiddle);
                tilemap.SwapTile(blueMediumRightAlt, blueMediumRight);
                tilemap.SwapTile(blueSmallLeftAlt, blueSmallLeft);
                tilemap.SwapTile(blueSmallMiddleAlt, blueSmallMiddle);
                tilemap.SwapTile(blueSmallRightAlt, blueSmallRight);
                tilemap.SwapTile(blueBigTopLeftAlt, blueBigTopLeft);
                tilemap.SwapTile(blueBigTopMiddleAlt, blueBigTopMiddle);
                tilemap.SwapTile(blueBigTopRightAlt, blueBigTopRight);
                tilemap.SwapTile(blueBigMiddleLeftAlt, blueBigMiddleLeft);
                tilemap.SwapTile(blueBigMiddleMiddleAlt, blueBigMiddleMiddle);
                tilemap.SwapTile(blueBigMiddleRightAlt, blueBigMiddleRight);
                tilemap.SwapTile(blueBigBottomLeftAlt, blueBigBottomLeft);
                tilemap.SwapTile(blueBigBottomMiddleAlt, blueBigBottomMiddle);
                tilemap.SwapTile(blueBigBottomRightAlt, blueBigBottomRight);
            }

        }
    }
    public Tilemap GetTilemap()
    {
        return tilemap;
    }
}
