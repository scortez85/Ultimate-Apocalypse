using UnityEngine;
using System.Collections;

public class gameHud : MonoBehaviour
{

    public Texture heathBar;
    public Texture weaponBar;
    public Texture pointDisplay;
    public Texture healthFill;
    public Texture healthBack;
    public Texture sheildFill;
    public Texture sheildBack;
    public GUIStyle style;
    public string currentWeapon;
    public string currentAmmo;
    public string maxAmmo;
    public string playerPoints;
    public string numberOfEnemies;
    public string roundNumber;

    // Use this for initialization
    void Start()
    {
        //playerPoints = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin.label = style;
        GUI.skin.textField = style;

        //life fill by amount
        GUI.DrawTexture(new Rect(Screen.width / 4 - 30, 0, 420, 53), healthBack);
        GUI.DrawTexture(new Rect(Screen.width / 4 - 30, 0, (GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().life * 420)/100, 53) , healthFill);
        //sheild bar fill by amount
        GUI.DrawTexture(new Rect(Screen.width / 4 +810, 0, -420, 53), sheildBack);
        GUI.DrawTexture(new Rect(Screen.width / 4 +810, 0, -(GameObject.FindGameObjectWithTag("GameController").GetComponent<playerStats>().shield * 420) / 100, 53), sheildFill);
        //life bar and sheild bar
        GUI.DrawTexture(new Rect(Screen.width/4-50, 0, 878, 139/2), heathBar);
        
        //GUI.Label(new Rect(22, 32, 100, 20), "LIFE");

        //weapon bar
        GUI.DrawTexture(new Rect(Screen.width - (280), Screen.height - (254/1.5f), 280, 254), weaponBar);
        GUI.Label(new Rect(Screen.width - (280/2 )+25, Screen.height - (254 )-20, 280 , 254 ), currentWeapon);
        GUI.Label(new Rect(Screen.width - (280/2 ) + 25, Screen.height - (254 ) +10, 280 , 254 ), currentAmmo + " / " + maxAmmo);
        //GUI.Label(new Rect(22, 722, 100, 20), currentWeapon + "    " + currentAmmo + "/" + maxAmmo);

        //enemies left
        GUI.Label(new Rect(Screen.width - (260 ) + 25, Screen.height -150, 280, 254),"Enemies: "+ numberOfEnemies);
        //points display
        playerPoints = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().playerPoints.ToString();
        GUI.DrawTexture(new Rect(0, Screen.height-(254/1.5f), 280, 254), pointDisplay);
        //GUI.Label(new Rect(30, 615, 175, 55), playerPoints + " :Points");
        GUI.Label(new Rect(0, 690, 175, 55), playerPoints + " :Points");

        //scrap
        GUI.Label(new Rect(0, 630, 175, 55), "Scrap:");

        //chemicals
        GUI.Label(new Rect(0, 600, 175, 55), "Chemicals:");

        //number of enemies display
        numberOfEnemies = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().numberOfEnemies.ToString();
        GUI.Label(new Rect(0, 720, 175, 55), "Enemies: "+numberOfEnemies);

        //round display
        roundNumber = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControl>().roundNumber.ToString();
        GUI.Label(new Rect(0, 660, 175, 55), "Round: " + roundNumber);
    }
}
