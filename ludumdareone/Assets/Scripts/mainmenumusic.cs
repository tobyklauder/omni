﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenumusic : MonoBehaviour
{
    public AudioClip menumusic;
    public AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = menumusic;
        audioSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
