using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    Direction direction;

    public LayerMask chestLayer;

    float vertical;
    float horizontal;

    bool chestActive;

    GameObject chest;
    public GameObject inventory;
    public GameObject flashlight;
    public GameObject weapon;

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

        Collider2D chestPossibly = Physics2D.OverlapCircle(transform.position, 1.5f, chestLayer);
        if(chestPossibly != transform.GetChild(5).gameObject.activeSelf){
            transform.GetChild(5).gameObject.SetActive(!transform.GetChild(5).gameObject.activeSelf);
            if(chestPossibly) chest = chestPossibly.gameObject;
            else chest = null;
        } 

        if(Input.GetKeyDown(KeyCode.E)){
            if(!inventory.activeSelf && chest) chest.GetComponent<chestStuff>().activateChest();
            else if(chest) chest.GetComponent<chestStuff>().deactivateChest();
            inventory.SetActive(!inventory.activeSelf);
            flashlight.SetActive(!flashlight.activeSelf);
            weapon.GetComponent<weaponAttack>().enabled = !weapon.GetComponent<weaponAttack>().enabled;
            if(Time.timeScale == 1f) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }
}
