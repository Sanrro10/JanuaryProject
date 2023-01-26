using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x;
    [SerializeField] private Player player;

    private void Update()
    {
        if(player.GetPlayerDirection() == Vector2.right)
            img.uvRect = new Rect(img.uvRect.position + new Vector2(x, img.uvRect.position.y) * Time.deltaTime, img.uvRect.size);
        if (player.GetPlayerDirection() == Vector2.left)
            img.uvRect = new Rect(img.uvRect.position + new Vector2(-x, img.uvRect.position.y) * Time.deltaTime, img.uvRect.size);
    }
}
