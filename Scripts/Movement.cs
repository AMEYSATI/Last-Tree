using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    float moveup;
    float rollinput;

    [Header("General Control Setting")]
   [SerializeField] float rollspeed = 90f;
   [SerializeField]float rollacc = 3.5f;
   [Tooltip("Movement speed of our player")] [SerializeField] float movingspeed = 60f;

   [Tooltip("Take game object with particle system . Child under parent playersparrow")] 
   [SerializeField] GameObject[] lasers;
    // [SerializeField] ParticleSystem[] lasers;

  

    [SerializeField] float lookratespeed = 50f;
    Vector2 lookinput, screencenter, mousedistance;
    float playerboundz;


    // Start is called before the first frame update
    void Start()
    {
        screencenter.x = Screen.width * 0.5f;
        screencenter.y = Screen.height * 0.5f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        movement();
        firing();
        playquitmenu();
    }

     void rotation()
    {
        lookinput.x = Input.mousePosition.x;
        lookinput.y = Input.mousePosition.y;

        mousedistance.x = (lookinput.x - screencenter.x) / screencenter.y;
        mousedistance.y = (lookinput.y - screencenter.y) / screencenter.y;

        mousedistance = Vector2.ClampMagnitude(mousedistance, 1f);

        rollinput = Mathf.Lerp(rollinput, Input.GetAxis("Horizontal"), rollacc * Time.deltaTime);

        transform.Rotate(-mousedistance.y * lookratespeed * Time.deltaTime, mousedistance.x * lookratespeed * Time.deltaTime,- rollinput * rollspeed * Time.deltaTime, Space.Self);
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * Time.deltaTime * movingspeed;

            playerboundz = Mathf.Clamp(transform.localPosition.z, -225, 325);
        }


        moveup = Input.GetAxisRaw("Upwards");
        float offsetup = moveup * Time.deltaTime * movingspeed;
        float newposup = Mathf.Clamp(transform.localPosition.y , -25 , 140)+ offsetup;


        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -320, 165), newposup, playerboundz);
    }
    
    void firing()
    {
        if(Input.GetButton("Fire1"))
        {
            //EnableFiring();

            ActiveFiring(true);
        }
        else
        {
            // DisableFiring();

            ActiveFiring(false);
        }
    }
   /* void EnableFiring()
    {
        foreach (ParticleSystem laser in lasers)
        {
            laser.enableEmission = true;
        }
    }
    void DisableFiring()
    {
        foreach (ParticleSystem laser in lasers)
        {
            laser.enableEmission =false;
        }
    }*/

    void ActiveFiring(bool flag)
    {
        foreach (GameObject laser in lasers)
        {
            var emmision = laser.GetComponent<ParticleSystem>().emission;
            emmision.enabled = flag; 
        }
    }
    void playquitmenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
