using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

    GameObject Enemy;
    

   public EnemyShip(GameObject[] models) :base (models)
    {
 
    }

   public void setName(string name)
   {
       Enemy.transform.name = name;
   }

	// Use this for initialization
	public override void Start() {
        GameObject StartPosistion = GameObject.Find("EnemyObject");
        Enemy = MonoBehaviour.Instantiate(Models[0], new Vector3(0, 62, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        Enemy.transform.parent = StartPosistion.transform;
    }
	
    public void DestroyShip(){
        MonoBehaviour.Destroy(Enemy);

    }

	// Update is called once per frame
     public override void Update()
    {
	
    }
}
