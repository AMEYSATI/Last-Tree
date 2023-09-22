using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;

    TMP_Text healthtext;

    void Start()
    {
        healthtext = GetComponent<TMP_Text>();
        healthtext.text = "100";
    }

    public void decreasehealth(int h)
    {
        health -= h;
        healthtext.text = health.ToString();
    }
}
