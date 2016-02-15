using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class threedPrint : MonoBehaviour {
    public Texture backgroundTexture;
    public Texture pointerTexture;
    public GUIStyle listStyle;
    public bool ableToGetWeapon;
    public int weaponChoice;
    public bool ableToChoose;
    public int numOfGuns;
    public string weaponCost;
    
    public List<Hashtable> weaponList = new List<Hashtable>();
    
    void Start() {
        //sample data remove later
        Hashtable SampleWeap = new Hashtable();
        SampleWeap["Glock 17"] = "50";
        SampleWeap["M 16     "] = "100";
        SampleWeap["Knife       "] = "3";
        SampleWeap["Ammo        "] = "10";
        weaponList.Add(SampleWeap);
        
        
        //remove above
	
	}
	    
	// Update is called once per frame
	void Update () {
        
        if (Input.GetAxis("Vertical") > 0 && ableToChoose && ableToGetWeapon && weaponChoice >0)
        {
              weaponChoice--;
            ableToChoose = false;
        }
        else if (Input.GetAxis("Vertical") < 0 && ableToChoose && ableToGetWeapon && weaponChoice < numOfGuns)
        {
            weaponChoice++;
            ableToChoose = false;
        }
        else if (Input.GetAxis("Vertical")==0 && !ableToChoose)
        {
            ableToChoose = true;
        }

        if (Input.GetAxis("Submit") != 0 && ableToChoose && ableToGetWeapon)
        {
            //check to see if player has the money for the gun
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().playerScrap > int.Parse(weaponCost))

            {
                GameObject.FindGameObjectWithTag("printer").GetComponent<printAni>().aniTime = 180;
                GameObject.FindGameObjectWithTag("printer").GetComponent<printAni>().playClip = true;
                givePlayerWeapon(weaponChoice);
                ableToGetWeapon = false;
                ableToChoose = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().moveSpeed = 5;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().turningSpeed = 75f;
                weaponChoice = 0;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().playerScrap -= int.Parse(weaponCost);

            }
            else
            {
                ableToGetWeapon = false;
                ableToChoose = false;
                weaponChoice = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().moveSpeed = 5;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().turningSpeed = 75f;
               
            }

        }
    }

    void OnCollisionEnter(Collision col)
    {
        {
            //Debug.Log("hit");
            if (col.collider.name =="player")
            {
                //Debug.Log("hit");
                ableToGetWeapon = true;
                ableToChoose = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().moveSpeed = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoveFps>().turningSpeed = 0;
                

            }
        }
    }
    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(Screen.width/2, Screen.height/2, 100, 100), pointerTexture);
        if (ableToGetWeapon)
        {
            
            
            List <string> guns = new List<string>();
            List<string> gunPrices = new List<string>();
            
            if (weaponList.Count > 0)
            {
                
                for (int k = 0; k < weaponList.Count; k++)
                {
                    //get weapon prices
                    foreach (string price in weaponList[k].Values)
                    {
                        gunPrices.Add(price);
                    }
                    weaponCost = gunPrices[weaponChoice];
                    //get weapon names
                    foreach (string gun in weaponList[k].Keys)
                    {
                        guns.Add(gun);
                        
                        // OnGUI(gun);
                    }
                }
            }
            //draw gui
            for (int k=0;k<guns.Count;k++)
            {
                numOfGuns = k;
                
                GUI.skin.label = listStyle;
                //GUI.DrawTexture(new Rect(Screen.width / 2, 32 + (k * 64), 300, 100), backgroundTexture);
                GUI.Label(new Rect(Screen.width / 2, 32 + (k * 64), 400, 64), "         "+guns[k] +"\t"+ gunPrices[k]);
                //use this to get gun texture
                GUI.DrawTexture(new Rect(Screen.width / 2, 32 + (k + 64), 100, 100), getWeapTexture(guns[k]));
                
            }
            //draw pointer
            GUI.DrawTexture(new Rect(Screen.width / 2, 32 + (weaponChoice * 64), 64, 64), pointerTexture);
            //set price
            //weaponCost = int.Parse(gunPrices[weaponChoice]);
        }

         
    }
    public Texture getWeapTexture(string gunName)
    {
        Texture gunTexture = new Texture();
        //get texture from gun class

        return gunTexture;
    }
    public void givePlayerWeapon(int weaponId)
    {
        //send value to player inv of weapons
    }
}
