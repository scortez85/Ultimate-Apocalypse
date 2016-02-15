using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class playerStats : MonoBehaviour {

    // Use this for initialization
    public string playerName;
    public string playerPath;
    public int playerChem;
    public int playerScrap;
    public float shield = 100;
    public float life = 100;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (playerName != "" && playerChem <1)
        {
            //gather player scrap
            StreamReader playerScrapReader = new StreamReader(playerPath + playerName + "'s Scrap.txt");
            string scrap = playerScrapReader.ReadLine();
            playerScrap = int.Parse(scrap);
            playerScrapReader.Close();
            //gather player chem info

            StreamReader playerListreader = new StreamReader(playerPath  +playerName+ "'s Chemicals.txt");
            //playerList.Add(userName);

            string s = playerListreader.ReadLine();
            //Debug.Log(s);

            playerChem = int.Parse(s);

             
            playerListreader.Close();
        }

    }
}
