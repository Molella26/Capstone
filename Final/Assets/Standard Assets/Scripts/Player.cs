using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {

    public GameObject[] Models;
    CreateFile SF;
    GameObject Cannon;
    ApplicationModel AM = new ApplicationModel();
    double Attack, Defense, HP;

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
        Cannon.transform.Rotate(new Vector3(90f, 0f, 0f));
        Attack = int.Parse(SF.ReadAttack("ShipSave", int.Parse(SF.ReadCurrentShip("SaveFile"))));
        Defense = int.Parse(SF.ReadDefence("ShipSave", int.Parse(SF.ReadCurrentShip("SaveFile"))));
        HP = int.Parse(SF.ReadHP("ShipSave", int.Parse(SF.ReadCurrentShip("SaveFile"))));
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "DragonBullet")
        {
            Destroy(collision.gameObject);
            Debug.Log("");
            Debug.Log(HP);
            Debug.Log(Defense);
            double Damage = (40 - (40 * (Defense / 100)))*0.5;
            Debug.Log(Damage);
            HP -= Damage;
            Debug.Log(HP);
            float OldHp = float.Parse(SF.ReadHP("ShipSave", int.Parse(SF.ReadCurrentShip("SaveFile"))));
            float HPleft = (256.0f - (256.0f * (1 - (float)(HP / OldHp))));
            if (HPleft <= 0) HPleft = 0;
            GameObject.Find("Health").guiTexture.pixelInset = new Rect(6,5,50,HPleft);
            if (HP <= 0) Application.LoadLevel(1); 
        }
    }
}
