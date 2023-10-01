using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowMouse : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    public float scaleCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouse);
        transform.position = (scaleCam * (new Vector3(mouseWorld.x, mouseWorld.y, 0f) - transform.position)) + player.transform.position;
    }
}
