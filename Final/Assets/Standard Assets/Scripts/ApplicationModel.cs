using UnityEngine;
using System.Collections;

public class ApplicationModel {

    static public bool Firing = false;
    static public int CurPlanet = 0;
    static public string CurLevel;
    static SolarSystem SS;
    static public bool Pause = false;

    public void setPause(bool pause)
    {
        Pause = pause;
    }

    public bool getPause()
    {
        return Pause;
    }

    public void setCurPlanet(int num)
    {
        CurPlanet = num;

    }

    public int getCurPlanet()
    {
        return CurPlanet;
    }


    public void setFiring(bool Bool)
    {
        Firing = Bool;
    }

    public bool getFiring()
    {
        return Firing;
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
