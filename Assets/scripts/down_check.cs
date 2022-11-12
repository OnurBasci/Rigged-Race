using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_check : MonoBehaviour
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
        foreach (GameObject @object in floors)
        {
            if (@object == ignore_object)
            {
                if(Input.GetKeyDown("s"))
                {
                    Physics2D.IgnoreCollision(collider2d, @object.GetComponent<Collider2D>());
                }
            }
        }
    }
}
