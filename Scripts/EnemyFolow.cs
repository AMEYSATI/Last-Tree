using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFolow : MonoBehaviour
{
    public Transform Player;
    [SerializeField]int MoveSpeed = 10;
    [SerializeField] int MaxDist = 50;
    [SerializeField] int MinDist = 10;
    [SerializeField] GameObject[] lasers;

    void Update()
    {
        transform.LookAt(Player);
        if (gameObject.tag == "MoveEnemy")
        {

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                foreach (GameObject laser in lasers)
                {
                    var emmision = laser.GetComponent<ParticleSystem>().emission;
                    if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                    {
                        emmision.enabled = true;
                    }
                    else
                    {
                        emmision.enabled = false;
                    }

                }
            }
        }
        else
        {

            foreach (GameObject laser in lasers)
            {
                var emmision = laser.GetComponent<ParticleSystem>().emission;
                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    emmision.enabled = true;
                }
                else
                {
                    emmision.enabled = false;
                }

            }
        }
    }
}
