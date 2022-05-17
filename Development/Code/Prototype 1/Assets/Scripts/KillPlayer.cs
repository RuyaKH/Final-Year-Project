using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    float timeLeft = 10.0f;

    void Update()
    {
        if (b.isMoving == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
                Kill();
        }
    }

    public void GoNextLevel() //if options button pressed then load the scene options
    {
        Debug.Log("go next level");
        SceneManager.LoadScene("Game1");
    }

    //trigger to check for 
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.name == "Ball")
        {
            Kill();
            GoNextLevel();
        }
    }

    void Kill()
    {
        timeLeft = 10.0f;
        physics.isKinematic = true;
        ball.transform.position = ballCheckpoint.transform.position;
        player.transform.position = playerCheckpoint.transform.position;
        physics.velocity = Vector2.zero;
        physics.angularVelocity = 0f;
        physics.transform.rotation = Quaternion.identity;
        b.isMoving = false;
        b.isClicked = false;
        //player.SetActive(false);
        //ball.SetActive(false);
    }
}
