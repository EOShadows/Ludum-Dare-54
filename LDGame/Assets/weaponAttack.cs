using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponAttack : MonoBehaviour
{
    public LayerMask enemy;
    private Collider2D[] attackArea;
    Animator anim;
    public float angle = 0;
    public float range = 1f;
    public float damage = 5f;
    public float attackSize = 10f;
    Vector2 positionOnScreen;
    Vector2 mouseOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // angle = Mathf.Round(angle / 45) * 45;

		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90f));
        
        // transform.RotateAround(transform.parent.position, Vector3.forward, angle);
        if(Input.GetButtonDown("Fire1")){
            anim.SetTrigger("attack");
            Debug.Log(positionOnScreen);
            //Debug.Log(mouseOnScreen);
            attack();
        }
    }

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
    void attack()
    {
        Vector2 loc = mouseOnScreen - new Vector2(transform.position.x, transform.position.y);
        Vector2 unit = loc.normalized;
        //Debug.Log(loc);
        attackArea = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y) + (unit * range), attackSize / 2, enemy);
        foreach(Collider2D c in attackArea) {
            if (c != null)
            {
                Debug.Log("attacked Enemy");
                c.gameObject.GetComponent<health>().takeDamage(damage);
            }
        }

    }
}
