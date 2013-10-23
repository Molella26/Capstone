using UnityEngine;
using System.Collections;

public class Ship {

    CreateFile SF;
    public GameObject[] Models;
    GameObject ship;
    ApplicationModel AM = new ApplicationModel();
    GameObject StartPoision;

    int Attack, HP, Defence;



    public void SetAttack(int Num)
    {
        Attack = Num;
    }
    public int GetAttack()
    {
        return Attack;
    }

    public void SetHP(int Num)
    {
        HP = Num;
    }
    public int GetHP()
    {
        return HP;
    }

    public void SetDefence(int Num)
    {
        Defence = Num;
    }
    public int GetDefence()
    {
        return Defence;
    }

    public Ship(GameObject[] models)
    {
        Models = models;
    }
    // Use this for initialization
    public void Start()
    {
        StartPoision = GameObject.Find("GameObject");
        SF = new CreateFile();
        int CurrentShip = int.Parse(SF.ReadCurrentShip("SaveFile"));
        ship = MonoBehaviour.Instantiate(Models[CurrentShip], new Vector3(0f, 0f, 0f), new Quaternion(0, 0, 0, 1)) as GameObject;
        ship.transform.parent = StartPoision.transform;
        float x, y, z;
        x = ship.transform.parent.position.x; y = ship.transform.parent.position.y; z = ship.transform.parent.position.z;
        ship.transform.Translate(new Vector3(x, y, z));
    }

    //Update is called once per frame
    public void Update()
    {
        

    }



}
