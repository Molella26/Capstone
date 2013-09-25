using UnityEngine;
using System.Collections;

public class SolarSystem{
    Planet[] planets;
    int SolarSize;
    public SolarSystem(int Size)
    {
        SolarSize = Size;
        planets = new Planet[Size];
        CreateSystem();
    }

    void CreateSystem()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            bool Lock = false;
            if (i == 0)
            {
                Lock = true;
            }
            planets[i] = new Planet((i).ToString(),new Vector3(i*4,0,0),Lock);
        }

    }

    public int getSize()
    {
        return SolarSize;
    }

    public int NextPlanet(int CurPlanet){
        if (CurPlanet < (SolarSize-1))
        {
            CurPlanet++;
        }
        return CurPlanet;
    }

    public int PrePlanet(int CurPlanet){
        if (CurPlanet > 0)
        {
            CurPlanet--;
        }
        return CurPlanet;
    }

    public Vector3 getPosition(int CurPlanet)
    {
        Vector3 PlaPos;

        PlaPos = planets[CurPlanet].getPosition();

        return PlaPos;
    }

    public void setPosition(int CurPlanet, Vector3 Location)
    {
        planets[CurPlanet].setPosition(Location);
    }

    public string getPlanetName(int CurPlanet)
    {
        return planets[CurPlanet].getName();
    }

    public void setPlanetName(string name,int CurPlanet)
    {
        planets[CurPlanet].setName(name);
    }

    public void setPlanetLock(bool locker,int CurPlanet)
    {
        planets[CurPlanet].setLock(locker);
    }

    public bool getPlanetLock(int CurPlanet)
    {
        return planets[CurPlanet].getLock();
    }

    public string getPlanetScore(int CurPlanet)
    {
        return planets[CurPlanet].getScore();
    }

    public void setPlanetScore(string num, int CurPlanet)
    {
        planets[CurPlanet].setScore(num);
    }
}
