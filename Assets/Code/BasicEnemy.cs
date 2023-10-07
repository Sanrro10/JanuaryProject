using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public EdgeCollider2D edgeCollider;
    public GameObject waypoint1;
    public GameObject waypoint2;
    private bool isMovingToWaypoint1 = true;
    private Vector2 target;
    private GameController gameController;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = gameController.GetPlayer();
        waypoint1.GetComponent<SpriteRenderer>().enabled = false;
        waypoint2.GetComponent<SpriteRenderer>().enabled = false;
        target = waypoint1.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(edgeCollider.IsTouching(player.GetPlayerCollider()))
        {
            gameController.Die();
        }
        if(Vector2.Distance(transform.position, target) < 0.1f){

            if(isMovingToWaypoint1){
                target = waypoint2.transform.position;
                isMovingToWaypoint1 = false;
            }else{
                target = waypoint1.transform.position;
                isMovingToWaypoint1 = true;
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
