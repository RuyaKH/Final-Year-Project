using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour 
{
    public Transform target;
    public Vector3 offset;
	// Update is called once per frame
	void Update()
	{
        transform.position = target.position + offset;
        //transform.Rotate = target.Rotate + offset;
    }

}
