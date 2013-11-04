using UnityEngine;
using System.Collections;

public class PlanetMain : MonoBehaviour {
    public GUIText PlanetName;
    public GameObject BasicPlanet;
    SolarSystem SS;
    KeyCheck Key = new KeyCheck();
    int CurPlanet = 0; 
    public int Size = 5;
    bool Zoom = false;
    GameObject[] NewPlanets;
    ApplicationModel AM = new ApplicationModel();
    CreateFile CF;

	// Use this for initialization
	void Start () {
        CF = new CreateFile();
        AM.setCurLevel("PlanetMain");
        SS = new SolarSystem(Size);
        NewPlanets = new GameObject[Size];
        createPlanets();
        NamePlanets();
        this.transform.position = new Vector3(SS.getPosition(CurPlanet).x, SS.getPosition(CurPlanet).y, -3.0f);
        
    }

    void NamePlanets()
    {
        SS.setPlanetName("Adora", 0);
        SS.setPlanetName("Crustler", 1);
        SS.setPlanetName("Mondell", 2);
        SS.setPlanetName("BlahhBlahh", 3);
        SS.setPlanetName("WaaWaa", 4);
    }

    void createPlanets(){
        for (int i = 0; i < Size; i++)
        {
            BasicPlanet.name = (i).ToString();
            NewPlanets[i] = Instantiate(BasicPlanet, SS.getPosition(i), new Quaternion(0,0,0,1)) as GameObject;
            string Lock = CF.ReadFilePlanetsLock("PlanetSave", i);
            if (Lock == "1")
            {
                SS.setPlanetLock(true, i);
            }
            else
            {
                SS.setPlanetLock(false, i);
            }
            SS.setPlanetScore(CF.ReadScore("PlanetSave",i),i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updatePlanetsPos();
        KeyBoardKeys();
        if (Zoom == false)
        {
            PlanetName.text = SS.getPlanetName(CurPlanet);
            this.transform.position = new Vector3(SS.getPosition(CurPlanet).x, SS.getPosition(CurPlanet).y, -4.0f);
        }
        else
        {
            PlanetName.text = "";
            this.transform.position = new Vector3(((Size - 1) * 4) / 2, 0, ((Size - 1) * -4));
        }

        if (SS.getPlanetLock(CurPlanet))
        {
            PlanetName.material.color = Color.white;
        }
        else
        {
            PlanetName.material.color = Color.red;
        }
	}

    void KeyBoardKeys()
    {

        if (Key.getKeyUp(KeyCode.LeftArrow))
        {
            if (Zoom == true)
            {
                Zoom = false;
            }
            else
            {
                CurPlanet = SS.PrePlanet(CurPlanet);
            }
        }
        if (Key.getKeyUp(KeyCode.RightArrow))
        {
            if (Zoom == true)
            {
                Zoom = false;
            }
            else
            {
                CurPlanet = SS.NextPlanet(CurPlanet);
            }
        }
        if (Key.getKeyUp(KeyCode.DownArrow))
        {
            Zoom = true;
        }
        if (Key.getKeyUp(KeyCode.UpArrow))
        {
            Zoom = false;

        }
        if (Key.getKeyUp(KeyCode.KeypadEnter) || Key.getKeyUp(KeyCode.Space))
        {
            if (SS.getPlanetLock(CurPlanet))
            {
                AM.setCurPlanet(CurPlanet);
                AM.setSS(SS);
                Application.LoadLevel(2);
            }

        }
    }

    void updatePlanetsPos()
    {
        for (int i = 0; i < Size; i++)
        {
            GameObject locator;
            string LookFor = i.ToString() + "(Clone)";
            locator = GameObject.Find(LookFor);
            SS.setPosition(i, locator.transform.position);
        }
    }
}
