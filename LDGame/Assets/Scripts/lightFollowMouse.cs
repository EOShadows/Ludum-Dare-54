using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public float angle = 0;

    // Update is called once per frame
    void Update () 
	{
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // angle = Mathf.Round(angle / 45) * 45;

		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90f));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
