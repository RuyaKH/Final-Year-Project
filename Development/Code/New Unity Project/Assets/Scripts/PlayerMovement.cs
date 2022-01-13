using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{
	public int movementspeed = 10;
	public Ball ball;
    private InputManager inputManager;
	// Use this for initialization
	void Start()
	{
        inputManager = InputManager.instance;
	}

	// Update is called once per frame
	void Update()
	{
		if (ball.isMoving == false)
		{
			if (inputManager.GetKey(KeybindingActions.Left))
			{
				transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
			}
			if (inputManager.GetKey(KeybindingActions.Right))
			{
				transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
			}
		}
		else if (ball.isMoving == true)
        {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
