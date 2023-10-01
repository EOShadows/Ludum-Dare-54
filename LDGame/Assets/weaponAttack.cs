using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAttack : MonoBehaviour
{
    Animator anim;
    public float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // angle = Mathf.Round(angle / 45) * 45;

		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90f));
        
        // transform.RotateAround(transform.parent.position, Vector3.forward, angle);
        if(Input.GetButtonDown("Fire1")){
            anim.SetTrigger("attack");
            Debug.Log(positionOnScreen);
            Debug.Log(mouseOnScreen);
        }
    }

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
