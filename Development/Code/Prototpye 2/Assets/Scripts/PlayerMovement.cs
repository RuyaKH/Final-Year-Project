using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{
	public int movementspeed = 10;
    private InputManager inputManager;
	// Use this for initialization
	void Start()
	{
        inputManager = InputManager.instance;
	}

	// Update is called once per frame
	void Update()
	{
		if (inputManager.GetKey(KeybindingActions.Left))
		{
			transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
		}
		if (inputManager.GetKey(KeybindingActions.Right))
		{
			transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
		}
        if (inputManager.GetKey(KeybindingActions.Up))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
        }
        if (inputManager.GetKey(KeybindingActions.Down))
        {
            transform.Translate(Vector3.forward * -movementspeed * Time.deltaTime);
        }
        if (inputManager.GetKey(KeybindingActions.RotateLeft))
        {
            transform.Rotate(0, -5, 0);
        }
        if (inputManager.GetKey(KeybindingActions.RotateRight))
        {
            transform.Rotate(0, 5, 0);
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
