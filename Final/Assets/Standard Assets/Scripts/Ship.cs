using UnityEngine;
using System.Collections;

public class Ship {

    CreateFile SF;
    public GameObject[] Models;
    ApplicationModel AM = new ApplicationModel();
    public GameObject[] Bullets;
    GameObject ship;
    GameObject[] bullet = new GameObject[2];
    float Speed = 0.1f;
    GameObject StartPoision;
    KeyCheck Key = new KeyCheck();
    GameObject[] CannonPos = new GameObject[2];

    public Ship(GameObject[] models, GameObject[] bullets)
    {
        Models = models;
        Bullets = bullets;
    }
    // Use this for initialization
    public virtual void Start()
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


    void SetUpBullet()
    {

        for (int i = 0; i < 2; i++)
        {
            CannonPos[i] = GameObject.Find("Sphere_00" + (i+1));
            bullet[i] = MonoBehaviour.Instantiate(Bullets[0]) as GameObject;
            bullet[i].name = "Bullet";
            bullet[i].transform.position = CannonPos[i].transform.position;
        }

    }

    void KeyboardCheck(){

        //Movement
        if (Key.getKey(KeyCode.LeftArrow) && ship.gameObject.transform.parent.transform.position.x < 14)
        {
            ship.transform.parent.transform.Translate(new Vector3(Speed,0,0));
        }
        if (Key.getKey(KeyCode.RightArrow) && ship.gameObject.transform.parent.transform.position.x > -14)
        {
            ship.transform.parent.transform.Translate(new Vector3(-Speed, 0, 0));
        }
        if (Key.getKeyDown(KeyCode.Space))
        {
            
            if(!AM.getFiring())
                SetUpBullet();
        }

    }

    void checkFiring()
    {
        if (!GameObject.Find("Bullet")) AM.setFiring(false);

    }


    //Update is called once per frame
    public virtual void Update()
    {
        KeyboardCheck();
        if (AM.getFiring()) checkFiring();
    }



}
