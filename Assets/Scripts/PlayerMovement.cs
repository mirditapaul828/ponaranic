using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Transform Player;
    public float speed = 2f;
    private float minDistance = 0.2f;
    private float range;

    Vector2 movement;


    void Update()
    {
        Player = GameObject.FindWithTag("Coin").transform;
        range = Vector2.Distance(transform.position, Player.position);
        if (range > minDistance)
        {
            Debug.Log(range);
            Player = GameObject.FindWithTag("Coin").transform;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }



        // moves the enemy charcter from his position towoards the targets postion at a certain speed
        // Time.delta.Time allows to make sure that the faster  and more performance computer dont have an eney running alot faster then the enemy on a  slower computer  
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);


        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        direction.Normalize();
        movement = direction;
        //movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {

            target.gameObject.SetActive(false);

        }

    



    }

}
