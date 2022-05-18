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
    public bool isClicked = false;
    Vector2 power;

    public float downTime, upTime;
    public bool ready = false;

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
        if (GameManager.GM.ballMouse == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPosition = getMousePosition();
                //Debug.Log(startPosition);
            }

            if (Input.GetMouseButtonUp(0) && !isClicked)
            {
                isClicked = true;
                endPosition = getMousePosition();
                if (GameManager.GM.no == true) power = startPosition - endPosition;
                if (GameManager.GM.yes == true) power = endPosition - startPosition;
                physics.isKinematic = false;
                isMoving = true;
                physics.AddForce(power * force, ForceMode2D.Force);
                Debug.Log(physics.velocity);
                //Cursor.lockState = CursorLockMode.Confined;
            }
        }
        if (GameManager.GM.ballKeyboard == true)
        {
            //Debug.Log("It is working!");
            //Debug.Log(GameManager.GM.ball);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                downTime = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                upTime = Time.time - downTime;
                Debug.Log("Pressed for : " + upTime + "seconds");

                power = new Vector2((upTime - downTime), (upTime - downTime));
                isMoving = true;
                physics.AddForce(power * force, ForceMode2D.Force);
                Debug.Log(physics.velocity);
            }
        }


    }

    private Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
