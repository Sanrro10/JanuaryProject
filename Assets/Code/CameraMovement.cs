using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Camera cam;
    private float verticalThreshold;
    private float horizontalThreshold;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        horizontalThreshold = cam.orthographicSize * (float) 1.5;
        Debug.Log("Horizontal threshold: " + horizontalThreshold);
        verticalThreshold = cam.orthographicSize * (float) 0.7;
        Debug.Log("Horizontal threshold: " + verticalThreshold);
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.transform.position.x - player.position.x > horizontalThreshold){
            cam.transform.position = new Vector3(player.position.x + horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        }else if(player.position.x - cam.transform.position.x > horizontalThreshold){
            cam.transform.position = new Vector3(player.position.x - horizontalThreshold, cam.transform.position.y, cam.transform.position.z);
        }if(cam.transform.position.y - player.position.y > verticalThreshold){
            cam.transform.position = new Vector3(cam.transform.position.x, player.position.y + verticalThreshold, cam.transform.position.z);
        }else if(player.position.y - cam.transform.position.y > verticalThreshold){
            cam.transform.position = new Vector3(cam.transform.position.x, player.position.y - verticalThreshold, cam.transform.position.z);
        }
    }
}
