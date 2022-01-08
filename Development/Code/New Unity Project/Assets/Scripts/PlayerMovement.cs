using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{
	public int movementspeed = 10;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
		}
	}

    void OnColliderEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Wall")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    //void FixedUpdate()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float z = Input.GetAxisRaw("Vertical");
    //    transform.position += z * transform.forward * Time.deltaTime * movementspeed;
    //    transform.position += x * transform.right * Time.deltaTime * movementspeed;
    //}
}
