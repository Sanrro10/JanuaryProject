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
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        horizontalThreshold = cam.orthographicSize * (float) 0.5;
        Debug.Log("Horizontal threshold: " + horizontalThreshold);
        verticalThreshold = cam.orthographicSize * (float) 0.7;
        Debug.Log("Vertical threshold: " + verticalThreshold);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Direction: " + ((player.GetPlayerDirection() == Vector2.right) ? "Right " : "Left ") + "Distance: " + (cam.transform.position.x - player.transform.position.x) + "Threshold: " + horizontalThreshold);
        // if(player.GetPlayerDirection() == Vector2.right){
        //     if(cam.transform.position.x - player.transform.position.x > horizontalThreshold){
        //         cam.transform.position = new Vector3(player.transform.position.x - horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        //         Debug.Log("1");
        //     }else if(player.transform.position.x - cam.transform.position.x > horizontalThreshold){
        //         cam.transform.position = new Vector3(player.transform.position.x - horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        //         Debug.Log("2");
        //     }
        // }else{
        //     if(player.transform.position.x - cam.transform.position.x > horizontalThreshold){
        //         cam.transform.position = new Vector3(player.transform.position.x + horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        //         Debug.Log("3");
        //     }else if(cam.transform.position.x - player.transform.position.x > horizontalThreshold){
        //         cam.transform.position = new Vector3(player.transform.position.x + horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        //         Debug.Log("4");
        //     }
        // }

        // if(player.GetPlayerDirection() == Vector2.right){
        //     if(0<=(cam.transform.position.x - (player.transform.position.x + horizontalThreshold)) && 
        //     (cam.transform.position.x - (player.transform.position.x + horizontalThreshold)) <= cameraError){
        //         cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        //     }else{
        //         if(cam.transform.position.x - (player.transform.position.x + horizontalThreshold) <= cameraError){
        //             transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
        //         }else{
        //             //transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
        //         }
               
        //     }
        // }else{
        //     if(0<= cam.transform.position.x - (player.transform.position.x - horizontalThreshold) &&
        //     cam.transform.position.x - (player.transform.position.x - horizontalThreshold) <= cameraError){
        //         cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        //     }else{
        //         if(cam.transform.position.x - (player.transform.position.x - horizontalThreshold) <= cameraError){
        //             transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
        //         }else{
        //             //transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
        //         }               
        //     }
        //}

        if(player.GetPlayerDirection() == Vector2.right){
            if(player.transform.position.x >= cam.transform.position.x -horizontalThreshold + cameraError 
            && player.transform.position.x <= cam.transform.position.x -horizontalThreshold - cameraError){
                transform.Translate(player.GetPlayerDirection() * player.playerSpeed * Time.deltaTime);
                Debug.Log("En los márgenes");
            }else{
                if(player.transform.position.x > cam.transform.position.x -horizontalThreshold){
                    transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
                    Debug.Log("Fuera de los márgenes: Catch Up");
                }else{
                    Debug.Log("Fuera de los márgenes: Wait");
                }
            }
        }else{
            if(player.transform.position.x >= cam.transform.position.x + horizontalThreshold + cameraError  //Igual no hay que cambiar los signos
            && player.transform.position.x <= cam.transform.position.x + horizontalThreshold - cameraError){
                transform.Translate(player.GetPlayerDirection() * player.playerSpeed * Time.deltaTime);
                Debug.Log("En los márgenes");
            }else{
                if(player.transform.position.x < cam.transform.position.x + horizontalThreshold){
                    transform.Translate(player.GetPlayerDirection() * catchUpSpeed * player.playerSpeed * Time.deltaTime);
                    Debug.Log("Fuera de los márgenes: Catch Up");
                }else{
                    Debug.Log("Fuera de los márgenes: Wait");
                }
            }
        }
        

        if(cam.transform.position.y - player.transform.position.y > verticalThreshold){
            cam.transform.position = new Vector3(cam.transform.position.x, player.transform.position.y + verticalThreshold, cam.transform.position.z);
        }else if(player.transform.position.y - cam.transform.position.y > verticalThreshold){
            cam.transform.position = new Vector3(cam.transform.position.x, player.transform.position.y - verticalThreshold, cam.transform.position.z);
        }
    }
}
