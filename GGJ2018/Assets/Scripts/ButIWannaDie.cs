using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButIWannaDie : MonoBehaviour
{
    static bool initialized = false;

    // Use this for initialization
    void Start()
    {
        if (initialized == false) {
            initialized = true;
        DontDestroyOnLoad(gameObject);
        }
        else { Destroy(this.gameObject); }
        

    }
}
