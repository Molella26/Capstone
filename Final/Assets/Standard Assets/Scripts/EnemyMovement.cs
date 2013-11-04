using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
        this.transform.position = new Vector3(Random.Range(-20,20), 62, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
