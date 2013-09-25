using UnityEngine;
using System.Collections;

public class AttachCannon : MonoBehaviour {

    public GameObject[] Models;
    CreateFile SF;
    GameObject Cannon;
    ApplicationModel AM = new ApplicationModel();
	// Use this for initialization
	void Start () {
        SF = new CreateFile();
        int CurrentCannon = int.Parse(SF.ReadCurrentCannon("SaveFile"));
        Cannon = Instantiate(Models[CurrentCannon], new Vector3(0f, 0f, 0f), new Quaternion(0, 0, 0, 1)) as GameObject;
        Cannon.transform.parent = this.transform;
        Cannon.name = "Cannon";
        float x, y, z;
        x = Cannon.transform.parent.position.x; y = Cannon.transform.parent.position.y; z = Cannon.transform.parent.position.z;
        Cannon.transform.Translate(new Vector3(x, y, z));
        if (AM.getCurLevel() == "Garage")
        {
            Cannon.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        Cannon.transform.Rotate(new Vector3(90f,0f,0f));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
