using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first_scene_manager : MonoBehaviour
{
    public GameObject[] ennemys;
    private void Update()
    {
        foreach(GameObject @object in ennemys)
        {
            if(@object.transform.position.x > -160)
            {
                @object.transform.position = new Vector2(-280, @object.transform.position.y);
            }
        }
    }
    public void next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
