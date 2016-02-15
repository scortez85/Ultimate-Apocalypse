/*
aad more elements to play files in newuser


*/



using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class leaderboardMenu : MonoBehaviour
{
    public Texture mainMenuTexture;
    //public Texture titleTexture;
    // Use this for initialization
    //public List<string> playerAccounts = new List<string>();
    //public string playerPath;
    public List<string> menuItems = new List<string>();

    //public List<string> userScrap = new List<string>();
    //public int userScrap = 0;
   // public List<string> userChem = new List<string>();

    public List<string> playerList = new List<string>();
   // public Dictionary<int, string> playerScores = new Dictionary<int, string>();
    public Hashtable PlayerScores = new Hashtable();


    public string userName;
    public List<string> letters = new List<string>();
   // public string menuTitle = "New Player";
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
       // menuItems.Add("New");
        //menuItems.Add("Load");
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
            //playerScores.Add(Int32.Parse(s.Split(":"[0])[1]), (s.Split(":"[0])[1]));
            //playerList.Add(s);
            playerList.Add((s.Split(":"[0])[1])+":"+ (s.Split(":"[0])[0]));
            //Debug.Log(playerList[0]);
            PlayerScores[Int32.Parse(s.Split(":"[0])[1])] = s.Split(":"[0])[0];

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

            //Application.Quit();
            {
                Application.LoadLevel("introMenu");
            }

           
            else if (menuChoice == 0)
                Application.LoadLevel("introMenu");

        }
       

        //return button
        if (Input.GetAxis("Cancel") > 0)
        {
            Application.LoadLevel("introMenu");

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
 



        //draw background
        //GUI.DrawTexture(new Rect(65, 600 / 2 - 100, 110, 50 * menuItems.Count), charMenuTexture);
        //draw game pointer
       

            //GUI.DrawTexture(new Rect(-10, Screen.height / 2 - 1 * -(menuChoice * 50), 64, 64), pointerTexture);
            if (pointerTime > 0)
                GUI.DrawTexture(new Rect(-10, 375 / 2 - 1 * -(menuChoice * 50), 64, 64), pointerTexture);
       

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
                
                if (menuItems[k] == "Back")
                    Application.LoadLevel("introMenu");

            }


        }
        //draw menu texture
        GUI.DrawTexture(new Rect(Screen.width/2, 200, 320, 90 * playerList.Count), charMenuTexture);
        GUI.Label(new Rect(Screen.width / 2+30, 200, 300, 50), "Player scores:\nNames\tPoints");
        GUI.Label(new Rect(Screen.width / 2 + 30, 200, 300, 50), "              \n______\t_____");
        //draw users



        //test
        List<int> myList = new List<int>();
      foreach (int var in PlayerScores.Keys)
        {
            myList.Add(var);
            
            
        }
        myList.Sort();
        
        myList.Reverse();
        
        for (int k = playerList.Count-1;k>=0;k--)
        {
            
            GUI.Label(new Rect(Screen.width / 2 + 30, (40 * k) + 300, 150, 50), PlayerScores[myList[k]].ToString()+"\t"  + myList[k].ToString());
        }
        
        //end test

      

    }

   
}
