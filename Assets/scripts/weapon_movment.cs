using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_movment : MonoBehaviour
{
    Vector2 dir = new Vector2(1, 0);
    int speed = 50;
    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<ennemy_movement>().enabled = false;
            collision.gameObject.GetComponent<Animator>().SetBool("fall", true);
        }
        Destroy(gameObject);
    }
}
