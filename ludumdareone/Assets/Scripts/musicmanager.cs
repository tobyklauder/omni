using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public AudioClip intense;
    public AudioClip search; 
    public static AudioClip searchmusic;
    public static AudioClip intensemusic; 
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        searchmusic = search;
        intensemusic = intense;
        audioSource.clip = searchmusic;
        audioSource.Play(); 
    }

    // Update is called once per frame


    public static void switchclip(string clip) {
        if (searchmusic.name.ToString() == clip)
        {
            audioSource.clip = searchmusic;
            audioSource.Play();
        }
        else if (intensemusic.name.ToString() == clip) {
            audioSource.clip = intensemusic;
            audioSource.Play(); 
        }
    }
}
