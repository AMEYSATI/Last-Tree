using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
     void Awake()
    {
        int numusicplayer = FindObjectsOfType<PlayerMusic>().Length;
        if(numusicplayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
