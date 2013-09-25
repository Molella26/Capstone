using UnityEngine;
using System.Collections;

public class KeyCheck{

    public bool getKeyUp(KeyCode Key)
    {
        bool keyy = false;
        if (Input.GetKeyUp(Key))
        {
            keyy = true;
        }
        return keyy;
    }

    public bool getKeyDown(KeyCode Key)
    {
        bool keyy = false;
        if (Input.GetKeyDown(Key))
        {
            keyy = true;
        }
        return keyy;
    }
}
