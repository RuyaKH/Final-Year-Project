using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	private CountScore cs;

    void Start()
    {
        cs = FindObjectOfType<CountScore>();
    }

	void OnTriggerEnter2D (Collider2D HoopCheck){
		Debug.Log ("Ball in hoop");
		Debug.Log (HoopCheck.name);

        if (HoopCheck.name == "Ball")
        {
            cs.UpdateScoreValue(3);                
            Debug.Log(gameObject.name);
        }
	
	}
}
