using UnityEngine;
using System.Collections;

public class RuningLevel : MonoBehaviour {

    ApplicationModel AM = new ApplicationModel();
    public GameObject Planet;
    GameObject NewPlanet;
    Ship ship;
    EnemyShip[] Eship = new EnemyShip[2];
    public GameObject[] Models;
    public GameObject[] EModels;

	// Use this for initialization
	void Start () {
        ship = new Ship(Models);
        for (int i = 0; i < Eship.Length; i ++){
        Eship[i] = new EnemyShip(EModels);
        Eship[i].Start();
        Eship[i].setName(i.ToString());
        }
        ship.Start();
        AM.setCurLevel("RunningLevel");
        Planet.name = AM.getCurPlanet().ToString();
        Planet.transform.localScale = new Vector3(30f, 30f, 30f);
        NewPlanet = Instantiate(Planet, new Vector3(0f,-0.5f,0f), new Quaternion(0, 0, 1, 1)) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void LoadEnemy()
    {


    }
}
