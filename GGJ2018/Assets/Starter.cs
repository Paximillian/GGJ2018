using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadPlayeryz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Playeryz");
    }
}
