﻿using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 3, 0, Space.World);
	}
}
