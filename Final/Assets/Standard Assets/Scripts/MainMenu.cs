using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    KeyCheck Key = new KeyCheck();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Key.getKeyUp(KeyCode.Alpha1))
        {
            Application.LoadLevel(3);
        }
        if (Key.getKeyUp(KeyCode.Alpha2))
        {
            Application.LoadLevel(1);
        }
	}
}
