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
    public float range = 2f;
    public float damage = 5f;
    public float attackSize = 10f;
    public float attackSpeed = 1f;
    private float nextAttack = 0.0f;
    Vector2 positionOnScreen;
    Vector2 mouseOnScreen;
    Vector2 mouseInWorld;
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
        mouseInWorld = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // angle = Mathf.Round(angle / 45) * 45;

		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90f));
        
        // transform.RotateAround(transform.parent.position, Vector3.forward, angle);
        if(Input.GetButtonDown("Fire1")){
            if (Time.time >= nextAttack)
            {
                anim.SetTrigger("attack");
                //Debug.Log(positionOnScreen);
                //Debug.Log(mouseOnScreen);
                attack();
                nextAttack = Time.time + attackSpeed;
            }
        }
    }

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
    void attack()
    {
        Vector2 loc = mouseInWorld - new Vector2(transform.parent.position.x, transform.parent.position.y);
        Vector2 unit = loc.normalized;
        Debug.Log(mouseOnScreen);
        //Debug.Log(unit);
        Vector2 hitloc = new Vector2(transform.parent.position.x + (unit.x * range), transform.parent.position.y + (unit.y * range));
        //Debug.Log("Attack Location: "+hitloc);
        attackArea = Physics2D.OverlapCircleAll(hitloc, attackSize / 2, enemy);
        foreach(Collider2D c in attackArea) {
            if (c != null)
            {
                Debug.Log(c.name);
                //Debug.Log("attacked Enemy");
                if(c.name == "HatMan" || c.name == "Imposter") c.gameObject.GetComponent<health>().takeDamage(damage);
            }
        }

    }
}
