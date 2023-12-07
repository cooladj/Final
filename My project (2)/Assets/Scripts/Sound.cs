using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip Clip;
    [Range(0f,1f)]
    public float volume;
    [Range(0f,3f)]
    public float pitch;

    public bool loop;
    [HideInInspector]
    public AudioSource source;
    
    // Start is called before the first frame update
    void Awake()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
