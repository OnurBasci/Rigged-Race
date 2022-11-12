using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_check : MonoBehaviour
{
    public bool there_is_obstacle = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            gameObject.GetComponentInParent<ennemy_movement>().decide_prob = Random.Range(1,101);
            there_is_obstacle = true;
        }
    }
}
