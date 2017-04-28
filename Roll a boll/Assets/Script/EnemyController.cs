using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int Enemyspeed;
    private Transform theTarget;
    public Rigidbody rigidB;
	// Use this for initialization
	void Start () {
        rigidB = GetComponent<Rigidbody>();
        theTarget = GameObject.Find("Player").transform;
        Enemyspeed = 15;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Flyttar fiendebollen om spelaren är på banan
        if (theTarget.position.z > 270)
        {
            transform.position = Vector3.MoveTowards(transform.position, theTarget.position, Enemyspeed*Time.deltaTime);
        }
	}
}
