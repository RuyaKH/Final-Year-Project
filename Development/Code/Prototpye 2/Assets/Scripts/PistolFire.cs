using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject pistol;
    public GameObject bullet;
    public GameObject bulletCheckpoint;
    public bool isFiring = false;
    private Vector2 power;
    public Rigidbody physics;
    public float force = 10f;

    int movementspeed = 10;

    void Awake()
    {
        physics = bullet.GetComponent<Rigidbody>();
    }

    void Start()
    {
        physics.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            //power = new Vector3(1.0f, 1.0f, 1.0f);
            isFiring = true;
            physics.isKinematic = false;
            //physics.AddForce(power * force, ForceMode.Force);
            //Debug.Log(physics.velocity);
            transform.Translate(transform.forward * movementspeed * Time.deltaTime);
        }
    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        pistol.GetComponent<Animator>().Play("FirePistol");
        yield return new WaitForSeconds(0.25f);
        pistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "ground")
        {
            physics.isKinematic = true;
            bullet.transform.position = bulletCheckpoint.transform.position;
            physics.velocity = Vector3.zero;
            //physics.angularVelocity = 0f;
            physics.transform.rotation = Quaternion.identity;
            Debug.Log("bullet reset");
        }
    }
}
