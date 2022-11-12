using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_check : MonoBehaviour
{
    public BoxCollider2D collider2d;
    public GameObject[] floors;
    GameObject ignore_object;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ignore_object = collision.gameObject;
    }
    private void Update()
    {
        if(!character_movment.is_grounded)
        {
            foreach (GameObject @object in floors)
            {
                if (@object == ignore_object)
                {
                    Physics2D.IgnoreCollision(collider2d, @object.GetComponent<Collider2D>());
                }
                else
                {
                    Physics2D.IgnoreCollision(collider2d, @object.GetComponent<Collider2D>(), false);
                }
            }
        }
    }
}
