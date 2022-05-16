using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour 
{
	public float movementspeed = 10f;
    public Rigidbody2D physics;
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
            movementspeed = 10f;
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
        }
        else if (ball.isMoving == true)
        {
            if (inputManager.GetKey(KeybindingActions.Left))
            {
                transform.Translate(Vector3.zero * movementspeed * Time.deltaTime);
            }
            //else
            //{
            //    transform.Translate(0f, 0f, 0f);
            //}
            if (inputManager.GetKey(KeybindingActions.Right))
            {
                transform.Translate(Vector3.zero * movementspeed * Time.deltaTime);
            }
            //else
            //{
            //    transform.Translate(0f, 0f, 0f);
            //}
        }
    }

    void OnColliderEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Wall") 
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
