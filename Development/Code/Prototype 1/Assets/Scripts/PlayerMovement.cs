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

	//void ChangeSprite()
 //   {
	//	spriteRenderer.sprite = spriteArray[0];
 //   }

	void Start()
	{
        inputManager = InputManager.instance;
	}

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
