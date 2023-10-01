using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            angle = Mathf.Round(angle / 90) * 90;
            if(angle == 0f){
                Debug.Log("Attack LEFT");
            }
            else if(angle == 90f){
                Debug.Log("Attack DOWN");
            }
            else if(angle == 180f){
                Debug.Log("Attack RIGHT");
            }
            else{
                Debug.Log("Attack UP");
            }
        }
    }

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
