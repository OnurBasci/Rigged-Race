using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            character_movment.weapon_number++;
        }
        Destroy(gameObject);
    }
}
