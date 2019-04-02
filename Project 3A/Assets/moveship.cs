using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveship : MonoBehaviour
{

    public Rigidbody2D ship;
    public GameObject shipobject;
    public int speed = 4;
    public float rotation;
    public GameObject bulletprefab;
    public GameObject container;
    public AudioSource shootaud;
    public AudioClip shootclip;
    public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnPrefab()
    {

        GameObject bullet = Instantiate(bulletprefab);
        //bullet.transform.Translate(ship.position);
        bullet.transform.position = ship.transform.position;
        direction = ship.transform.forward;
        bullet.transform.rotation = ship.transform.rotation;
        Rigidbody2D bulletbody = bullet.GetComponent<Rigidbody2D>();
        bulletbody.AddForce(ship.transform.up * 300);
        bullet.transform.SetParent(container.transform);
        //bullet.transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);
        Debug.Log(bullet.transform.position);

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("space"))
        { SpawnPrefab();

            if(PlayerPrefs.HasKey("sfxvolume"))
            { shootaud.volume = PlayerPrefs.GetFloat("sfxvolume"); }

            shootaud.PlayOneShot(shootclip);

        }

        if (Input.GetKey("w"))
        { ship.AddForce(ship.transform.up * speed);
            foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
            { if (go.tag == "fire")
                { go.SetActive(true); }
             }


        }

        if (Input.GetKey("w") == false)
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (go.tag == "fire")
                { go.SetActive(false); }
            }
        }



        if (Input.GetKey("a"))
        {
            ship.transform.Rotate(0, 0, rotation);
            rotation = Input.GetAxis("Horizontal") * -speed;             
        }

        if (Input.GetKey("d"))
        {
            ship.transform.Rotate(0, 0, rotation);
            rotation = Input.GetAxis("Horizontal") * -speed;  
                
        }



    }

    // private IEnumerator RespawnPlayer()
    // { ship.SetActive(false);

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
