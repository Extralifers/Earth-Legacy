﻿using UnityEngine;
using System.Collections;
using System;

public class ItemSpeed : MonoBehaviour{

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().Speed += 100;
        Destroy(this.gameObject);
    }
}
