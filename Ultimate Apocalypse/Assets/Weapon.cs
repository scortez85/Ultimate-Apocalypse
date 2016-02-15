using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private string weaponName;
    private int startingAmmo;
    private int maxAmmo;
    private int ammoPerMag;
    private int weaponDmg;
    private int fireRate;
    private int recoilStrength;
    private int scrapPrice;
    private Texture weaponIcon;


    public Weapon(string name)
    {
        name = weaponName;
        if(name == "Glock 17")
        {
            maxAmmo = 98;
            ammoPerMag = 17;
            fireRate = 5;
            recoilStrength = 2;
            scrapPrice = 100;
        }
        else if(name == "AK-47")
        {
            maxAmmo = 120;
            ammoPerMag = 30;
            fireRate = 7;
            recoilStrength = 6;
            scrapPrice = 300;
        }
        else if(name == "Beretta")
        {
            maxAmmo = 32;
            ammoPerMag = 13;
            fireRate = 3;
            recoilStrength = 7;
            scrapPrice = 50;
        }
    }

    public string getScrapPrice(string name)
    {
        return Weapon(name).scrapPrice.toString();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
