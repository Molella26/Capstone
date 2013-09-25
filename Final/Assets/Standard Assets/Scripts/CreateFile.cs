using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;

public class CreateFile {
    SolarSystem SS;
    string Path;

    //PlanetSaveFile

    public void NewPlanetFile()
    {
        string write = "PlanetsUnlocked=10000@PlanetOne=--@PlanetTwo=--@PlanetThree=--@PlanetFour=--@PlanetFive=--";
        write = write.Replace("@", System.Environment.NewLine);
        File.WriteAllText(Path, write);
    }

    public void SavePlanetsLock(string FileName, SolarSystem ss)
    {
        SS = ss;
        int size = SS.getSize();
        if (!CheckFile(FileName)) NewPlanetFile();
        string Read = File.ReadAllText(Path);
        string[] Spliter = Read.Split('\n');
        Spliter[0] = "PlanetsUnlocked="; 
        for (int i = 0; i < size; i++)
        {
            if (SS.getPlanetLock(i))
            {
                Spliter[0] += "1";
            }
            else
            {
                Spliter[0] += "0";
            }
        }
        string Final = "";
        for (int i = 0; i < 6; i++)
        {
            Final+=Spliter[i] + System.Environment.NewLine;
        }
        File.WriteAllText(Path, Final);
    }

    public string ReadFilePlanetsLock(string FileName, int PlanetNum)
    {
        if (!CheckFile(FileName))
        {
            NewPlanetFile();
        }
        string Read = File.ReadAllText(Path);
        string[] Answer = Read.Split('=');
        return Answer[1].Substring(PlanetNum, 1);
    }

    public void SavePlanetScore(string FileName, SolarSystem ss)
    {
        CheckFile(FileName);
        SS=ss;
        int size = SS.getSize();
        string Answer = "";
        string Read = File.ReadAllText(Path);
        string[] Spliter = Read.Split('\n');
        Answer += Spliter[0]+System.Environment.NewLine;
        for (int i = 1; i <= size; i++)
        {
            string[] Spliter2 = Spliter[i].Split('=');
            Answer += Spliter2[0] + "=" + SS.getPlanetScore(i-1)+System.Environment.NewLine;
        }
        File.WriteAllText(Path, Answer);
    }

    public string ReadScore(string FileName, int PlanetNum)
    {
        if(!CheckFile(FileName)){
            NewPlanetFile();
        }
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        string[] Answer = Slipter[PlanetNum + 1].Split('=');
        return Answer[1];
    }

    
	

    //SaveFile

    public void NewSaveFile()
    {
        string write = "SelectedShip=0@SelectedCannon=0@UnlockedCannons=100@PlayerLevel=1@PlayerExp=0";
        write = write.Replace("@", System.Environment.NewLine);
        File.WriteAllText(Path, write);
    }

    public string ReadCurrentShip(string FileName)
    {
        if (!CheckFile(FileName))
        {
            NewSaveFile();
        }
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        string[] Answer = Slipter[0].Split('=');
        return Answer[1];
    }

    public void SaveCurrentShip(string FileName, int CurrentShip)
    {
        if (!CheckFile(FileName)) NewSaveFile();
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        Slipter[0] = "SelectedShip=" + CurrentShip;
        string Final = "";
        for (int i = 0; i < 5; i++)
        {
            Final += Slipter[i] + System.Environment.NewLine;
        }
        File.WriteAllText(Path, Final);
    }

    public string ReadCurrentCannon(string FileName)
    {
        if (!CheckFile(FileName))
        {
            NewSaveFile();
        }
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        string[] Answer = Slipter[1].Split('=');
        return Answer[1];
    }

    public void SaveCurrentCannon(string FileName,int CurrentCannon)
    {
        if(!CheckFile(FileName)) NewSaveFile();
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        Slipter[1] = "SelectedCannon=" + CurrentCannon;
        string Final = "";
        for (int i = 0; i < 5; i++)
        {
            Final += Slipter[i] + System.Environment.NewLine;
        }
        File.WriteAllText(Path, Final);
    }

    public string ReadUnlockedCannons(string FileName,int CannonNum)
    {
        if (!CheckFile(FileName))
        {
            NewPlanetFile();
        }
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        string[] Answer = Slipter[2].Split('=');
        return Answer[1].Substring(CannonNum, 1);
    }

    public void SaveUnlockedCannons(string FileName, int Unlocked)
    {
        if (!CheckFile(FileName)) NewSaveFile();
        string Read = File.ReadAllText(Path);
        string[] Slipter = Read.Split('\n');
        Slipter[2] = "UnlockedCannons=";
        int Num = 0;
        while (Num < 3)
        {
            if (Unlocked >= Num) Slipter[2] += 1;
            else Slipter[2] += 0;
            Num++;
        }
        string Final = "";
        for (int i = 0; i < 5; i++)
        {
            Final += Slipter[i] + System.Environment.NewLine;
        }
        File.WriteAllText(Path, Final);
    }


    //Both

    public bool CheckFile(string FileName)
    {
        bool bol = false;
        FileName = "/" + FileName + ".txt";
        Path = Application.dataPath + @FileName;
        if (File.Exists(Path))
        {
            bol = true;
        }
        return bol;
    }

}


