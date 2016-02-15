using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class mainMenu : MonoBehaviour {
    public List<string> menuList = new List<string>();
   // public List<string> playerList = new List<string>();
    public Texture mainMenuTexture;
    public Texture titleTexture;
    public GUIStyle style;

    public bool ableToChoose = false;
    public int myChar = 0;
    public bool ableHoriz = true;
    public bool ableVert = true;
    public bool ableToText = false;
    public int menuChoice = 0;
    public Texture pointerTexture;
    public bool pointerActive;
    public int pointerTime = 0;


    void Update()
    {
        //enable pointer
        if (Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            pointerTime = 200;

        }
        if (pointerTime > 0)
            pointerTime--;

        //toggle menu choices

        if (ableToChoose == true && ableToText == false)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                if (menuChoice < menuList.Count - 1)
                {
                    menuChoice++;
                    ableToChoose = false;

                }

            }
            if (Input.GetAxis("Vertical") > 0)
            {
                if (menuChoice > 0)
                {
                    menuChoice--;
                    ableToChoose = false;
                }
            }

        }
        if (Input.GetAxis("Vertical") == 0)
        //if (Input.anyKeyDown)
        {
            ableToChoose = true;
        }

        //return button
        if (Input.GetAxis("Cancel") > 0)
        {
            ableToText = false;
            ableHoriz = false;
            ableVert = false;
            ableToChoose = true;
            menuChoice = 0;

        }

        //submit button
        if (Input.GetAxis("Submit")>0)
        {
            if (menuChoice == 0 || menuChoice == 1)
                Application.LoadLevel("lobbyMenuIntro");
            else if (menuChoice == 4)
                Application.LoadLevel("leaderboardMenuIntro");
            else if (menuChoice == menuList.Count-1)
                Application.Quit();
        }

        //
    }
    void Start()
    {
        menuList.Add("Survival Solo");
        menuList.Add("Survival Co-op");
        menuList.Add("Options");
        menuList.Add("Credits");
        menuList.Add("Leaderboard");
        menuList.Add("Exit Game");
      
    }
    void OnGUI()
    {
        

        GUI.skin.button = style;
        GUI.skin.textField = style;

        GUI.DrawTexture(new Rect(0, 0, 1366, 768), mainMenuTexture);

        //draw label
        //GUI.Label (Rect (10, 10, 100, 20), "Ultimate Apocalypse");
        GUI.DrawTexture(new Rect(350, 50, 877, 83), titleTexture);

        for (int k=0;k<menuList.Count;k++)
        {
            //if (GUI.Button(new Rect(10, (180 *k) , 350, 80), menuList[k]))
            if (GUI.Button(new Rect(10, Screen.height / 2 -150 + (80 * k), 350, 80), menuList[k]))
            {
                if (menuList[k] == "Exit Game")
                    Application.Quit();
                else if (menuList[k] == "Survival Solo" || menuList[k] == "Survival Co-op")
                    Application.LoadLevel("lobbyMenuIntro");
                else if (menuList[k] == "Leaderboard")
                    Application.LoadLevel("leaderboardMenuIntro");
            }
        }
        //if (pointerTime > 0)
        //GUI.DrawTexture(new Rect(-10, 320 / 2 -1.6f * -(menuChoice * 50), 64, 64), pointerTexture);
        GUI.DrawTexture(new Rect(10, Screen.height / 2 - 150 + (80 * menuChoice), 64, 64), pointerTexture);

    }
}
