﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeNoOneEverWas : MonoBehaviour {
    [SerializeField]
    private Text self;

    private void Awake()
    {
        self.text = MyPrecious.Instance.winnerWinnerChickenDinner.ToString();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}