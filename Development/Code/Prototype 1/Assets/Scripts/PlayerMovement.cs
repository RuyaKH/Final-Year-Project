using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerMovement : MonoBehaviour 
{
	public int movementspeed = 10;
	public Ball ball;
    private InputManager inputManager;

	public bool isThrowing;

	public SpriteRenderer spriteRenderer;
	public Sprite[] spriteArray;

	void Start()
	{
        inputManager = InputManager.instance;
	}

    void Update()
	{
		if (ball.isMoving == false)
		{
            spriteRenderer.sprite = spriteArray[0];
            if (Input.GetKey(GameManager.GM.left))
			{
				transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
			}
            //else
            //{
            //    Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            //    movement.Normalize();
            //    movement *= movementspeed * Time.deltaTime;
            //    transform.Translate(movement.x, 0f, movement.y);
            //}

			if (Input.GetKey(GameManager.GM.right))
			{
				transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
			}
            //else
            //{
            //    Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            //    movement.Normalize();
            //    movement *= movementspeed * Time.deltaTime;
            //    transform.Translate(movement.x, 0f, movement.y);
            //}

            if (Input.GetMouseButtonDown(0))
			{
				//gameObject.GetComponent<Animator>().Play("Player Aim");
				spriteRenderer.sprite = spriteArray[1];
			}

		}
		else if (ball.isMoving == true)
        {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			spriteRenderer.sprite = spriteArray[2];
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
