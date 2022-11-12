using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_down_check : MonoBehaviour
{
    public BoxCollider2D collider2d;
    public GameObject[] floors;
    public obstacle_check forward_check;
    GameObject ignore_object;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ignore_object = collision.gameObject;
    }
    private void Update()
    {
        foreach (GameObject @object in floors)
        {
            if (@object == ignore_object)
            {
                if (forward_check.there_is_obstacle && gameObject.GetComponentInParent<ennemy_movement>().decide_prob < 50)
                {
                    Physics2D.IgnoreCollision(collider2d, @object.GetComponent<Collider2D>());
                    gameObject.GetComponentInParent<ennemy_movement>().decide_prob = 150;
                }
            }
        }
    }
}
