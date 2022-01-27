using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public BallMovement bm;
    public float force = 100f;
    private Vector2 startPosition;
    private Vector2 endPosition;
    public Rigidbody2D physics;
    public bool isMoving;

    void Awake()
    {
        physics = GetComponent<Rigidbody2D>();
    }

	void Start()
    {
        physics.isKinematic = true;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = getMousePosition();
            //Debug.Log(startPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = getMousePosition();
            Vector2 power = startPosition - endPosition;
            physics.isKinematic = false;
            isMoving = true;
            physics.AddForce(power * force, ForceMode2D.Force);
            Debug.Log(physics.velocity);
        }
    }

    private Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
