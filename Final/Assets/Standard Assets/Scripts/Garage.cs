using UnityEngine;
using System.Collections;

public class Garage : MonoBehaviour {

    DisplayShip DS = new DisplayShip();
    public GameObject[] Ships;
    GameObject[] GT;
    TextCreater TC = new TextCreater();
    bool FirstRun = true;
    int CurText = 0;
    int CurMenu = 0;
    int MaxText = 4;
    string Choice = "";
    int lastShip;
    CreateFile CF = new CreateFile();
    KeyCheck Key = new KeyCheck();
	// Use this for initialization
	void Start () {
        GT = new GameObject[10];
        DS.Start(Ships);
        lastShip = 0;
	}

    void Begining()
    {
        if (FirstRun)
        {
            GT[0] = TC.CreateNewText(GT[0], "Change Cannons", new Vector3(0.22f, 0.82f, 0.0f), Color.yellow, 30);
            GT[1] = TC.CreateNewText(GT[1], "Stats", new Vector3(0.22f, 0.7f, 0.0f), Color.gray, 30);
            GT[2] = TC.CreateNewText(GT[1], "Skill Tree", new Vector3(0.22f, 0.58f, 0.0f), Color.gray, 30);
            GT[3] = TC.CreateNewText(GT[1], "Change Ship", new Vector3(0.22f, 0.46f, 0.0f), Color.black, 30);            
            FirstRun = false;
        }

    }

    void CannonChange()
    {
        if (FirstRun)
        {
            GT[0] = TC.CreateNewText(GT[0], "Cannon Lv1", new Vector3(0.22f, 0.82f, 0.0f), Color.yellow, 30);
            Color C1 = Color.gray;
            Color C2 = C1;
            if (CF.ReadUnlockedCannons("SaveFile", 1) == "1") C1 = Color.black;
            if (CF.ReadUnlockedCannons("SaveFile", 2) == "1") C2 = Color.black;
            GT[1] = TC.CreateNewText(GT[1], "Cannon Lv2", new Vector3(0.22f, 0.7f, 0.0f), C1, 30);
            GT[2] = TC.CreateNewText(GT[1], "Cannon Lv3", new Vector3(0.22f, 0.58f, 0.0f), C2, 30);
            GT[3] = TC.CreateNewText(GT[1], "Back", new Vector3(0.08f, 0.40f, 0.0f), Color.black, 30);
            FirstRun = false;
        }
    }

    void ShipChange()
    {
        if (FirstRun)
        {
            ///first one is auto yellow!
            GT[0] = TC.CreateNewText(GT[0], "The Velcirox", new Vector3(0.22f, 0.82f, 0.0f), Color.black, 30);
            GT[1] = TC.CreateNewText(GT[1], "The SlyHawk", new Vector3(0.22f, 0.7f, 0.0f), Color.black, 30);
            GT[2] = TC.CreateNewText(GT[1], "The TomFalcon", new Vector3(0.22f, 0.58f, 0.0f), Color.black, 30);
            GT[3] = TC.CreateNewText(GT[1], "The Clunker", new Vector3(0.22f, 0.46f, 0.0f), Color.black, 30);
            GT[4] = TC.CreateNewText(GT[1], "Back", new Vector3(0.08f, 0.40f, 0.0f), Color.black, 30);
            CurText = lastShip;
            GT[CurText].guiText.material.color = Color.yellow;
            FirstRun = false; 
            
        }
        if (int.Parse(CF.ReadCurrentShip("SaveFile")) != CurText)
        {
            GT[int.Parse(CF.ReadCurrentShip("SaveFile"))].guiText.material.color = Color.red;
        }
       
        
    }

    void ApplyCannon()
    {
        if (CurText != 3)
        {
            if (int.Parse(CF.ReadCurrentCannon("SaveFile")) != CurText)
            {
                CF.SaveCurrentCannon("SaveFile", CurText);
                Destroy(GameObject.Find("Ship"));
                DS.Start(Ships);
            }
        }
        else
        {
            ConvertChoice();

        }

    }
	
	// Update is called once per frame
    void Update()
    {
        DS.Update();
        KeyPressing();
        if(CurMenu == 0) Begining();
        if (CurMenu == 1) CannonChange();
        if (CurMenu == 4) ShipChange();
        
	}

    int ConvertChoice()
    {

        for (int i = 0; i < MaxText; i++)
        {
            Destroy(GT[i]);

        }
        if (CurMenu == 0)
        {
            if (CurText == 0)
            {
                //Choice Change Cannons
                CurMenu = 1;
                MaxText = 4;
              

            }
            if (CurText == 1)
            {


            }
            if (CurText == 2)
            {


            }
            if (CurText == 3)
            {
                //Change Ship
                CurMenu = 4;
                MaxText = 5;
                lastShip = 0;
            }
        }
        else if (CurMenu == 4)
        {
            if (CurText == 4)
            {
                Destroy(GameObject.Find("Ship"));
                CurMenu = 0;
                MaxText = 4;
                DS.Start(Ships);
            }
            else
            {
                lastShip = CurText;
                CF.SaveCurrentShip("SaveFile", CurText);
            }
        }
        else if (CurMenu == 1)
        {
            CurMenu = 0;
            MaxText = 4;
        }
        CurText = 0;
        FirstRun = true;
        return CurMenu;
    }

    void KeyPressing()
    {
        if(CurText!=MaxText-1 && Key.getKeyUp(KeyCode.DownArrow)){
            for (int i = 1; i < MaxText; i++)
            {
                if (GT[CurText + i].guiText.material.color != Color.gray)
                {
                    GT[CurText].guiText.material.color = Color.black;
                    CurText+=i;
                    GT[CurText].guiText.material.color = Color.yellow;
                    break;
                }
            }
        } 
        if (Key.getKeyUp(KeyCode.UpArrow))
        {
            for (int i = 1; i < MaxText; i++)
            {
                if (CurText != 0 && GT[CurText - i].guiText.material.color != Color.gray)
                {
                    GT[CurText].guiText.material.color = Color.black;
                    CurText-=i;
                    GT[CurText].guiText.material.color = Color.yellow;
                    break;
                }
            }
        }

        if (Key.getKeyUp(KeyCode.KeypadEnter))
        {
            if (CurMenu == 1)
            {
                ApplyCannon();
            }
            else { 
                ConvertChoice();
            }
        }

        if(CurMenu == 4 && CurText != 4)
        {
             Destroy(GameObject.Find("Ship"));
                DS.ChangeShip(CurText);
        }

    }
}
