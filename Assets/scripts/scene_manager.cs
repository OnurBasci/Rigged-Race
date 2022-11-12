using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public GameObject[] spawn_points;
    public GameObject[] spawn_objects;
    public GameObject[] to_start_objects;
    public int spawn_time = 3;
    public GameObject Cam;
    public static bool start = false;
    bool start2 = false;
    Vector2 spawn_pos;

    bool spawned = false;
    private void Update()
    {
        if(!spawned && start2)
        {
            StartCoroutine("spawn");
        }
        if(start)
        {
            StartCoroutine("started");
            start = false;
        }
    }
    IEnumerator spawn()
    {
        spawned = true;
        int rand = Random.Range(1, 4);
        int rand_object = Random.Range(0, spawn_objects.Length);
        yield return new WaitForSeconds(spawn_time);
        if(spawn_objects.Length > 0)
        {
            switch (rand)
            {
                case 1:
                    spawn_pos = new Vector2(go_back.best.transform.position.x + 15, spawn_points[0].transform.position.y);
                    Instantiate(spawn_objects[rand_object], spawn_pos, Quaternion.identity);
                    break;
                case 2:
                    spawn_pos = new Vector2(go_back.best.transform.position.x + 15, spawn_points[1].transform.position.y);
                    Instantiate(spawn_objects[rand_object], spawn_pos, Quaternion.identity);
                    break;
                case 3:
                    spawn_pos = new Vector2(go_back.best.transform.position.x + 15, spawn_points[2].transform.position.y);
                    Instantiate(spawn_objects[rand_object], spawn_pos, Quaternion.identity);
                    break;
            }
        }

        spawned = false;
    }
    IEnumerator started()
    {
        yield return new WaitForSeconds(3);
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            to_start_objects[0].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[0].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<go_back>().enabled = true;  //respawn
            to_start_objects[2].GetComponent<character_movment>().enabled = true;  //character
            
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            to_start_objects[0].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[0].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[2].GetComponent<go_back>().enabled = true;  //respawn
            to_start_objects[3].GetComponent<character_movment>().enabled = true;  //character
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            to_start_objects[0].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[0].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[2].GetComponent<go_back>().enabled = true;  //respawn
            to_start_objects[3].GetComponent<character_movment>().enabled = true;  //character
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            to_start_objects[0].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[0].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[2].GetComponent<go_back>().enabled = true;  //respawn
            to_start_objects[3].GetComponent<character_movment>().enabled = true;  //character
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            to_start_objects[0].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[0].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[1].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[2].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[2].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[3].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[3].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[4].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[4].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[5].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[5].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[6].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[6].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[7].GetComponent<ennemy_movement>().enabled = true;  //ennemy
            to_start_objects[7].GetComponent<Animator>().enabled = true;  //ennemy
            to_start_objects[8].GetComponent<go_back>().enabled = true;  //respawn
            to_start_objects[9].GetComponent<character_movment>().enabled = true;  //character
        }
        start2 = true;
    }
    public void next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        start = false;
        start2 = false;
    }
    public void load_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        start = false;
        start2 = false;
    }
    public void play_again()
    {
        SceneManager.LoadScene(0);
        start = false;
        start2 = false;
    }
}
