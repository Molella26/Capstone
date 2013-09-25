using UnityEngine;
using System.Collections;

public class Planets : MonoBehaviour {

    public Material P1;
    public Material P2;
    public Material P3;
    public Material P4;
    public Material P5;
    ApplicationModel AM = new ApplicationModel();

	// Use this for initialization
	void Start () {
        ColorPlanet();
	}

    void ColorPlanet()
    {
        string Name = name.Substring(0,1);
        switch (Name)
        {
            case "0":
                renderer.material = P1;
                break;
            case "1":
                renderer.material = P2;
                break;
            case "2":
                renderer.material = P3;
                break;
            case "3":
                renderer.material = P4;
                break;
            case "4":
                renderer.material = P5;
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        if (AM.getCurLevel() == "PlanetMain")
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Rotate(new Vector3(0, 1, 0), 0.2f);
        }else if(AM.getCurLevel() == "RunningLevel")
        {
            transform.localScale = new Vector3(100, 100, 100);
            transform.Rotate(new Vector3(0, 1, 0), -0.05f); 
        }
	}
}
