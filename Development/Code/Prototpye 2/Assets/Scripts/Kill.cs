using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour
{
    // CameraControl camera;
    [SerializeField]
    private GameObject bulletCheckpoint;
    [SerializeField]
    private GameObject bullet;
    //[SerializeField]
    //private GameObject playerCheckpoint;
    //[SerializeField]
    //private GameObject player;

    public Rigidbody physics;
    public PistolFire b;

    //trigger to check for 
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.name == "bullet")
        {
            physics.isKinematic = true;
            bullet.transform.position = bulletCheckpoint.transform.position;
            //player.transform.position = playerCheckpoint.transform.position;
            physics.velocity = Vector3.zero;
            //physics.angularVelocity = 0f;
            physics.transform.rotation = Quaternion.identity;
            b.isFiring = false;
        }
    }
}
