using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform player;
    public Vector2 moving = new Vector2();
    
	public bool isGrounded;
	public float timePassed;


	void OnCollisionEnter() {
		isGrounded = true;
	}
		

    // Use this for initialization
    void Start()
    {
		isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

		Debug.Log ("Grounded " + isGrounded);

        moving.x = moving.y = 0;

        if (Input.GetKey("right"))
        {
            moving.x = 1;
        }
        if (Input.GetKey("left"))
        {
            moving.x = -1;
        }

		if (Input.GetKeyDown ("up") && timePassed < .75f) {
			moving.y = 1;
			timePassed += Time.deltaTime;

		} else if (Input.GetKeyUp ("up")){
			timePassed = 0;
		}	
	
//		if (Input.GetKey("down"))
//        {
//            moving.y = -1;
//        }

    }
}
