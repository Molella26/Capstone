using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
    KeyCheck key = new KeyCheck();

	void Update () {
	    if(key.getKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
	}
}
