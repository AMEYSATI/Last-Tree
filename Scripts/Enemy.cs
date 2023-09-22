using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyexplosion;
    [SerializeField] GameObject enemyhit;
    [SerializeField] Transform parent;
    int scoreincrease = 1;
    [SerializeField] int hitpointenemy = 10;

    ScoreBoard Score;

    void Start()
    {
        Score = FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Finish")
        {
            hitpoint();
            if (hitpointenemy < 1)
            {
                killenemy();
            }
        }
    }

    void killenemy()
    {
        GameObject exp = Instantiate(enemyexplosion, transform.position, Quaternion.identity);
        exp.transform.parent = parent;
        Destroy(gameObject);
        hitscore();
    }

     void hitscore()
    {
        Score.increasescore(scoreincrease);
    }

    void hitpoint()
    {
        GameObject exp = Instantiate(enemyhit, transform.position, Quaternion.identity);
        exp.transform.parent = parent;
        hitpointenemy--;
    }
}
