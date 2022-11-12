using System.Collections;
using UnityEngine;

public class character_movment : MonoBehaviour
{
    public float speed = 10f;
    public float inverse_value = 10f;
    public float jump_force;
    public float check_radius;
    public LayerMask what_is_floor;
    public GameObject floor_check;
    public GameObject weapon;
    public static int weapon_number = 0;
    public GameObject spawn_point;

    float h_axe;
    Rigidbody2D rb;
    bool running = false;
    public static bool is_grounded;
    Animator animator;
    SpriteRenderer render;
    bool jumping = false;
    private int max_speed = 20;
    public static bool is_grounded2;  //for better jumping
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        h_axe = Input.GetAxisRaw("Horizontal");
        if (h_axe == 1)
        {
            inverse_value = -1;
            render.flipX = false;
        }
        if (h_axe == -1)
        {
            inverse_value = 1;
            render.flipX = true;
        }
        if(Mathf.Abs(rb.velocity.x) < 1)
        {
            running = false;
        }
        else
        {
            running = true;
        }
        Animation();
    }
    private void FixedUpdate()
    {
        move();
        jump_check();
        jump();
        if(Input.GetKeyDown("e") && weapon_number > 0)
        {
            firalt();
            weapon_number--;
        }
    }
    void move()
    {
        if(Mathf.Abs(rb.velocity.x) < max_speed)
        {
            if (h_axe != 0)
            {
                rb.AddForce(new Vector2(h_axe * speed * Time.fixedDeltaTime, 0));

            }
            else if (running)
            {
                rb.AddForce(new Vector2(inverse_value * speed * Time.fixedDeltaTime, 0));
            }
        }
    }
    void jump()
    {
        if(Input.GetButtonDown("Jump") && is_grounded2)
        {
            rb.AddForce(new Vector2(0, jump_force));
            StartCoroutine("JUmp_check");
            is_grounded2 = false;
        }
    }
    void jump_check()
    {
        is_grounded = Physics2D.OverlapCircle(floor_check.transform.position, check_radius, what_is_floor);
        if(is_grounded)
        {
            jumping = false;
            max_speed = 20;
        }
        else
        {
            max_speed = 5;
        }
    }
    IEnumerator JUmp_check()
    {
        yield return new WaitForSeconds(0.1f);
        jumping = true;
    }
    void Animation()
    {
        if (jumping)
        {

            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }
    void firalt()
    {
        Instantiate(weapon, spawn_point.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "floor")
        {
            is_grounded2 = true;
        }
    }
}
