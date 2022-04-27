using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject cube;
    public Vector3 centre;
    public Vector3 size;

    void Start()
    {
        //cube.transform.Rotate(0, 180, 0);
        for(int i = 0; i < 20; i++)
        {
            Spawn();
        }
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Q))
        //for (int i = 0; i < 20; i++)
            //Spawn();
    }

    public void Spawn()
    {
        Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        //Vector3 rotation = Vector3(0, 180, 0);

        Instantiate(cube, pos, cube.transform.rotation);
    }


}
