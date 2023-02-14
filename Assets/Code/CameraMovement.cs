using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player player;
    private Camera cam;
    private float verticalThreshold;
    private float horizontalThreshold;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.2f;
    private Transform cameraTransform;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cameraTransform = transform;
        playerTransform = player.transform;
        horizontalThreshold = cam.orthographicSize * (float)0.7;
        verticalThreshold = cam.orthographicSize * (float)0.7;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetPlayerDirection() == Vector2.right)
        {
           Vector3 targetposition = playerTransform.position + new Vector3(horizontalThreshold, 0, -10f);
           targetposition.y = Mathf.Clamp(targetposition.y + (player.GetPlayerRigidbody().velocity.y * smoothTime), cameraTransform.position.y - verticalThreshold, cameraTransform.position.y + verticalThreshold);
           cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetposition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 targetposition = playerTransform.position + new Vector3(-horizontalThreshold, 0, -10f);
            targetposition.y = Mathf.Clamp(targetposition.y + (player.GetPlayerRigidbody().velocity.y * smoothTime), cameraTransform.position.y - verticalThreshold, cameraTransform.position.y + verticalThreshold);
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetposition, ref velocity, smoothTime);
        }

    }
}
