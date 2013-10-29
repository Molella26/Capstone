using UnityEngine;
using System.Collections;

public class DisplayShip {

    CreateFile SF;
    GameObject[] Models;
    GameObject Ship;
    ApplicationModel AM = new ApplicationModel();

	// Use this for initialization
    public void Start(GameObject[] Ships)
    {
        Models = Ships;
        AM.setCurLevel("Garage");
        SF = new CreateFile();
        int CurrentShip = int.Parse(SF.ReadCurrentShip("SaveFile"));
        Ship = MonoBehaviour.Instantiate(Models[CurrentShip], new Vector3(12.77636f, 8f, 1.6882f), new Quaternion(0, 0, 0, 1)) as GameObject;
        Ship.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        Ship.name = "Ship";
        MonoBehaviour.Destroy(Ship.transform.Find("Flame").gameObject);
	}

    //Update is called once per frame
	public void Update () {
        RotateShip();
        
	}

    public void ChangeShip(int num)
    {
        Ship = MonoBehaviour.Instantiate(Models[num], new Vector3(12.77636f, 8f, 1.6882f), new Quaternion(0, 0, 0, 1)) as GameObject;
        Ship.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Ship.name = "Ship";
        MonoBehaviour.Destroy(Ship.transform.Find("Flame").gameObject);
    }

    void RotateShip(){
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Ship.transform.Rotate(new Vector3(0, 2.5f, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Ship.transform.Rotate(new Vector3(0, -2.5f, 0));
        }
    }
}
