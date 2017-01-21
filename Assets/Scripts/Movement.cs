﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public float freq;
    public int threshold;

    private SoundManager thisSoundManager;
    private Rigidbody2D thisRigidBody;
            
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        thisSoundManager = GameObject.Find("AudioManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        freq = thisSoundManager.Frequencia;
        if(freq > threshold)
        {
            Vector2 v = Vector2.up * speed * Time.deltaTime;
            thisRigidBody.AddForce(v);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 v = new Vector2(0, speed);
            thisRigidBody.AddForce(v * speed);
        }
        else if( Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 v = new Vector2(0, -speed);
            thisRigidBody.AddForce(v * speed);
        }
        else
        {
            //thisRigidBody.Sleep();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals( "Tree"))
        {

            if(this.GetComponent<Rigidbody2D>())
                DestroyObject(this, 0);
            Debug.Log("You Lost");
        }
    }
}
