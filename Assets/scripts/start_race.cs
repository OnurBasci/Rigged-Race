using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_race : MonoBehaviour
{
    public GameObject character;
    public GameObject go_321;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "character")
        {
            scene_manager.start = true;
            character.GetComponent<character_movment>().enabled = false;
            go_321.SetActive(true);
            StartCoroutine("delete");
        }
    }
    IEnumerator delete()
    {
        yield return new WaitForSeconds(4);
        go_321.SetActive(false);
    }
}
