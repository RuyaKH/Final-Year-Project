using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private CountScore cs;
    void Start()
    {
        cs = FindObjectOfType<CountScore>();
    }

    //trigger to check for 
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.tag == "bullet")
        {
            cs.UpdateScoreValue(1);
            cube.SetActive(false);
        }
    }
}
