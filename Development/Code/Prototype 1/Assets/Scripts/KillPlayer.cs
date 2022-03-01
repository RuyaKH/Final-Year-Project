﻿using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    // CameraControl camera;
    [SerializeField]
    private GameObject ballCheckpoint;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject playerCheckpoint;
    [SerializeField]
    private GameObject player;

    public Rigidbody2D physics;
    public Ball b;

    //trigger to check for 
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.name == "Ball")
        {
            physics.isKinematic = true;
            ball.transform.position = ballCheckpoint.transform.position;
            player.transform.position = playerCheckpoint.transform.position;
            physics.velocity = Vector2.zero;
            physics.angularVelocity = 0f;
            physics.transform.rotation = Quaternion.identity;
            b.isMoving = false;
            b.isClicked = false;
        }
    }
}
