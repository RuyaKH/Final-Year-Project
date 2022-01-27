using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunShoot : MonoBehaviour 
{
	public int movementspeed = 5;
    private InputManager inputManager;
    public GameObject bullet;

    // Use this for initialization
    void Start()
	{
        //inputManager = InputManager.instance;
        //physics.isKinematic = true;
    }

	// Update is called once per frame
	void Update()
	{
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
            //physics.isKinematic = false;
            //physics.AddForce(force, ForceMode.Force);
            //Debug.Log(physics.velocity);
        }

    }

    void OnColliderEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "TargetBox")
        {
            Debug.Log("collide");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.SetActive(false);
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
