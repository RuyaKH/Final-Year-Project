using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	private CountScore cs;

    void Start()
    {
        cs = FindObjectOfType<CountScore>();
    }

	void OnTriggerEnter (Collider cubeCheck){
		Debug.Log ("Cube destroyed");
		Debug.Log (cubeCheck.name);

        if (cubeCheck.tag == "enemy")
        {
            cs.UpdateScoreValue(1);                
            Debug.Log(gameObject.name);
        }
	
	}
}
