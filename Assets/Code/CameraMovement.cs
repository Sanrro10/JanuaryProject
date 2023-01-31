using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player player;
    private Camera cam;
    private float verticalThreshold;
    private float horizontalThreshold;

    public float cameraError = 1.5f;

    public float catchUpSpeed = 2f;
    private Transform cameraTransform;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cameraTransform = transform;
        playerTransform = player.transform;
        horizontalThreshold = cam.orthographicSize * (float) 0.5;
        verticalThreshold = cam.orthographicSize * (float) 0.7;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetPlayerDirection() == Vector2.right){
            if(playerTransform.position.x >= cameraTransform.position.x -horizontalThreshold + cameraError 
            && playerTransform.position.x <= cameraTransform.position.x -horizontalThreshold - cameraError){
                transform.Translate(player.GetPlayerDirection() * player.playerSpeed * Time.deltaTime);
            }else{
                if(playerTransform.position.x > cameraTransform.position.x -horizontalThreshold){
                    transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
                }
            }
        }else{
            if(playerTransform.position.x >= cameraTransform.position.x + horizontalThreshold + cameraError  //Igual no hay que cambiar los signos
            && playerTransform.position.x <= cameraTransform.position.x + horizontalThreshold - cameraError){
                transform.Translate(player.GetPlayerDirection() * player.playerSpeed * Time.deltaTime);
            }else{
                if(playerTransform.position.x < cameraTransform.position.x + horizontalThreshold){
                    transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
                }
            }
        }
        

        if(cameraTransform.position.y - playerTransform.position.y > verticalThreshold){
            cameraTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y + verticalThreshold, cameraTransform.position.z);
        }else if(playerTransform.position.y - cameraTransform.position.y > verticalThreshold){
            cameraTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y - verticalThreshold, cameraTransform.position.z);
        }
    }
}
