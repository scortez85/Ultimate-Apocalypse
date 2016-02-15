using UnityEngine;
using System.Collections;

public class shootProj : MonoBehaviour
{

    public GameObject projectile;
    Rigidbody projectileRb;
    public float speed = 20f;
    public int currentAmmo;
    public int maxAmmo;
    public int ammoPerMag;
    //public int reloadAmmo;
    public int missingAmmo;

    void Start()
    {
        currentAmmo = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().currentAmmo;
        maxAmmo = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().maxAmmo;
        ammoPerMag = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().ammoPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        missingAmmo = ammoPerMag - currentAmmo;
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
            {
                Instantiate(projectile, transform.position, transform.rotation);

                //send to gameController
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().currentAmmo -= 1;
                //send to GUI
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().currentAmmo = (currentAmmo - 1).ToString();
                //decrease local ammo
                currentAmmo--;
                //missingAmmo = ammoPerMag - currentAmmo;
            }

        }
        else if (Input.GetButtonDown("Fire2"))
        {
            //
            if (currentAmmo == 0 && missingAmmo <= maxAmmo)
            {


                //missingAmmo = ammoPerMag - currentAmmo;
                currentAmmo += ammoPerMag;
                maxAmmo -= ammoPerMag;
                missingAmmo = 0;

            }
            //above is working fine
            //
            else if (currentAmmo < ammoPerMag && missingAmmo <= maxAmmo)
            {
                //missingAmmo = ammoPerMag - currentAmmo;
                currentAmmo += missingAmmo;
                maxAmmo -= missingAmmo;
                missingAmmo = 0;
            }
            else
            {
                currentAmmo += maxAmmo;
                maxAmmo = 0;
                missingAmmo = 0;


            }
        }






        //send to gameController
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().currentAmmo = currentAmmo;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().maxAmmo = maxAmmo;
        //send to GUI
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().currentAmmo = (currentAmmo).ToString();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().maxAmmo = (maxAmmo).ToString();
        //decrease local ammo





    }

}

