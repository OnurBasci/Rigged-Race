using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_movement : MonoBehaviour
{
    //ennemy always run to right
    //every indicated second it makes a decision --> jump or go down
    public float speed = 10f;
    public float speed_limit = 19;
    public float jump_force = 500;
    public float check_radius;
    public LayerMask what_is_floor;
    public GameObject floor_check;
    public GameObject forward_check;
    public int decide_prob = 50;

    [HideInInspector]
    public bool e_is_grounded;

    public float tmp_speed;
    float tmp_speed2;
    float actual_speed;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tmp_speed = speed_limit + 5;
        tmp_speed2 = speed_limit - 2;
        actual_speed = speed_limit;
    }
    private void FixedUpdate()
    {
        move();
        checks();
        Jump();
    }
    private void move()
    {

        if (Mathf.Abs(rb.velocity.x) < speed_limit)
        {
            rb.AddForce(new Vector2(speed * Time.fixedDeltaTime, 0));
        }
        if(go_back.best != null && gameObject == go_back.best.gameObject)
        {
            speed_limit = tmp_speed2;
        }
    }
    public void Jump()
    {
        if(e_is_grounded && forward_check.GetComponent<obstacle_check>().there_is_obstacle && decide_prob >= 50 && decide_prob <= 100 && transform.position.y > -3)
        {
            rb.AddForce(new Vector2(0, jump_force));
            forward_check.GetComponent<obstacle_check>().there_is_obstacle = false;
        }
        if(transform.position.y < -3 && decide_prob > 0 && decide_prob < 101 && e_is_grounded && forward_check.GetComponent<obstacle_check>().there_is_obstacle)
        {
            rb.AddForce(new Vector2(0, jump_force));
            forward_check.GetComponent<obstacle_check>().there_is_obstacle = false;
        }
    }
    void checks()
    {
        e_is_grounded = Physics2D.OverlapCircle(floor_check.transform.position, check_radius, what_is_floor);
    }
}
