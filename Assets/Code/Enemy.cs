using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public EdgeCollider2D edgeCollider;
    public GameObject waypoint1;
    public GameObject waypoint2;
    private bool isMovingToWaypoint1 = true;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        //waypoint1.GetComponent<SpriteRenderer>().enabled = false;
        //waypoint2.GetComponent<SpriteRenderer>().enabled = false;
        target = waypoint1.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Debug.Log("Moving to waypoint 1. Position: " + transform.position + " Target: " + target + " Distance: " + Vector2.Distance(transform.position, target));
    }

    // Update is called once per frame
    void Update()
    {
        if(edgeCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Debug.Log("Player is touching enemy");
        }
        if(Vector2.Distance(transform.position, target) < 0.1f){

            if(isMovingToWaypoint1){
                target = waypoint2.transform.position;
                isMovingToWaypoint1 = false;
                Debug.Log("Moving to waypoint 2. Position: " + transform.position + " Target: " + target + " Distance: " + Vector2.Distance(transform.position, target));
            }else{
                target = waypoint1.transform.position;
                isMovingToWaypoint1 = true;
                Debug.Log("Moving to waypoint 1. Position: " + transform.position + " Target: " + target + " Distance: " + Vector2.Distance(transform.position, target));
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

    }
}
