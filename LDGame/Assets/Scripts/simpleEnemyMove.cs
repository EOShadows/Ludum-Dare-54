using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemyMove : MonoBehaviour
{
    GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
