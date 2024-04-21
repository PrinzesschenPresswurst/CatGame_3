using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic _instance;
    private AudioSource _audioSource;
    
    void Start()
    {
        if (_instance == null) 
            _instance = this;
        
        else 
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    
}
