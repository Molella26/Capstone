using UnityEngine;
using System.Collections;

public class RuningLevel : MonoBehaviour {

    ApplicationModel AM = new ApplicationModel();
    public GameObject Planet;
    GameObject NewPlanet;
    Ship ship;

    public GameObject[] Model;

	// Use this for initialization
	void Start () {
        ship = new Ship(Model);
        ship.Start();
        AM.setCurLevel("RunningLevel");
        Planet.name = AM.getCurPlanet().ToString();
        Planet.transform.localScale = new Vector3(30f, 30f, 30f);
        NewPlanet = Instantiate(Planet, new Vector3(0f,-0.5f,0f), new Quaternion(0, 0, 1, 1)) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
