/*
aad more elements to play files in newuser


*/



using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class lobbyMenu : MonoBehaviour
{
    public Texture mainMenuTexture;
    //public Texture titleTexture;
    // Use this for initialization
    //public List<string> playerAccounts = new List<string>();
    public string playerPath;
    public List<string> menuItems = new List<string>();

    //public List<string> userScrap = new List<string>();
    public int userScrap = 0;
    public int userChem =0;
    public List<string> playerList = new List<string>();


    public string userName;
    public List<string> letters = new List<string>();
    public string menuTitle = "New Player";
    Rect windowRect = new Rect(10, 10, 1350, 700);
    public GUIStyle titleStyle;
    public GUIStyle listStyle;
    public bool ableToChoose = true;
    public int myChar = 0;
    public bool ableHoriz = true;
    public bool ableVert = true;
    public bool ableToText = false;
    //public int rowNum = 0;
    //public int colNum = 0;
    public int rowLen = 8;
    public int menuChoice = 0;
    public int charChoice = 0;
    public Texture charMenuTexture;
    public Texture titleTexture;
    public Texture pointerTexture;
    public bool pointerActive;
    public int pointerTime = 0;

    void Start()
    {
        //menu items
        menuItems.Add("New");
        menuItems.Add("Load");
        menuItems.Add("Back");

        //letters
        letters.Add("a"); letters.Add("b"); letters.Add("c"); letters.Add("d"); letters.Add("e"); letters.Add("f"); letters.Add("g"); letters.Add("h"); letters.Add("i"); letters.Add("j"); letters.Add("k"); letters.Add("l"); letters.Add("m"); letters.Add("n"); letters.Add("o"); letters.Add("p"); letters.Add("q"); letters.Add("r"); letters.Add("s"); letters.Add("t"); letters.Add("u"); letters.Add("v"); letters.Add("w"); letters.Add("x"); letters.Add("y"); letters.Add("z");
        //find all player accounts
        StreamReader playerListreader = new StreamReader("Assets\\gameData\\playerList.txt");
        //playerList.Add(userName);

        string s = playerListreader.ReadLine();
        //Debug.Log(s);
        while (s != null)
        {
            //char[] delimiter = { ':' };
            //string[] fields = s.Split(delimiter);
            //Debug.Log(s.Split(delimiter)[1]);

            playerList.Add(s);


            s = playerListreader.ReadLine();

        }
        playerListreader.Close();



    }

    // Update is called once per frame
    void Update()
    {
        //enable pointer
        if (Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            pointerTime = 200;

        }
        if (pointerTime > 0)
            pointerTime--;
        //choose name
        if (ableToText == true)
        {
            if (Input.GetAxis("Vertical") > 0 && ableVert == true && myChar < letters.Count - 1)
            {
                myChar++;
                ableVert = false;
            }

            else if (Input.GetAxis("Vertical") < 0 && ableVert == true && myChar > 0)
            {
                myChar--;
                ableVert = false;
            }

            else if (Input.GetAxis("Vertical") == 0 && ableVert == false)
            {

                ableVert = true;
            }
            //submit button
            else if (Input.GetAxis("Submit") > 0 && ableVert == true && ableHoriz == true)
            {
                ableVert = false;
                ableHoriz = false;

                if (userName.Length == 0)
                    userName += letters[myChar].ToUpper();
                else if (userName.Length > 0)
                    userName += letters[myChar];

            }

            else if (Input.GetAxis("Submit") == 0 && ableVert == true && ableHoriz == false)
            {
                ableVert = false;
                ableHoriz = true;
                //name += letters[myChar]
                //userName[0] = userName[0].ToString().ToUpper();


            }
        }
        

        if (Input.GetAxis("Submit") != 0)
        {
            //Debug.Log("room: " + menuChoice);
            if (menuChoice == 0)
                Application.LoadLevel("newMenuIntro");
            //Application.Quit();
            //{
               // ableToText = true;
             //   ableHoriz = false;
             //   ableVert = false;
                //GUI.FocusWindow(0);
          //  }

            ///create player folder
           // else if (menuChoice == 1 && userName != "")
           else if (menuChoice == 1)
            {
                Application.LoadLevel("introMenuLoad");
                {
                    
                    {


                       // System.IO.Directory.CreateDirectory("Assets\\gameData\\players\\" + userName);
                        
                        //playerPath = "Assets\\gameData\\players\\" + userName + "\\";

                        //create files
                      //  saveFile();
                      
                    }//
                }
            }
            else if (menuChoice == 2)
                Application.LoadLevel("introMenu");

        }
        //toggle menu choices

        if (ableToChoose == true && ableToText == false)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                if (menuChoice < menuItems.Count - 1)
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


    }
    void OnGUI()
    {
        //draw background
        GUI.DrawTexture(new Rect(0, 0, 1366, 768), mainMenuTexture);

        //draw label
        //GUI.Label (Rect (10, 10, 100, 20), "Ultimate Apocalypse");
        GUI.DrawTexture(new Rect(350, 50, 877, 83), titleTexture);
        //userName = "Enter a name";
        //userName = GUI.TextField(new Rect(500, 300, 150, 32), userName, 15);
        if (ableToText == true && myChar < letters.Count)
        {
            //userName = GUI.TextField(new Rect(500, 300, 150, 32), userName, 15);
            GUI.Label(new Rect(500, 200, 150, 32), "Enter a name and press return to finish");
            GUI.Label(new Rect(500, 300, 150, 32), userName + letters[myChar]);
            GUI.Label(new Rect(500, 300, 150, 32), userName + "_");
            //userName = GUI.TextField(new Rect(500, 300, 150, 32), userName, 15);
            GUI.FocusWindow(0);


        }




        //draw background
        GUI.DrawTexture(new Rect(65, 600 / 2 - 100, 110, 50 * menuItems.Count), charMenuTexture);
        //draw game pointer
        if (ableToText == false)
        {

            //GUI.DrawTexture(new Rect(-10, Screen.height / 2 - 1 * -(menuChoice * 50), 64, 64), pointerTexture);
            //if (pointerTime > 0)
                GUI.DrawTexture(new Rect(-10, 375 / 2 - 1 * -(menuChoice * 50), 64, 64), pointerTexture);
        }

        if (menuChoice == 1)
        {

        }
        //GUI.DrawTexture(new Rect(Screen.width/2 -120,Screen.height/2-1 * -(menuChoice * 50),64,64), pointerTexture);
        //draw game title
        GUI.skin.label = titleStyle;
       // GUI.Label(new Rect(50, 0, 150, 50), menuTitle);
        //draw game menu options
        for (int k = 0; k < menuItems.Count; k++)
        {
            GUI.skin.label = listStyle;
            if (GUI.Button(new Rect(70, 200 + (50 * k), 150, 50), menuItems[k]))
            {
                if (menuItems[k] == "New")
                    Application.LoadLevel("newMenuIntro");
                else if (menuItems[k] == "Load")
                    Application.LoadLevel("introMenuLoad");
                else if (menuItems[k] == "Back")
                    Application.LoadLevel("introMenu");
               
            }

        }

    }
    ///
    public void saveFile()
    {
        if (userChem == 0)
            newUser();


        {


        }
        StreamWriter userScrapWriter = new StreamWriter(playerPath + "\\" + userName + "'s Scrap" + ".txt");
        StreamWriter userChemWriter = new StreamWriter(playerPath + "\\" + userName + "'s Chemicals" + ".txt");
        //StreamWriter userInvWriter = new StreamWriter(playerPath + "\\" + userName + "\\" + userName + "'s Inv" + ".txt");
        //StreamWriter userAbilityWriter = new StreamWriter(playerPath + "\\" + userName + "\\" + userName + "'s Abilities" + ".txt");
        


        //generate player list for accounts
        StreamWriter playerListWriter = new StreamWriter("Assets\\gameData\\playerList.txt");

        playerList.Add(userName + ":" + 0);


        {
            //write scrap to file
            userScrapWriter.WriteLine(userScrap);

            //write chem to file
            userChemWriter.WriteLine(userChem);

            


            for (int i = 0; i < playerList.Count; i++)
            {
                playerListWriter.WriteLine(playerList[i]);
            }




        }
        userScrapWriter.Close();
        userChemWriter.Close();

        playerListWriter.Close();


    }

    //generate new user data
    public void newUser()
    {
        //player scrap
        // userScrap.Add("-----list for scrap-----");
        //userScrap.Add("50");
        //player chem
        userChem = 0;
        userScrap = 0;
    }
}
