using UnityEngine;
using System.Collections;

public class ApplicationModel {

    static public int CurPlanet = 0;
    static public string CurLevel;
    static SolarSystem SS;

    public void setCurPlanet(int num)
    {
        CurPlanet = num;

    }

    public int getCurPlanet()
    {
        return CurPlanet;
    }

    public void setCurLevel(string Level)
    {
        CurLevel = Level;
    }

    public string getCurLevel()
    {
        return CurLevel;
    }

    public void setSS(SolarSystem ss)
    {
        SS = ss;
    }

    public SolarSystem getSS()
    {
        return SS;
    }
}
