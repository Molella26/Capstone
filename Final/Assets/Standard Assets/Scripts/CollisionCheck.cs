using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {

    ApplicationModel AM = new ApplicationModel();
    
	// Use this for initialization
	void Start () {
        if(this.name == "Bullet")
        AM.setFiring(true);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!AM.getPause())
        {
            this.gameObject.rigidbody.WakeUp();
            this.gameObject.transform.Translate(new Vector3(0, 0, -0.7f));
        }
        else
        {
            this.gameObject.rigidbody.Sleep();
        }
        if (this.name == "Bullet")
        {
            if (this.gameObject.transform.position.z < -9) MonoBehaviour.Destroy(this.gameObject);
        }
        else 
        {
            if (this.gameObject.transform.position.z > 28) MonoBehaviour.Destroy(this.gameObject);

        }

	}

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
