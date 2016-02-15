using UnityEngine;
using System.Collections;


public class gameControl : MonoBehaviour
{
    public bool showWeap = true;
    public bool showInv = true;
    public Hashtable mytable;
    //temp weapon list subject to change
    public int startingWeapons = 1;
    public int maxWeapons = 2;
    public int maxEquip = 12;
    //array for weaponSlot, weaponName, currentAmmo, maxAmmo, ammoPerMag, weaponDmg
    public string[,] WeaponInv;// = new string[0,2];
    public string[,] EquipInv;
    public int currentAmmo;
    public int maxAmmo;
    public int ammoPerMag;
    public int playerPoints;
    public int startingPlayerPoints = 350;
    public double startingEnemies;
    public double numberOfEnemies;
    public int roundNumber;
    public string playerName;
    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        roundNumber = 1;
        startingEnemies = 8;
        playerPoints = startingPlayerPoints;
        //fully define array
        WeaponInv = new string[startingWeapons, 6];
        EquipInv = new string[maxEquip, 6];

        //trial give weapons, delete below later
        giveWeapon("Beretta", 10, 8, 6, 10, 3);
        //giveWeapon("cheese", 30, 7, 3, 1, 3);

        //trial give equip
        giveEquip("keycard: A", 1, 1);
        giveEquip("Silencer", 1, 1);
        giveEquip("Dummy Mines", 5, 30);
        //remove above later

        //remove below later
        if (showWeap)
        {
            for (int i = 0; i < 12; i++)
            {
                //int mypos = 0;
                if (WeaponInv[i, 0] != null)
                    Debug.Log(WeaponInv[i, 0] + "  " + int.Parse(WeaponInv[i, 1]) + "  " + int.Parse(WeaponInv[i, 2]) + "  " + int.Parse(WeaponInv[i, 3]));

            }
        }
        if (showInv)
        {
            for (int i = 0; i < 12; i++)
            {
                //int mypos = 0;
                if (EquipInv[i, 0] != null)
                    Debug.Log(EquipInv[i, 0] + "  " + int.Parse(EquipInv[i, 1]) + "  " + int.Parse(EquipInv[i, 2]));

            }
        }
        //remove above later

        //begin to access for menu and player weapons
        for (int i = 0; i < 12; i++)
        {

            if (WeaponInv[i, 0] != null)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().currentWeapon = WeaponInv[i, 0];
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().currentAmmo = WeaponInv[i, 2];
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameHud>().maxAmmo = WeaponInv[i, 1];
                currentAmmo = int.Parse(WeaponInv[i, 2]);
                maxAmmo = int.Parse(WeaponInv[i, 1]);
                ammoPerMag = int.Parse(WeaponInv[i, 2]);
                break;
            }
        }
    }
    void Update()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        numberOfEnemies = aliens.Length + robots.Length + zombies.Length;
        if (Input.GetKeyDown(KeyCode.A))
        {
            numberOfEnemies--;
        }
        if (numberOfEnemies == 0)
        {
            newRound();
        }
    }

    void newRound()
    {
        roundNumber += 1;
        numberOfEnemies = startingEnemies * 1.5;
    }


    void giveWeapon(string weaponName, int maxAmmo, int ammoPerMag, int weaponDmg, int fireRate, int recoilStrength)
    {
        for (int i = 0; i < maxWeapons; i++)
        {
            if (WeaponInv[i, 0] == null)
            {
                WeaponInv[i, 0] = weaponName;
                WeaponInv[i, 1] = maxAmmo.ToString();
                WeaponInv[i, 2] = ammoPerMag.ToString();
                WeaponInv[i, 3] = weaponDmg.ToString();
                WeaponInv[i, 4] = fireRate.ToString();
                WeaponInv[i, 5] = recoilStrength.ToString();
                break;
            }
        }
    }
    void giveEquip(string equipName, int equipAmount, int equipMax)
    {
        for (int i = 0; i < maxWeapons; i++)
        {
            if (EquipInv[i, 0] == null)
            {
                EquipInv[i, 0] = equipName;
                EquipInv[i, 1] = equipAmount.ToString();
                EquipInv[i, 2] = equipMax.ToString();
                break;
            }
        }
    }

    void spawnZombie()
    {

    }

    void spawnAlien()
    {

    }

    void spawnRobot()
    {

    }
}
