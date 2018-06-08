using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour {

    public GameObject spawnPoint;

	// Use this for initialization
	void Start () {

        transform.position = spawnPoint.transform.position;
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Hazard")
        {
            
            transform.position = spawnPoint.transform.position;

        }

    }
}
