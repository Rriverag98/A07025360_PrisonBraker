using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour {

    musicPlayer instance;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = new musicPlayer();
            GameObject.DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }
}