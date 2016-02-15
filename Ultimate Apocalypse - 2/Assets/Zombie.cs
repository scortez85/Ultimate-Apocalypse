using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    public int playerPoints;
    public int zombHealth;
    public int weaponDmg;
    public int zombieDps;

    //find and follow player
    public float myDistance =100;
    public float mySpeed = 1f;
    public float myRotationSpeed = 10f;
    private float minDistance = 5f;
    private float maxDistance = 10f;
    private Vector3 myOffset;
    private Vector3 objDist;
    private float objDistF;
    public float damageTimer = 0;
    public GameObject myPlayer;

    //public GameObject myCompanion;
    public bool mychase = true;
    // Use this for initialization
    void Start () {
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        playerPoints = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().playerPoints;
        zombHealth = 100;
        //weaponDmg = GameObject.FindGameObjectWithTag("Weapon")GetComponent<Weapon>().weaponDmg;
    }
	
	// Update is called once per frame
	void Update () {
        //damage timeer
        if (damageTimer > 0)
            damageTimer--;
        playerPoints = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().playerPoints;

        //
        //calculate the distance
        if (myDistance < 20)
            mychase = true;
        myDistance = Mathf.Abs(Mathf.Round(transform.position.z - myPlayer.transform.position.z));
        objDist = (myPlayer.transform.position - transform.position);
        objDistF = objDist.sqrMagnitude;
        //find roatation
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myPlayer.transform.position - transform.position), myRotationSpeed * Time.deltaTime);
        //this activates the zombie
        if (mychase)
        {
            transform.Translate(0, 0, mySpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("zombieActive", true);
            GetComponent<Animator>().SetFloat("speed", 2);
        }
            //
        }

    void OnCollisionEnter(Collision col)
    {
        //if (col.collider.name == "player")
            //GetComponent<Animator>().SetBool("attack", true);
        //coll with player

        if (col.collider.name == "bullet(Clone)" && zombHealth > 10)
        {
            //Debug.Log("HIT");
            zombHealth -= 10;
            playerPoints += 10;
            Destroy(col.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().playerPoints += 10;
            //GameObject.FindGameObjectWithTag("Main Camera").GetComponent<gameHud>().playerPoints = (playerPoints + 10).ToString();
        }
        else if (col.gameObject.name == "bullet(Clone)" && zombHealth <= 10)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.collider.name == "player")
        {
            //GetComponent<Animator>().SetBool("zombieActive", true);
            if (damageTimer == 0)
                damageTimer = 100;
            //set a damage value later
            float playerLife = GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().life;
            float playerSheild = GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().shield;

            if (playerSheild > 0 && damageTimer < 90 && damageTimer > 80)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().shield -= zombieDps;
            }

            if (playerSheild == 0 && playerLife  > 0 && damageTimer <90 && damageTimer > 80)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().life -= zombieDps;
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
       // if (col.collider.name == "player")
         //   GetComponent<Animator>().SetBool("attack", false);
    }
}
