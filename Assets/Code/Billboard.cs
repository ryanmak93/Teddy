﻿using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public Camera camera;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.LookAt(transform.position + camera.transform.rotation * Vector3.back);
	}
}
