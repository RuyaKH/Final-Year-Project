using UnityEngine;
using System.Collections;

public class KillBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    //trigger to check for 
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.name);
        if (collider.tag == "enemy")
        {
            bullet.SetActive(false);
        }
    }
}
