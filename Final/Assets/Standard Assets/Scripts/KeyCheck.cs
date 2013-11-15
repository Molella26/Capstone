using UnityEngine;
using System.Collections;

public class KeyCheck{

    public bool getKeyUp(KeyCode Key)
    {
        if (Input.GetKeyUp(Key))
        {
            return true;
        }
        return false;
    }

    public bool getKeyDown(KeyCode Key)
    {
        if (Input.GetKeyDown(Key))
        {
            return true;
        }
        return false;
    }

    public bool getKey(KeyCode Key)
    {

        if (Input.GetKey(Key))
        {
            return true;
        }
        return false;
    }
}
