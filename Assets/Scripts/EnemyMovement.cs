using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    // this variable will hold gameobject that our enemy is chasing after 
    public Transform target;
    //Self Ridgebody 2d attachment
    public Rigidbody2D rb;
    //Self Animation 
    public Animator animator;


    // stor both x and y for animation movement 
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //target is set to the tag of the player "player" !!!! MAKE SURE THE PLAYER HAS THE SAME TAG AS THE STING BELOW!!!
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves the enemy charcter from his position towoards the targets postion at a certain speed
        // Time.delta.Time allows to make sure that the faster  and more performance computer dont have an eney running alot faster then the enemy on a  slower computer  
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        //animation Instruction 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    //transforms the animation 
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed  * Time.deltaTime));
    }


}
