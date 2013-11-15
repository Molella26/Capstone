using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public double Attack, Defense, HP;
    public string Name;
    CreateFile SF = new CreateFile();
	// Use this for initialization
	void Start () {
        this.gameObject.name = Name;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            int IncomingAttack = int.Parse(SF.ReadAttack("ShipSave", int.Parse(SF.ReadCurrentShip("SaveFile"))));
            MonoBehaviour.Destroy(collision.gameObject);
            double DamAttack = (IncomingAttack - (IncomingAttack * (Defense / 100))) * 0.5;
            Debug.Log("");
            Debug.Log(HP);
            Debug.Log(DamAttack);
            HP -= DamAttack;
            Debug.Log(HP);
            if (HP <= 0)
            {
                MonoBehaviour.Destroy(this.gameObject);
            }
        }
    }
}
