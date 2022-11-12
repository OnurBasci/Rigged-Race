using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_episode : MonoBehaviour
{
    public GameObject win_text, yeniden_dene, sonraki_bolum;
    public GameObject lose_text;

    BoxCollider2D bc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "character")
        {
            win_text.SetActive(true);
            sonraki_bolum.SetActive(true);
            bc = gameObject.GetComponent<BoxCollider2D>();
            bc.enabled = false;
        }
        else if(collision.gameObject.layer == 10)
        {
            lose_text.SetActive(true);
            yeniden_dene.SetActive(true);
            bc = gameObject.GetComponent<BoxCollider2D>();
            bc.enabled = false;
        }

    }

}
