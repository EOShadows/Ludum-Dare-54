using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private Vector2 current = Vector2.down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDirection(Vector2 direction)
    {
        current = direction;
    }

    public Vector2 getDirection()
    {
        return current;
    }
}
