using UnityEngine;
using System.Collections;

public class EnemyShip : Ship {

    public GameObject Enemy;
    GameObject[] Ebullet = new GameObject[2];
    float Delay;
    string name;
    float Movement = 0.2f;

   public EnemyShip(GameObject[] models, GameObject[] bullets, string Name) :base (models, bullets)
    {
        Enemy = new GameObject();
        name = Name;
    }

   public void setName(string name)
   {
       Enemy.transform.name = name;
   }

	// Use this for initialization
	public override void Start() {
        MonoBehaviour.Destroy(Enemy);
        GameObject StartPosistion = GameObject.Find("EnemyObject");
        Enemy = MonoBehaviour.Instantiate(Models[0], new Vector3(Random.Range(-17, 17), 62, -5), new Quaternion(0, 0, 0, 0)) as GameObject;
        Enemy.transform.parent = StartPosistion.transform;
        Delay = Time.time;
    }

    public void DestroyShip()
    {
        MonoBehaviour.Destroy(Enemy);

    }

    public void ChangeDirection()
    {
        Movement = Movement * -1.0f;
    }

    void AIMoving()
    {
        Enemy.transform.Translate(new Vector3(Movement, 0, 0));
        if (Enemy.transform.position.x > (20 - Movement)) ChangeDirection();
        if (Enemy.transform.position.x < ( Movement - (-20)) * -1) ChangeDirection();
    }

    void AIShooting()
    {

        if (Time.time > Delay + 5.0f)
        {
            for (int i = 0; i < 2; i++)
            {
                Ebullet[i] = MonoBehaviour.Instantiate(Bullets[1]) as GameObject;
                Ebullet[i].transform.position = Enemy.transform.FindChild("C" + (i + 1)).gameObject.transform.position;
                Ebullet[i].name = name  + "Bullet";
            }
            Delay = Time.time;
        }
    }
    
    // Update is called once per frame
    public override void Update()
    {
        AIShooting();
        AIMoving();
    }
}
