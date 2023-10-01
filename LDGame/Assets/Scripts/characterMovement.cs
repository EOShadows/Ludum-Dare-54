using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    Direction direction;

    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        direction = GetComponent<Direction>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector2(speed * horizontal, speed * vertical);

        if(vertical != 0 || horizontal != 0)
            direction.setDirection(new Vector2(horizontal,vertical).normalized);
    }
}
