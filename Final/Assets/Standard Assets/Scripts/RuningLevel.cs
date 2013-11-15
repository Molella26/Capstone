using UnityEngine;
using System.Collections;

public class RuningLevel : MonoBehaviour {

    ApplicationModel AM = new ApplicationModel();
    public GameObject Planet;
    GameObject NewPlanet;
    Ship ship;
    EnemyShip[] Eship;
    GameObject[] GT = new GameObject[5];
    TextCreater TC = new TextCreater();
    public GameObject[] Models;
    public GameObject[] EModels;
    public GameObject[] Bullet;
    int WaveNum;
    int WaveAmout;
    int WaveLeft = 0;
    int WaveCurt = 1;
    int ShipOnScreen = 0;
    int CreatedShips = 0;
    string EName = "Dragon";
    float TimePast;
    float TimeDelay;
    KeyCheck key = new KeyCheck();

	// Use this for initialization
	void Start () {
        ship = new Ship(Models, Bullet);
        ship.Start();
        AM.setCurLevel("RunningLevel");
        Planet.name = AM.getCurPlanet().ToString();
        Planet.transform.localScale = new Vector3(30f, 30f, 30f);
        NewPlanet = Instantiate(Planet, new Vector3(0f,-0.5f,0f), new Quaternion(0, 0, 1, 1)) as GameObject;
        WaveNum = AM.getCurPlanet() + 4;
        StartNewWave();
        GT[0] = TC.CreateNewText(GT[0], "Left In Wave " + (WaveAmout - WaveLeft) + "/" + WaveAmout, new Vector3(0.9f, 0.15f, 0.0f), Color.white, 30);
        GT[1] = TC.CreateNewText(GT[1], "Current Wave " + WaveCurt + "/" + WaveNum, new Vector3(0.895f, 0.07f, 0.0f), Color.white, 30);
	}

    void CheckPosition()
    {
        for(int i = 0; i < CreatedShips; i++){
            if (Eship[i].Enemy != null)
            {
                float EPos = Eship[i].Enemy.gameObject.transform.position.x;
                float NEPos = Eship[CreatedShips].Enemy.gameObject.transform.position.x;
                if (NEPos < (EPos + 11) && (NEPos > EPos - 11))
                {
                    Eship[CreatedShips].Enemy.gameObject.transform.position = new Vector3(Random.Range(-20, 20), 62, -5);
                    i = -1;
                }
            }
        }

    }
    
    void StartNewWave()
    {
        WaveAmout = Random.Range(WaveNum, WaveNum + 4);
        Eship = new EnemyShip[WaveAmout];
        for (int i = 0; i < Eship.Length; i++)
        {
            Eship[i] = new EnemyShip(EModels, Bullet, EName);
        }
        Eship[0].Start();
        Eship[0].setName("E0");
        CreatedShips = 1;
        WaveLeft = WaveAmout;
        TimePast = Time.time;
        TimeDelay = Time.time;
    }

    void WaveFunction()
    {
        if (WaveLeft > 0)
        {
            int CheckDiff = 0;
            bool NewShip = false;
            int diff = 0;
            //Checks to see how many ships are on alive
            for (int i = 0; i < CreatedShips; i++)
            {
                if (Eship[i].Enemy == null) CheckDiff++;
                else diff++;
            }

            //Checks to see if a ship was destoried
            //Helps out with the next part, since i wanted to check when i ship was destoried i had to use some weird math
            //If 1 ship is on the field and its destoried than a newship needs to be made
            //If more than 1 ship are on the field, it checks to see if one was destoried
            if (CheckDiff == CreatedShips) //Add Delay Time for Spwan, figure it out again Fag it
            {
                NewShip = true;
            }
            else if (CheckDiff > CreatedShips - ShipOnScreen)
            {
               
                NewShip = false;
                if (ShipOnScreen >= 1)
                {
                    NewShip = true;
                }

            }

            //Changes the ShipOnScreen value here, because the function before
            //needs to know how many there was
            if (diff != ShipOnScreen)
            {
                ShipOnScreen = diff;
            }
            //Checks to see if a new ship should be created
            //if 10 seconds passed since last ship was created
            //if a ship was destoried
            //No more than 3 ships can be on the field at once

            if ((((NewShip) || Time.time > TimePast + 10.0f) && ShipOnScreen < 2) && CreatedShips < Eship.Length)
            {
                Eship[CreatedShips].Start();
                Eship[CreatedShips].setName("E" + (CreatedShips+1));
                CheckPosition();
                CreatedShips++;
                TimePast = Time.time;
                NewShip = false;
            }
            WaveLeft = 0;
            //checks to see if theres any remaning enemies
            //to appear, it also updates if an enemy was defeated
            for (int i = 0; i < Eship.Length; i++)
            {
                if (Eship[i].Enemy != null) WaveLeft++;
            }
            GT[0].guiText.text = "Left In Wave " + (WaveAmout - WaveLeft) + "/" + WaveAmout;

        }
        if (WaveLeft == 0)
        {
            if (WaveCurt == WaveNum)
            {
                //Boss Fight
                Application.LoadLevel(1);
            }
            else
            {
                if (GameObject.Find("Bullet")) { Destroy(GameObject.Find("Bullet")); }
                StartNewWave();
                WaveCurt++;
                GT[0].guiText.text = "Left In Wave " + (WaveAmout - WaveLeft) + "/" + WaveAmout;
                GT[1].guiText.text = "Current Wave " + WaveCurt + "/" + WaveNum;
            }


        }


    }

    void EnemyUpdate()
    {
        for (int i = 0; i < CreatedShips; i++)
        {
            if (Eship[i].Enemy != null)
            {
                for (int k = 0; k < CreatedShips; k++)
                {
                    if (k != i && Eship[k].Enemy != null)
                    {
                        float EX = Eship[i].Enemy.transform.position.x;
                        float EXX = Eship[k].Enemy.transform.position.x;
                        if (EX > EXX + 7.0f || EX < EXX - 7.0f)
                        {
                            Eship[i].ChangeDirection();
                            Eship[k].ChangeDirection();
                        }
                    }
                }
                Eship[i].Update();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!AM.getPause())
        {
            ship.Update();
            WaveFunction();
            EnemyUpdate();
        }
        if(key.getKeyUp(KeyCode.P)){
            if (AM.getPause()) AM.setPause(false);
            else AM.setPause(true);
        }
    }
}
