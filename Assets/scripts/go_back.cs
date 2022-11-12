using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_back : MonoBehaviour
{
    public GameObject[] characters;
    public float speed = 10;
    public Cinemachine.CinemachineVirtualCamera cam;
    public int get_object_time = 5;
    Vector3 go_to;
    public static Transform best;
    public static Transform worst;
    public GameObject isinlanma_effekti;
    public Transform isinlama_place;
    bool getting = false;
    bool get = false;
    private float current_time = 5;
    GameObject destroyed_object;
    bool isinladi = false;
    GameObject transportation;
    private void Awake()
    {
        current_time = get_object_time;
        worst = characters[0].GetComponent<Transform>();
    }
    private void Update()
    {
        choose_best();
        choose_worst();
        follow(best.gameObject);
        if(!isinladi)
        {
            annimation();
        }
        current_time -= Time.deltaTime;
    }
    void choose_best()
    {
        best = characters[0].GetComponent<Transform>();
        for(int i = 0; i < characters.Length; i++)
        {
            if(characters[i].GetComponent<Transform>().position.x > best.position.x)
            {
                best = characters[i].GetComponent<Transform>();
            }
        }
    }
    void choose_worst()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].GetComponent<Transform>().position.x < worst.position.x && characters[i] != destroyed_object)
            {
                worst = characters[i].GetComponent<Transform>();
            }
        }
    }
    void follow(GameObject to_follow_object)
    {
        if(!getting)
        {
            go_to = new Vector2(to_follow_object.transform.position.x, transform.position.y);
        }

        if(Vector2.Distance(go_to, transform.position) < 0.2 && getting)
        {
            able();
            current_time = get_object_time;
            getting = false;
            speed = 30;
            cam.m_Follow = characters[0].transform;
        }
        if (current_time <= 0)
        {
            if (get)
            {
                destroy();
            }
            if (destroyed_object == characters[0])
            {
                cam.m_Follow = gameObject.transform;
            }
            go_to = new Vector2(worst.transform.position.x - 10, transform.position.y);
            getting = true;
            speed = 20;
            isinladi = false;
            Destroy(transportation);
        }
        else if (current_time <= 1)
        {
            get = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, go_to, speed * Time.deltaTime);
    }
    void destroy()
    {
        destroyed_object = best.gameObject;
        if(destroyed_object.layer == 9)
        {
            destroyed_object.GetComponent<SpriteRenderer>().enabled = false;
            destroyed_object.GetComponent<character_movment>().enabled = false;
            destroyed_object.transform.position = new Vector2(-120, destroyed_object.transform.position.y);
        }
        if (destroyed_object.layer == 10)
        {
            destroyed_object.GetComponent<SpriteRenderer>().enabled = false;
            destroyed_object.GetComponent<ennemy_movement>().enabled = false;
            destroyed_object.transform.position = new Vector2(-120, destroyed_object.transform.position.y);
        }
        get = false;
    }
    void able()
    {
        if (destroyed_object.layer == 9)
        {
            destroyed_object.transform.position = new Vector2(gameObject.transform.position.x, destroyed_object.transform.position.y);
            destroyed_object.GetComponent<SpriteRenderer>().enabled = true;
            destroyed_object.GetComponent<character_movment>().enabled = true;
            destroyed_object.transform.position = new Vector2(gameObject.transform.position.x, 5);
        }
        if (destroyed_object.layer == 10)
        {
            destroyed_object.transform.position = new Vector2(gameObject.transform.position.x, destroyed_object.transform.position.y);
            destroyed_object.GetComponent<SpriteRenderer>().enabled = true;
            destroyed_object.GetComponent<ennemy_movement>().enabled = true;
            destroyed_object.GetComponent<ennemy_movement>().speed_limit = destroyed_object.GetComponent<ennemy_movement>().tmp_speed;
            destroyed_object.transform.position = new Vector2(gameObject.transform.position.x, 5);
        }
    }
    void annimation()
    {
        if(current_time <= 3 && current_time > 0)
        {
            transportation = Instantiate(isinlanma_effekti, isinlama_place.position, Quaternion.identity, transform);
            isinladi = true;
        }
    }
}
