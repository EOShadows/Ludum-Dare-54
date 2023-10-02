using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawnrate = 3f;
    float nextspawntime = 0f;
    bool nextStage = false;
    Vector2 mouseInWorld;
    GameObject player;
    bool behindSpawn = false;
    Vector3 loc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        mouseInWorld = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Time.time > nextspawntime)
        {
            Spawn();
            nextspawntime = Time.time + spawnrate;
        }
        if(Time.time > 30f && !nextStage)
        {
            spawnrate -= 1;
            nextStage = true;   
        }
        
    }
    void Spawn()
    {
        Vector2 playerpos = player.transform.position;
        if (!behindSpawn)
        {
            loc = ((Vector2)player.transform.position + (mouseInWorld - playerpos).normalized) * -8;
            behindSpawn = true;
        }
        else
        {
           loc = (Vector2)player.transform.position + ((mouseInWorld - playerpos).normalized) * 8;
            behindSpawn = false;
        }
        Instantiate(enemy, loc, Quaternion.Euler(0, 0, 0));
    }
}
