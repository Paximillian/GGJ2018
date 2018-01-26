using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeShower : MonoBehaviour {

    public DiscRotationController holderOfThee;
    // Use this for initialization
    void Start() {
        holderOfThee = GetComponentInParent<DiscRotationController>();

    }
	
}
