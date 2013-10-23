using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float Mx = 20f;
    GameObject Ship;
    CreateFile SF;
    public GameObject[] Models;
    KeyCheck Key = new KeyCheck();
    bool Turn = false;
	// Use this for initialization
	void Start () {
        SF = new CreateFile();
        int CurrentShip = int.Parse(SF.ReadCurrentShip("SaveFile"));
        Ship = Instantiate(Models[CurrentShip], new Vector3(0f, 0f, 0f), new Quaternion(0, 0, 0, 1)) as GameObject;
        Ship.transform.parent = this.transform;
        float x, y, z;
        x = Ship.transform.parent.position.x; y = Ship.transform.parent.position.y; z = Ship.transform.parent.position.z;
        Ship.transform.Translate(new Vector3(x, y, z));
	}
	
	// Update is called once per frame
	void Update () {
        MoveMent();
	}

    void MoveMent()
    {

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Ship.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Ship.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < Mx)
            {
                transform.position += (transform.transform.right / 8);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                Ship.transform.Rotate(new Vector3(0, 0, -45));
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > -Mx)
            {
                transform.position -= (transform.transform.right / 8);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Ship.transform.Rotate(new Vector3(0, 0, 45));
            }
        }
        

    }

}
