using UnityEngine;
using System.Collections;

public class Planet{
    string Name;
    Vector3 Pos;
    bool Unlocked;
    string Score = "--";

    public string getScore()
    {
        return Score;
    }

    public void setScore(string num)
    {
        Score = num;
    }

    public void setName(string newName)
    {
        Name = newName;
    }

    public string getName(){
        return Name;
    }

    public void setLock(bool unlocked)
    {
        Unlocked = unlocked;
    }

    public bool getLock()
    {
        return Unlocked;
    }

    public Vector3 getPosition()
    {
        return Pos;
    }

    public void setPosition(Vector3 Loation)
    {
        Pos = Loation;
    }

    public Planet(string name, Vector3 pos, bool unlocked)
    {
        Name = name;
        Pos = pos;
        Unlocked = unlocked;
    }


}
