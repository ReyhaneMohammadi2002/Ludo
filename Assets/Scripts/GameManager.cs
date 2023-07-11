using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalRedInHouse, totalGreenInHouse, totalYellowInHouse, totalBlueInHouse;

    public GameObject redFrame, greenFrame, yellowFarme,blueFrame;
    //public GameObject redWinScreen, greenWinScreen, yellowWinScreen, blueWinScreen;
    public GameObject confirmScreen;
    public GameObject gameCompletedScreen;

    //Player Movement Controller
    public GameObject redPlayer1, redPlayer2, redPlayer3, redPlayer4;
    public GameObject greenPlayer1, greenPlayer2, greenPlayer3, greenPlayer4;
    public GameObject yellowPlayer1, yellowPlayer2, yellowPlayer3, yellowPlayer4;
    public GameObject bluePlayer1, bluePlayer2, bluePlayer3, bluePlayer4;

    public Button redPlayer1Btn, redPlayer2Btn, redPlayer3Btn, redPlayer4Btn;
    public Button greenPlayer1Btn, greenPlayer2Btn, greenPlayer3Btn, greenPlayer4Btn;
    public Button yellowPlayer1Btn, yellowPlayer2Btn, yellowPlayer3Btn, yellowPlayer4Btn;
    public Button bluePlayer1Btn, bluePlayer2Btn, bluePlayer3Btn, bluePlayer4Btn;

    public GameObject redPlayer1Border, redPlayer2Border, redPlayer3Border, redPlayer4Border;
    public GameObject greenPlayer1Border, greenPlayer2Border, greenPlayer3Border, greenPlayer4Border;
    public GameObject yellowPlayer1Border, yellowPlayer2Border, yellowPlayer3Border, yellowPlayer4Border;
    public GameObject bluePlayer1Border, bluePlayer2Border, bluePlayer3Border, bluePlayer4Border;

    public static Vector3 redPlayer1Pos,redPlayer2Pos, redPlayer3Pos, redPlayer4Pos;
    public  static Vector3 greenPlayer1Pos, greenPlayer2Pos, greenPlayer3Pos, greenPlayer4Pos;
    public static Vector3 yellowPlayer1Pos, yellowPlayer2Pos, yellowPlayer3Pos, yellowPlayer4Pos;
    public  static Vector3 bluePlayer1Pos, bluePlayer2Pos, bluePlayer3Pos, bluePlayer4Pos;

    public static  int redPlayer1Steps, redPlayer2Steps, redPlayer3Steps, redPlayer4Steps;
    public static  int greenPlayer1Steps, greenPlayer2Steps, greenPlayer3Steps, greenPlayer4Steps;
    public static int yellowPlayer1Steps, yellowPlayer2Steps, yellowPlayer3Steps, yellowPlayer4Steps;
    public static int bluePlayer1Steps, bluePlayer2Steps, bluePlayer3Steps, bluePlayer4Steps;

    public List<GameObject> redMovementBlock = new List<GameObject>();
    public List<GameObject> greenMovementBlock = new List<GameObject>();
    public List<GameObject> yellowMovementBlock = new List<GameObject>();
    public List<GameObject> blueMovementBlock = new List<GameObject>();

    //public Transform diceRoll;
    //public Transform redDiceRoll, greenDiceRoll,yellowDiceRoll,blueDiceRoll;
    public Button diceRollButton;
    private int selectDiceNumAnimation;
    private System.Random randNo;
    public GameObject dice1Animation, dice2Animation, dice3Animation, dice4Animation, dice5Animation, dice6Animation;

    private string playerTurn = "YELLOW";
    private string currentPlayer = "none";
    private string currentPlayerName = "none";

    //public AudioClip diceRollingAC;
    //public static AudioSource diceRollingAS;
    //public AudioClip buttonAC;
    //public static AudioSource buttonAS;
    //public AudioClip winningAC;
    //public static AudioSource winningAS;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
        randNo = new System.Random();

        //diceRollingAS = GetComponent<AudioSource>();
        //buttonAS = GetComponent<AudioSource>();
        //winningAS = GetComponent<AudioSource>();

        dice1Animation.SetActive(false);
        dice2Animation.SetActive(false);
        dice3Animation.SetActive(false);
        dice4Animation.SetActive(false);
        dice5Animation.SetActive(false);
        dice6Animation.SetActive(false);

        //Player initial positions
        redPlayer1Pos = redPlayer1.transform.position;
        redPlayer2Pos = redPlayer1.transform.position;
        redPlayer3Pos = redPlayer1.transform.position;
        redPlayer4Pos = redPlayer1.transform.position;

        greenPlayer1Pos = greenPlayer1.transform.position;
        greenPlayer2Pos = greenPlayer1.transform.position;
        greenPlayer3Pos = greenPlayer1.transform.position;
        greenPlayer4Pos = greenPlayer1.transform.position;

        yellowPlayer1Pos = yellowPlayer1.transform.position;
        yellowPlayer2Pos = yellowPlayer1.transform.position;
        yellowPlayer3Pos = yellowPlayer1.transform.position;
        yellowPlayer4Pos = yellowPlayer1.transform.position;

        bluePlayer1Pos = bluePlayer1.transform.position;
        bluePlayer2Pos = bluePlayer1.transform.position;
        bluePlayer3Pos = bluePlayer1.transform.position;
        bluePlayer4Pos = bluePlayer1.transform.position;

        //Deactiveting Players Round Borders
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        //Deactiveting Winnnig Scenes
        //redWinScreen.SetActive(false);
        //greenWinScreen.SetActive(false);
        //yellowWinScreen.SetActive(false);
        //blueWinScreen.SetActive(false);

        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                playerTurn = "RED";
                redFrame.SetActive(true);
                //diceRoll.position = redDiceRoll.position;
                yellowFarme.SetActive(false);


                bluePlayer1.SetActive(false);
                bluePlayer2.SetActive(false);
                bluePlayer3.SetActive(false);
                bluePlayer4.SetActive(false);

                greenPlayer1.SetActive(false);
                greenPlayer2.SetActive(false);
                greenPlayer3.SetActive(false);
                greenPlayer4.SetActive(false);

                break;

            case 3:
                playerTurn = "RED";
                redFrame.SetActive(true);
                //diceRoll.position = redDiceRoll.position;

                yellowFarme.SetActive(false);
                blueFrame.SetActive(false);

                greenPlayer1.SetActive(false);
                greenPlayer2.SetActive(false);
                greenPlayer3.SetActive(false);
                greenPlayer4.SetActive(false);
                break;

            case 4:
                playerTurn = "RED" ;
                redFrame.SetActive(true);
               // diceRoll.position = redDiceRoll.position;

                yellowFarme.SetActive(false);
                blueFrame.SetActive(false);
                greenFrame.SetActive(false);
                break;

        }

    }

    public void RedPlayer1Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Btn.interactable = false;
        redPlayer2Btn.interactable = false;
        redPlayer3Btn.interactable = false;
        redPlayer4Btn.interactable = false;

        if(playerTurn=="RED" && (redMovementBlock.Count-redPlayer1Steps>selectDiceNumAnimation))
        {
            if(selectDiceNumAnimation==6 && redPlayer1Steps==0)
            {
                Vector3[] redPlayer1Path = new Vector3[1];
                redPlayer1Path[0] = redMovementBlock[0].transform.position;
                redPlayer1Steps += 1;
                playerTurn = "RED";
                currentPlayerName = "RED PLAYER 1";
                iTween.MoveTo(redPlayer1, iTween.Hash("position",redPlayer1Path[0],"speed",125,"time",4.0f,"easetype","elastice","oncomplete","InitializeDice","oncompletetarget",this.gameObject));
               
            }

            else
            {
                Vector3[] redPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer1Path[i] = redMovementBlock[redPlayer1Steps + i].transform.position;
                }

                redPlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("path", redPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("position", redPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED PLAYER 1";
            }
        }
        else
        {
            if(playerTurn=="RED" && (redMovementBlock.Count-redPlayer1Steps)== selectDiceNumAnimation)
            {
                Vector3[] redPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer1Path[i] = redMovementBlock[redPlayer1Steps + i].transform.position;
                }
                if (redPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("path", redPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer1, iTween.Hash("position", redPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
               
                redPlayer1Steps += selectDiceNumAnimation;
                totalRedInHouse += 1;
                redPlayer1Btn.enabled = false;
                redMovementBlock.RemoveAt(redPlayer1Steps);
                Checking();
            }
            else
            {
                if(redPlayer2Steps==0 && redPlayer3Steps==0 && redPlayer4Steps== 0 && selectDiceNumAnimation!=6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                InitializeDice();
            }
        }

        
       
    }
    public void RedPlayer2Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Btn.interactable = false;
        redPlayer2Btn.interactable = false;
        redPlayer3Btn.interactable = false;
        redPlayer4Btn.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer2Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && redPlayer2Steps == 0)
            {
                Vector3[] redPlayer2Path = new Vector3[1];
                redPlayer2Path[0] = redMovementBlock[0].transform.position;
                redPlayer2Steps += 1;
                playerTurn = "RED";
                currentPlayerName = "RED PLAYER 2";
                iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] redPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer2Path[i] = redMovementBlock[redPlayer2Steps + i].transform.position;
                }

                redPlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("path", redPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED PLAYER 2";
            }
        }
        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer2Path[i] = redMovementBlock[redPlayer2Steps + i].transform.position;
                }
                if (redPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("path", redPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer2, iTween.Hash("position", redPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                
                redPlayer2Steps += selectDiceNumAnimation;
                totalRedInHouse += 1;
                redPlayer2Btn.enabled = false;
                redMovementBlock.RemoveAt(redPlayer2Steps);
                Checking();
            }
            else
            {
                if (redPlayer1Steps == 0 && redPlayer3Steps == 0 && redPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void RedPlayer3Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Btn.interactable = false;
        redPlayer2Btn.interactable = false;
        redPlayer3Btn.interactable = false;
        redPlayer4Btn.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer3Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && redPlayer3Steps == 0)
            {
                Vector3[] redPlayer3Path = new Vector3[1];
                redPlayer3Path[0] = redMovementBlock[0].transform.position;
                redPlayer3Steps += 1;
                playerTurn = "RED";
                currentPlayerName = "RED PLAYER 3";
                iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] redPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer3Path[i] = redMovementBlock[redPlayer3Steps + i].transform.position;
                }

                redPlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("path", redPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED PLAYER 3";
            }
        }
        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer3Path[i] = redMovementBlock[redPlayer3Steps + i].transform.position;
                }
                if (redPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("path", redPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer3, iTween.Hash("position", redPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                redPlayer3Steps += selectDiceNumAnimation;
                totalRedInHouse += 1;
                redPlayer3Btn.enabled = false;
                redMovementBlock.RemoveAt(redPlayer3Steps);
                Checking();
            }
            else
            {
                if (redPlayer2Steps == 0 && redPlayer1Steps == 0 && redPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void RedPlayer4Movement()
    {
        redPlayer1Border.SetActive(false);
        redPlayer2Border.SetActive(false);
        redPlayer3Border.SetActive(false);
        redPlayer4Border.SetActive(false);

        redPlayer1Btn.interactable = false;
        redPlayer2Btn.interactable = false;
        redPlayer3Btn.interactable = false;
        redPlayer4Btn.interactable = false;

        if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer4Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && redPlayer4Steps == 0)
            {
                Vector3[] redPlayer4Path = new Vector3[1];
                redPlayer4Path[0] = redMovementBlock[0].transform.position;
                redPlayer4Steps += 1;
                playerTurn = "RED";
                currentPlayerName = "RED PLAYER 4";
                iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] redPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer4Path[i] = redMovementBlock[redPlayer4Steps + i].transform.position;
                }

                redPlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("path", redPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED PLAYER 4";
            }
        }
        else
        {
            if (playerTurn == "RED" && (redMovementBlock.Count - redPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer4Path[i] = redMovementBlock[redPlayer4Steps + i].transform.position;
                }
                if (redPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("path", redPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayer4, iTween.Hash("position", redPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                redPlayer4Steps += selectDiceNumAnimation;
                totalRedInHouse += 1;
                redPlayer4Btn.enabled = false;
                redMovementBlock.RemoveAt(redPlayer4Steps);
                Checking();
            }
            else
            {
                if (redPlayer2Steps == 0 && redPlayer3Steps == 0 && redPlayer1Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void YellowPlayer1Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Btn.interactable = false;
        yellowPlayer2Btn.interactable = false;
        yellowPlayer3Btn.interactable = false;
        yellowPlayer4Btn.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer1Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && yellowPlayer1Steps == 0)
            {
                Vector3[] yellowPlayer1Path = new Vector3[1];
                yellowPlayer1Path[0] = yellowMovementBlock[0].transform.position;
                yellowPlayer1Steps += 1;
                playerTurn = "YELLOW";
                currentPlayerName = "YELLOW PLAYER 1";
                iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] yellowPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer1Path[i] = yellowMovementBlock[yellowPlayer1Steps + i].transform.position;
                }

                yellowPlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (yellowPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("path", yellowPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW PLAYER 1";
            }
        }
        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer1Path[i] = yellowMovementBlock[yellowPlayer1Steps + i].transform.position;
                }
                if (yellowPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("path", yellowPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer1, iTween.Hash("position", yellowPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                
                SoundManager.goInHouseAusioSource.Play();
                yellowPlayer1Steps += selectDiceNumAnimation;
                totalYellowInHouse += 1;
                yellowPlayer1Btn.enabled = false;
                yellowMovementBlock.RemoveAt(yellowPlayer1Steps);
                Checking();
            }
            else
            {
                if (yellowPlayer2Steps == 0 && yellowPlayer3Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void YellowPlayer2Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Btn.interactable = false;
        yellowPlayer2Btn.interactable = false;
        yellowPlayer3Btn.interactable = false;
        yellowPlayer4Btn.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer2Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && yellowPlayer2Steps == 0)
            {
                Vector3[] yellowPlayer2Path = new Vector3[1];
                yellowPlayer2Path[0] = yellowMovementBlock[0].transform.position;
                yellowPlayer2Steps += 1;
                playerTurn = "YELLOW";
                currentPlayerName = "YELLOW PLAYER 2";
                iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] yellowPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer2Path[i] = yellowMovementBlock[yellowPlayer2Steps + i].transform.position;
                }

                yellowPlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (yellowPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("path", yellowPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW PLAYER 2";
            }
        }
        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer2Path[i] = yellowMovementBlock[yellowPlayer2Steps + i].transform.position;
                }
                if (yellowPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("path", yellowPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer2, iTween.Hash("position", yellowPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                yellowPlayer2Steps += selectDiceNumAnimation;
                totalYellowInHouse += 1;
                yellowPlayer2Btn.enabled = false;
                yellowMovementBlock.RemoveAt(yellowPlayer2Steps);
                Checking();
            }
            else
            {
                if (yellowPlayer1Steps == 0 && yellowPlayer3Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void YellowPlayer3Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Btn.interactable = false;
        yellowPlayer2Btn.interactable = false;
        yellowPlayer3Btn.interactable = false;
        yellowPlayer4Btn.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer3Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && yellowPlayer3Steps == 0)
            {
                Vector3[] yellowPlayer3Path = new Vector3[1];
                yellowPlayer3Path[0] = yellowMovementBlock[0].transform.position;
                yellowPlayer3Steps += 1;
                playerTurn = "YELLOW";
                currentPlayerName = "YELLOW PLAYER 3";
                iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] yellowPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer3Path[i] = yellowMovementBlock[yellowPlayer3Steps + i].transform.position;
                }

                yellowPlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (yellowPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("path", yellowPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW PLAYER 3";
            }
        }
        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer3Path[i] = yellowMovementBlock[yellowPlayer3Steps + i].transform.position;
                }
                if (yellowPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("path", yellowPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer3, iTween.Hash("position", yellowPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
               
                SoundManager.goInHouseAusioSource.Play();
                yellowPlayer3Steps += selectDiceNumAnimation;
                totalYellowInHouse += 1;
                yellowPlayer3Btn.enabled = false;
                yellowMovementBlock.RemoveAt(yellowPlayer3Steps);
                Checking();
            }
            else
            {
                if (yellowPlayer2Steps == 0 && yellowPlayer1Steps == 0 && yellowPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void YellowPlayer4Movement()
    {
        yellowPlayer1Border.SetActive(false);
        yellowPlayer2Border.SetActive(false);
        yellowPlayer3Border.SetActive(false);
        yellowPlayer4Border.SetActive(false);

        yellowPlayer1Btn.interactable = false;
        yellowPlayer2Btn.interactable = false;
        yellowPlayer3Btn.interactable = false;
        yellowPlayer4Btn.interactable = false;

        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer4Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && yellowPlayer4Steps == 0)
            {
                Vector3[] yellowPlayer4Path = new Vector3[1];
                yellowPlayer4Path[0] = yellowMovementBlock[0].transform.position;
                yellowPlayer4Steps += 1;
                playerTurn = "YELLOW";
                currentPlayerName = "YELLOW PLAYER 4";
                iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] yellowPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer4Path[i] = yellowMovementBlock[yellowPlayer4Steps + i].transform.position;
                }

                yellowPlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }

                if (yellowPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("path", yellowPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW PLAYER 4";
            }
        }
        else
        {
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayer4Path[i] = yellowMovementBlock[yellowPlayer4Steps + i].transform.position;
                }
                if (yellowPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("path", yellowPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowPlayer4, iTween.Hash("position", yellowPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                yellowPlayer4Steps += selectDiceNumAnimation;
                totalYellowInHouse += 1;
                yellowPlayer4Btn.enabled = false;
                yellowMovementBlock.RemoveAt(yellowPlayer4Steps);
                Checking();
            }
            else
            {
                if (yellowPlayer2Steps == 0 && yellowPlayer3Steps == 0 && yellowPlayer1Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void bluePlayer1Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Btn.interactable = false;
        bluePlayer2Btn.interactable = false;
        bluePlayer3Btn.interactable = false;
        bluePlayer4Btn.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer1Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && bluePlayer1Steps == 0)
            {
                Vector3[] bluePlayer1Path = new Vector3[1];
                bluePlayer1Path[0] = blueMovementBlock[0].transform.position;
                bluePlayer1Steps += 1;
                playerTurn = "BLUE";
                currentPlayerName = "BLUE PLAYER 1";
                iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] bluePlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer1Path[i] = blueMovementBlock[bluePlayer1Steps + i].transform.position;
                }

                bluePlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                       
                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (bluePlayer1Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("path", bluePlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "blue PLAYER 1";
            }
        }
        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer1Path[i] = blueMovementBlock[bluePlayer1Steps + i].transform.position;
                }
                if (bluePlayer1Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("path", bluePlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer1, iTween.Hash("position", bluePlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                bluePlayer1Steps += selectDiceNumAnimation;
                totalBlueInHouse += 1;
                bluePlayer1Btn.enabled = false;
                blueMovementBlock.RemoveAt(bluePlayer1Steps);
                Checking();
            }
            else
            {
                if (bluePlayer2Steps == 0 && bluePlayer3Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void bluePlayer2Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Btn.interactable = false;
        bluePlayer2Btn.interactable = false;
        bluePlayer3Btn.interactable = false;
        bluePlayer4Btn.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer2Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && bluePlayer2Steps == 0)
            {
                Vector3[] bluePlayer2Path = new Vector3[1];
                bluePlayer2Path[0] = blueMovementBlock[0].transform.position;
                bluePlayer2Steps += 1;
                playerTurn = "BLUE";
                currentPlayerName = "BLUE PLAYER 2";
                iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] bluePlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer2Path[i] = blueMovementBlock[bluePlayer2Steps + i].transform.position;
                }

                bluePlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (bluePlayer2Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("path", bluePlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "blue PLAYER 2";
            }
        }
        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer2Path[i] = blueMovementBlock[bluePlayer2Steps + i].transform.position;
                }
                if (bluePlayer2Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("path", bluePlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer2, iTween.Hash("position", bluePlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                bluePlayer2Steps += selectDiceNumAnimation;
                totalBlueInHouse += 1;
                bluePlayer2Btn.enabled = false;
                blueMovementBlock.RemoveAt(bluePlayer2Steps);
                Checking();
            }
            else
            {
                if (bluePlayer1Steps == 0 && bluePlayer3Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void bluePlayer3Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Btn.interactable = false;
        bluePlayer2Btn.interactable = false;
        bluePlayer3Btn.interactable = false;
        bluePlayer4Btn.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer3Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && bluePlayer3Steps == 0)
            {
                Vector3[] bluePlayer3Path = new Vector3[1];
                bluePlayer3Path[0] = blueMovementBlock[0].transform.position;
                bluePlayer3Steps += 1;
                playerTurn = "BLUE";
                currentPlayerName = "BLUE PLAYER 3";
                iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] bluePlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer3Path[i] = blueMovementBlock[bluePlayer3Steps + i].transform.position;
                }

                bluePlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (bluePlayer3Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("path", bluePlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "blue PLAYER 3";
            }
        }
        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer3Path[i] = blueMovementBlock[bluePlayer3Steps + i].transform.position;
                }
                if (bluePlayer3Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("path", bluePlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer3, iTween.Hash("position", bluePlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                bluePlayer3Steps += selectDiceNumAnimation;
                totalBlueInHouse += 1;
                bluePlayer3Btn.enabled = false;
                blueMovementBlock.RemoveAt(bluePlayer3Steps);
                Checking();
            }
            else
            {
                if (bluePlayer2Steps == 0 && bluePlayer1Steps == 0 && bluePlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void bluePlayer4Movement()
    {
        bluePlayer1Border.SetActive(false);
        bluePlayer2Border.SetActive(false);
        bluePlayer3Border.SetActive(false);
        bluePlayer4Border.SetActive(false);

        bluePlayer1Btn.interactable = false;
        bluePlayer2Btn.interactable = false;
        bluePlayer3Btn.interactable = false;
        bluePlayer4Btn.interactable = false;

        if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer4Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && bluePlayer4Steps == 0)
            {
                Vector3[] bluePlayer4Path = new Vector3[1];
                bluePlayer4Path[0] = blueMovementBlock[0].transform.position;
                bluePlayer4Steps += 1;
                playerTurn = "BLUE";
                currentPlayerName = "BLUE PLAYER 4";
                iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] bluePlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer4Path[i] = blueMovementBlock[bluePlayer4Steps + i].transform.position;
                }

                bluePlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                if (bluePlayer4Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("path", bluePlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "blue PLAYER 4";
            }
        }
        else
        {
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - bluePlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayer4Path[i] = blueMovementBlock[bluePlayer4Steps + i].transform.position;
                }
                if (bluePlayer4Path.Length > 1)
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("path", bluePlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(bluePlayer4, iTween.Hash("position", bluePlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                bluePlayer4Steps += selectDiceNumAnimation;
                totalBlueInHouse += 1;
                bluePlayer4Btn.enabled = false;
                blueMovementBlock.RemoveAt(bluePlayer4Steps);
                Checking();
            }
            else
            {
                if (bluePlayer2Steps == 0 && bluePlayer3Steps == 0 && bluePlayer1Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void GreenPlayer1Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Btn.interactable = false;
        greenPlayer2Btn.interactable = false;
        greenPlayer3Btn.interactable = false;
        greenPlayer4Btn.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer1Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && greenPlayer1Steps == 0)
            {
                Vector3[] greenPlayer1Path = new Vector3[1];
                greenPlayer1Path[0] = greenMovementBlock[0].transform.position;
                greenPlayer1Steps += 1;
                playerTurn = "GREEN";
                currentPlayerName = "GREEN PLAYER 1";
                iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] greenPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer1Path[i] = greenMovementBlock[greenPlayer1Steps + i].transform.position;
                }

                greenPlayer1Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (greenPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("path", greenPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN PLAYER 1";
            }
        }
        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer1Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer1Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer1Path[i] = greenMovementBlock[greenPlayer1Steps + i].transform.position;
                }
                if (greenPlayer1Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("path", greenPlayer1Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer1, iTween.Hash("position", greenPlayer1Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                greenPlayer1Steps += selectDiceNumAnimation;
                totalGreenInHouse += 1;
                greenPlayer1Btn.enabled = false;
                greenMovementBlock.RemoveAt(greenPlayer1Steps);
                Checking();
            }
            else
            {
                if (greenPlayer2Steps == 0 && greenPlayer3Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void GreenPlayer2Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Btn.interactable = false;
        greenPlayer2Btn.interactable = false;
        greenPlayer3Btn.interactable = false;
        greenPlayer4Btn.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer2Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && greenPlayer2Steps == 0)
            {
                Vector3[] greenPlayer2Path = new Vector3[1];
                greenPlayer2Path[0] = greenMovementBlock[0].transform.position;
                greenPlayer2Steps += 1;
                playerTurn = "GREEN";
                currentPlayerName = "GREEN PLAYER 2";
                iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] greenPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer2Path[i] = greenMovementBlock[greenPlayer2Steps + i].transform.position;
                }

                greenPlayer2Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (greenPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("path", greenPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN PLAYER 2";
            }
        }
        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer2Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer2Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer2Path[i] = greenMovementBlock[greenPlayer2Steps + i].transform.position;
                }
                if (greenPlayer2Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("path", greenPlayer2Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer2, iTween.Hash("position", greenPlayer2Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                
                greenPlayer2Steps += selectDiceNumAnimation;
                totalGreenInHouse += 1;
                greenPlayer2Btn.enabled = false;
                greenMovementBlock.RemoveAt(greenPlayer2Steps);
                Checking();
            }
            else
            {
                if (greenPlayer1Steps == 0 && greenPlayer3Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void GreenPlayer3Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Btn.interactable = false;
        greenPlayer2Btn.interactable = false;
        greenPlayer3Btn.interactable = false;
        greenPlayer4Btn.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer3Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && greenPlayer3Steps == 0)
            {
                Vector3[] greenPlayer3Path = new Vector3[1];
                greenPlayer3Path[0] = greenMovementBlock[0].transform.position;
                greenPlayer3Steps += 1;
                playerTurn = "GREEN";
                currentPlayerName = "GREEN PLAYER 3";
                iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] greenPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer3Path[i] = greenMovementBlock[greenPlayer3Steps + i].transform.position;
                }

                greenPlayer3Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (greenPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("path", greenPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN PLAYER 3";
            }
        }
        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer3Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer3Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer3Path[i] = greenMovementBlock[greenPlayer3Steps + i].transform.position;
                }
                if (greenPlayer3Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("path", greenPlayer3Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer3, iTween.Hash("position", greenPlayer3Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                greenPlayer3Steps += selectDiceNumAnimation;
                totalGreenInHouse += 1;
                greenPlayer3Btn.enabled = false;
                greenMovementBlock.RemoveAt(greenPlayer3Steps);
                Checking();
            }
            else
            {
                if (greenPlayer2Steps == 0 && greenPlayer1Steps == 0 && greenPlayer4Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }
    public void GreenPlayer4Movement()
    {
        greenPlayer1Border.SetActive(false);
        greenPlayer2Border.SetActive(false);
        greenPlayer3Border.SetActive(false);
        greenPlayer4Border.SetActive(false);

        greenPlayer1Btn.interactable = false;
        greenPlayer2Btn.interactable = false;
        greenPlayer3Btn.interactable = false;
        greenPlayer4Btn.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer4Steps > selectDiceNumAnimation))
        {
            if (selectDiceNumAnimation == 6 && greenPlayer1Steps == 0)
            {
                Vector3[] greenPlayer4Path = new Vector3[1];
                greenPlayer4Path[0] = greenMovementBlock[0].transform.position;
                greenPlayer4Steps += 1;
                playerTurn = "GREEN";
                currentPlayerName = "GREEN PLAYER 4";
                iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 125, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

            }

            else
            {
                Vector3[] greenPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer4Path[i] = greenMovementBlock[greenPlayer4Steps + i].transform.position;
                }

                greenPlayer4Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }

                if (greenPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("path", greenPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN PLAYER 4";
            }
        }
        else
        {
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayer4Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer4Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer4Path[i] = greenMovementBlock[greenPlayer4Steps + i].transform.position;
                }
                if (greenPlayer4Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("path", greenPlayer4Path, "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayer4, iTween.Hash("position", greenPlayer4Path[0], "speed", 25, "time", 4.0f, "easetype", "elastice", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                SoundManager.goInHouseAusioSource.Play();
                greenPlayer4Steps += selectDiceNumAnimation;
                totalGreenInHouse += 1;
                greenPlayer4Btn.enabled = false;
                greenMovementBlock.RemoveAt(greenPlayer4Steps);
                Checking();
            }
            else
            {
                if (greenPlayer2Steps == 0 && greenPlayer3Steps == 0 && greenPlayer1Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                InitializeDice();
            }
        }



    }



    private void InitializeDice()
    {
 
        diceRollButton.interactable = true;

        dice1Animation.SetActive(false);
        dice2Animation.SetActive(false);
        dice3Animation.SetActive(false);
        dice4Animation.SetActive(false);
        dice5Animation.SetActive(false);
        dice6Animation.SetActive(false);

       // getting currentPlayer value
        if (currentPlayerName.Contains("RED PLAYER"))
        {
            if (currentPlayerName == "RED PLAYER 1")
            {
                currentPlayer = RedPlayerOne.redPlayer1ColName;
            }
            if (currentPlayerName == "RED PLAYER 2")
            {
                currentPlayer = RedPlayertwo.redPlayer2ColName;
            }
            if (currentPlayerName == "RED PLAYER 3")
            {
                currentPlayer = RedPlayerThree.redPlayer3ColName;
            }
            if (currentPlayerName == "RED PLAYER 4")
            {
                currentPlayer = RedPlayerFour.redPlayer4ColName;
            }

        }
        if (currentPlayerName.Contains("YELLOW PLAYER"))
        {
            if (currentPlayerName == "YELLOW PLAYER 1")
            {
                currentPlayer = YellowPlayerOne.yellowPlayer1ColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 2")
            {
                currentPlayer = YellowPlayerTwo.yellowPlayer2ColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 3")
            {
                currentPlayer = YellowPlayerThree.yellowPlayer3ColName;
            }
            if (currentPlayerName == "YELLOW PLAYER 4")
            {
                currentPlayer = YellowPlayerFour.yellowPlayer4ColName;
            }

        }
        if (currentPlayerName.Contains("BLUE PLAYER"))
        {
            if (currentPlayerName == "BLUE PLAYER 1")
            {
                currentPlayer = BluePlayerOne.bluePlayer1ColName;
            }
            if (currentPlayerName == "BLUE PLAYER 2")
            {
                currentPlayer = BluePlayerTwo.bluePlayer2ColName;
            }
            if (currentPlayerName == "BLUE PLAYER 3")
            {
                currentPlayer = BluePlayerthree.bluePlayer3ColName;
            }
            if (currentPlayerName == "BLUE PLAYER 4")
            {
                currentPlayer = BluePlayerFour.bluePlayer4ColName;
            }

        }
        if (currentPlayerName.Contains("GREEN PLAYER"))
        {
            if (currentPlayerName == "GREEN PLAYER 1")
            {
                currentPlayer = GreenPlayerOne.greenPlayer1ColName;
            }
            if (currentPlayerName == "GREEN PLAYER 2")
            {
                currentPlayer = GreenPlayerTwo.greenPlayer2ColName;
            }
            if (currentPlayerName == "GREEN PLAYER 3")
            {
                currentPlayer = GreenPlayerThree.greenPlayer3ColName;
            }
            if (currentPlayerName == "GREEN PLAYER 4")
            {
                currentPlayer = GreenPlayerFour.greenPlayer4ColName;
            }

        }

        //player vs enemy
        if(currentPlayerName !="none")
        {
            switch(MainMenuManager.howManyPlayers)
            {
                case 2:
                    if (currentPlayerName.Contains("RED PLAYER"))
                    {
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName  )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }

                    }
                    if (currentPlayerName.Contains("YELLOW PLAYER"))
                    {
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                    }
                    break;
                case 3:
                    if (currentPlayerName.Contains("RED PLAYER"))
                    {
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }

                        if (currentPlayerName == BluePlayerOne.bluePlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer1.transform.position = bluePlayer1Pos;
                            BluePlayerOne.bluePlayer1ColName = "none";
                            bluePlayer1Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerTwo.bluePlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer2.transform.position = bluePlayer2Pos;
                            BluePlayerTwo.bluePlayer2ColName = "none";
                            bluePlayer2Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerthree.bluePlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer3.transform.position = bluePlayer3Pos;
                            BluePlayerthree.bluePlayer3ColName = "none";
                            bluePlayer3Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerFour.bluePlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer4.transform.position = bluePlayer4Pos;
                            BluePlayerFour.bluePlayer4ColName = "none";
                            bluePlayer4Steps = 0;
                            playerTurn = "BLUE";
                        }

                    }
                    if (currentPlayerName.Contains("YELLOW PLAYER"))
                    {
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == BluePlayerOne.bluePlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer1.transform.position = bluePlayer1Pos;
                            BluePlayerOne.bluePlayer1ColName = "none";
                            bluePlayer1Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerTwo.bluePlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer2.transform.position = bluePlayer2Pos;
                            BluePlayerTwo.bluePlayer2ColName = "none";
                            bluePlayer2Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerthree.bluePlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer3.transform.position = bluePlayer3Pos;
                            BluePlayerthree.bluePlayer3ColName = "none";
                            bluePlayer3Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerFour.bluePlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer4.transform.position = bluePlayer4Pos;
                            BluePlayerFour.bluePlayer4ColName = "none";
                            bluePlayer4Steps = 0;
                            playerTurn = "BLUE";
                        }
                    }
                    if(currentPlayerName.Contains("BLUE PLAYER"))
                    {
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                    }
                    break;
                case 4:
                    if (currentPlayerName.Contains("RED PLAYER"))
                    {
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }

                        if (currentPlayerName == BluePlayerOne.bluePlayer1ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer1.transform.position = bluePlayer1Pos;
                            BluePlayerOne.bluePlayer1ColName = "none";
                            bluePlayer1Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerTwo.bluePlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer2.transform.position = bluePlayer2Pos;
                            BluePlayerTwo.bluePlayer2ColName = "none";
                            bluePlayer2Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerthree.bluePlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer3.transform.position = bluePlayer3Pos;
                            BluePlayerthree.bluePlayer3ColName = "none";
                            bluePlayer3Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerFour.bluePlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer4.transform.position = bluePlayer4Pos;
                            BluePlayerFour.bluePlayer4ColName = "none";
                            bluePlayer4Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == GreenPlayerOne.greenPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer1.transform.position = greenPlayer1Pos;
                            GreenPlayerOne.greenPlayer1ColName = "none";
                            greenPlayer1Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerTwo.greenPlayer2ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer2.transform.position = greenPlayer2Pos;
                            GreenPlayerTwo.greenPlayer2ColName = "none";
                            greenPlayer2Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerThree.greenPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer3.transform.position = greenPlayer3Pos;
                            GreenPlayerThree.greenPlayer3ColName = "none";
                            greenPlayer3Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerFour.greenPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer4.transform.position = greenPlayer4Pos;
                            GreenPlayerFour.greenPlayer4ColName = "none";
                            greenPlayer4Steps = 0;
                            playerTurn = "GREEN";
                        }

                    }
                    if (currentPlayerName.Contains("YELLOW PLAYER"))
                    {
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == BluePlayerOne.bluePlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer1.transform.position = bluePlayer1Pos;
                            BluePlayerOne.bluePlayer1ColName = "none";
                            bluePlayer1Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerTwo.bluePlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer2.transform.position = bluePlayer2Pos;
                            BluePlayerTwo.bluePlayer2ColName = "none";
                            bluePlayer2Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerthree.bluePlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer3.transform.position = bluePlayer3Pos;
                            BluePlayerthree.bluePlayer3ColName = "none";
                            bluePlayer3Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerFour.bluePlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer4.transform.position = bluePlayer4Pos;
                            BluePlayerFour.bluePlayer4ColName = "none";
                            bluePlayer4Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == GreenPlayerOne.greenPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer1.transform.position = greenPlayer1Pos;
                            GreenPlayerOne.greenPlayer1ColName = "none";
                            greenPlayer1Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerTwo.greenPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer2.transform.position = greenPlayer2Pos;
                            GreenPlayerTwo.greenPlayer2ColName = "none";
                            greenPlayer2Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerThree.greenPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer3.transform.position = greenPlayer3Pos;
                            GreenPlayerThree.greenPlayer3ColName = "none";
                            greenPlayer3Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerFour.greenPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer4.transform.position = greenPlayer4Pos;
                            GreenPlayerFour.greenPlayer4ColName = "none";
                            greenPlayer4Steps = 0;
                            playerTurn = "GREEN";
                        }
                    }
                    if (currentPlayerName.Contains("BLUE PLAYER"))
                    {
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName  )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == GreenPlayerOne.greenPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer1.transform.position = greenPlayer1Pos;
                            GreenPlayerOne.greenPlayer1ColName = "none";
                            greenPlayer1Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerTwo.greenPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer2.transform.position = greenPlayer2Pos;
                            GreenPlayerTwo.greenPlayer2ColName = "none";
                            greenPlayer2Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerThree.greenPlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer3.transform.position = greenPlayer3Pos;
                            GreenPlayerThree.greenPlayer3ColName = "none";
                            greenPlayer3Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayerName == GreenPlayerFour.greenPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            greenPlayer4.transform.position = greenPlayer4Pos;
                            GreenPlayerFour.greenPlayer4ColName = "none";
                            greenPlayer4Steps = 0;
                            playerTurn = "GREEN";
                        }
                    }
                    if(currentPlayerName.Contains("GREEN PLAYER"))
                    {
                        if (currentPlayerName == RedPlayerOne.redPlayer1ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer1.transform.position = redPlayer1Pos;
                            RedPlayerOne.redPlayer1ColName = "none";
                            redPlayer1Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayertwo.redPlayer2ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer2.transform.position = redPlayer2Pos;
                            RedPlayertwo.redPlayer2ColName = "none";
                            redPlayer2Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerThree.redPlayer3ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer3.transform.position = redPlayer3Pos;
                            RedPlayerThree.redPlayer3ColName = "none";
                            redPlayer3Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == RedPlayerFour.redPlayer4ColName)
                        {
                            SoundManager.failAusioSource.Play();
                            redPlayer4.transform.position = redPlayer4Pos;
                            RedPlayerFour.redPlayer4ColName = "none";
                            redPlayer4Steps = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayerName == BluePlayerOne.bluePlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer1.transform.position = bluePlayer1Pos;
                            BluePlayerOne.bluePlayer1ColName = "none";
                            bluePlayer1Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerTwo.bluePlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer2.transform.position = bluePlayer2Pos;
                            BluePlayerTwo.bluePlayer2ColName = "none";
                            bluePlayer2Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerthree.bluePlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer3.transform.position = bluePlayer3Pos;
                            BluePlayerthree.bluePlayer3ColName = "none";
                            bluePlayer3Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == BluePlayerFour.bluePlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            bluePlayer4.transform.position = bluePlayer4Pos;
                            BluePlayerFour.bluePlayer4ColName = "none";
                            bluePlayer4Steps = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayerName == YellowPlayerOne.yellowPlayer1ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer1.transform.position = yellowPlayer1Pos;
                            YellowPlayerOne.yellowPlayer1ColName = "none";
                            yellowPlayer1Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerTwo.yellowPlayer2ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer2.transform.position = yellowPlayer2Pos;
                            YellowPlayerTwo.yellowPlayer2ColName = "none";
                            yellowPlayer2Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerThree.yellowPlayer3ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer3.transform.position = yellowPlayer3Pos;
                            YellowPlayerThree.yellowPlayer3ColName = "none";
                            yellowPlayer3Steps = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayerName == YellowPlayerFour.yellowPlayer4ColName )
                        {
                            SoundManager.failAusioSource.Play();
                            yellowPlayer4.transform.position = yellowPlayer4Pos;
                            YellowPlayerFour.yellowPlayer4ColName = "none";
                            yellowPlayer4Steps = 0;
                            playerTurn = "YELLOW";
                        }
                    }
                    break;

            }
        }

        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                if (playerTurn == "YELLOW")
                {
                    
                    yellowFarme.SetActive(true);
                    redFrame.SetActive(false);
                }

                if (playerTurn == "RED")
                {
                   
                    redFrame.SetActive(true);
                    yellowFarme.SetActive(false);
                }

                yellowPlayer1.GetComponent<YellowPlayerOne>().enabled = false;
                yellowPlayer2.GetComponent<YellowPlayerTwo>().enabled = false;
                yellowPlayer3.GetComponent<YellowPlayerThree>().enabled = false;
                yellowPlayer4.GetComponent<YellowPlayerFour>().enabled = false;

                yellowPlayer1Btn.interactable = false;
                yellowPlayer2Btn.interactable = false;
                yellowPlayer3Btn.interactable = false;
                yellowPlayer4Btn.interactable = false;

                redPlayer1Btn.interactable = false;
                redPlayer2Btn.interactable = false;
                redPlayer3Btn.interactable = false;
                redPlayer4Btn.interactable = false;

                redPlayer1.GetComponent<RedPlayerOne>().enabled = false;
                redPlayer2.GetComponent<RedPlayertwo>().enabled = false;
                redPlayer3.GetComponent<RedPlayerThree>().enabled = false;
                redPlayer4.GetComponent<RedPlayerFour>().enabled = false;

                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                yellowPlayer1Border.SetActive(false);
                yellowPlayer2Border.SetActive(false);
                yellowPlayer3Border.SetActive(false);
                yellowPlayer4Border.SetActive(false);
                break;

            case 3:
                if (playerTurn == "YELLOW")
                {
                    
                    yellowFarme.SetActive(true);
                    redFrame.SetActive(false);
                    blueFrame.SetActive(false);
                }

                if (playerTurn == "RED")
                {
                   
                    redFrame.SetActive(true);
                    yellowFarme.SetActive(false);
                    blueFrame.SetActive(false);
                }

                if (playerTurn == "BLUE")
                {
                    
                    blueFrame.SetActive(true);
                    redFrame.SetActive(false);
                    yellowFarme.SetActive(false);
                }

                yellowPlayer1Btn.interactable = false;
                yellowPlayer2Btn.interactable = false;
                yellowPlayer3Btn.interactable = false;
                yellowPlayer4Btn.interactable = false;

                redPlayer1Btn.interactable = false;
                redPlayer2Btn.interactable = false;
                redPlayer3Btn.interactable = false;
                redPlayer4Btn.interactable = false;

                bluePlayer1Btn.interactable = false;
                bluePlayer2Btn.interactable = false;
                bluePlayer3Btn.interactable = false;
                bluePlayer4Btn.interactable = false;

                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                yellowPlayer1Border.SetActive(false);
                yellowPlayer2Border.SetActive(false);
                yellowPlayer3Border.SetActive(false);
                yellowPlayer4Border.SetActive(false);

                bluePlayer1Border.SetActive(false);
                bluePlayer2Border.SetActive(false);
                bluePlayer3Border.SetActive(false);
                bluePlayer4Border.SetActive(false);
                break;

            case 4:
                if (playerTurn == "YELLOW")
                {
                    
                    yellowFarme.SetActive(true);
                    redFrame.SetActive(false);
                    blueFrame.SetActive(false);
                    greenFrame.SetActive(false);
                }

                if (playerTurn == "RED")
                {
                  
                    redFrame.SetActive(true);
                    yellowFarme.SetActive(false);
                    blueFrame.SetActive(false);
                    greenFrame.SetActive(false);
                }

                if (playerTurn == "BLUE")
                {
                   
                    blueFrame.SetActive(true);
                    redFrame.SetActive(false);
                    yellowFarme.SetActive(false);
                    greenFrame.SetActive(false);
                }

                if (playerTurn == "GREEN")
                {
                    
                    greenFrame.SetActive(true);
                    redFrame.SetActive(false);
                    yellowFarme.SetActive(false);
                    blueFrame.SetActive(false);

                }

                yellowPlayer1Btn.interactable = false;
                yellowPlayer2Btn.interactable = false;
                yellowPlayer3Btn.interactable = false;
                yellowPlayer4Btn.interactable = false;

                redPlayer1Btn.interactable = false;
                redPlayer2Btn.interactable = false;
                redPlayer3Btn.interactable = false;
                redPlayer4Btn.interactable = false;

                bluePlayer1Btn.interactable = false;
                bluePlayer2Btn.interactable = false;
                bluePlayer3Btn.interactable = false;
                bluePlayer4Btn.interactable = false;

                greenPlayer1Btn.interactable = false;
                greenPlayer2Btn.interactable = false;
                greenPlayer3Btn.interactable = false;
                greenPlayer4Btn.interactable = false;


                redPlayer1Border.SetActive(false);
                redPlayer2Border.SetActive(false);
                redPlayer3Border.SetActive(false);
                redPlayer4Border.SetActive(false);

                yellowPlayer1Border.SetActive(false);
                yellowPlayer2Border.SetActive(false);
                yellowPlayer3Border.SetActive(false);
                yellowPlayer4Border.SetActive(false);

                bluePlayer1Border.SetActive(false);
                bluePlayer2Border.SetActive(false);
                bluePlayer3Border.SetActive(false);
                bluePlayer4Border.SetActive(false);

                greenPlayer1Border.SetActive(false);
                greenPlayer2Border.SetActive(false);
                greenPlayer3Border.SetActive(false);
                greenPlayer4Border.SetActive(false);
                break;
        }

    }
    public void DiceRoll()
    {
        SoundManager.diceRollingAusioSource.Play();
        diceRollButton.interactable = false;
        selectDiceNumAnimation = randNo.Next(1, 7);
        //selectDiceNumAnimation = 6;

        switch(selectDiceNumAnimation)
        {
            case 1:
                dice1Animation.SetActive(true);
                break;

            case 2:
                dice2Animation.SetActive(true);
                break;

            case 3:
                dice3Animation.SetActive(true);
                break;

            case 4:
                dice4Animation.SetActive(true);
                break;

            case 5:
                dice5Animation.SetActive(true);
                break;

            case 6:
                dice6Animation.SetActive(true);
                break;
        }
        StartCoroutine("PlayersNotInitialized");
    }

   IEnumerator PlayersNotInitialized()
    {
        yield return new WaitForSeconds(1f);

        switch(playerTurn)
        {
            case "RED":

               //when players can get out of house
              if(selectDiceNumAnimation==6 && redPlayer1Steps==0)
                {
                    redPlayer1Border.SetActive(true);
                    redPlayer1Btn.interactable = true;
                    redPlayer1.GetComponent<RedPlayerOne>().enabled = true;
                }
              
                if (selectDiceNumAnimation == 6 && redPlayer2Steps == 0)
                {
                    redPlayer2Border.SetActive(true);
                    redPlayer2Btn.interactable = true;
                    redPlayer2.GetComponent<RedPlayertwo>().enabled = true;
                }
                if (selectDiceNumAnimation == 6 && redPlayer3Steps == 0)
                {
                    redPlayer3Border.SetActive(true);
                    redPlayer3Btn.interactable = true;
                    redPlayer3.GetComponent<RedPlayerThree>().enabled = true;
                }
                if (selectDiceNumAnimation == 6 && redPlayer4Steps == 0)
                {
                    redPlayer4Border.SetActive(true);
                    redPlayer4Btn.interactable = true;
                    redPlayer4.GetComponent<RedPlayerFour>().enabled = true;
                }
                //if player is out of house
                if((redMovementBlock.Count-redPlayer1Steps)>= selectDiceNumAnimation && redPlayer1Steps>0 &&(redMovementBlock.Count>redPlayer1Steps))
                {
                    redPlayer1Border.SetActive(true);
                    redPlayer1Btn.interactable = true;
                    redPlayer1.GetComponent<RedPlayerOne>().enabled = true;
                }
                if ((redMovementBlock.Count - redPlayer2Steps) >= selectDiceNumAnimation && redPlayer2Steps > 0 && (redMovementBlock.Count > redPlayer2Steps))
                {
                    redPlayer2Border.SetActive(true);
                    redPlayer2Btn.interactable = true;
                    redPlayer2.GetComponent<RedPlayertwo>().enabled = true;
                }
                if ((redMovementBlock.Count - redPlayer3Steps) >= selectDiceNumAnimation && redPlayer3Steps > 0 && (redMovementBlock.Count > redPlayer3Steps))
                {
                    redPlayer3Border.SetActive(true);
                    redPlayer3Btn.interactable = true;
                    redPlayer3.GetComponent<RedPlayerThree>().enabled = true;
                }
                if ((redMovementBlock.Count - redPlayer4Steps) >= selectDiceNumAnimation && redPlayer4Steps > 0 && (redMovementBlock.Count > redPlayer4Steps))
                {
                    redPlayer4Border.SetActive(true);
                    redPlayer4Btn.interactable = true;
                    redPlayer4.GetComponent<RedPlayerFour>().enabled = true;
                }

                //if player dont move then switch it
                if (!redPlayer1Border.activeInHierarchy && !redPlayer2Border.activeInHierarchy && !redPlayer3Border.activeInHierarchy&& !redPlayer4Border.activeInHierarchy)
                {
                    redPlayer1Btn.interactable = false;
                    redPlayer2Btn.interactable = false;
                    redPlayer3Btn.interactable = false;
                    redPlayer4Btn.interactable = false;

                    redPlayer1.GetComponent<RedPlayerOne>().enabled = false;
                    redPlayer2.GetComponent<RedPlayertwo>().enabled = false;
                    redPlayer3.GetComponent<RedPlayerThree>().enabled = false;
                    redPlayer4.GetComponent<RedPlayerFour>().enabled = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;
                    }
                }
                break;
            case "YELLOW":
                if(selectDiceNumAnimation==6 && yellowPlayer1Steps==0)
                {
                    yellowPlayer1Border.SetActive(true);
                    yellowPlayer1Btn.interactable = true;
                    yellowPlayer1.GetComponent<YellowPlayerOne>().enabled = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayer2Steps == 0)
                {
                    yellowPlayer2Border.SetActive(true);
                    yellowPlayer2Btn.interactable = true;
                    yellowPlayer2.GetComponent<YellowPlayerTwo>().enabled = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayer3Steps == 0)
                {
                    yellowPlayer3Border.SetActive(true);
                    yellowPlayer3Btn.interactable = true;
                    yellowPlayer3.GetComponent<YellowPlayerThree>().enabled = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayer4Steps == 0)
                {
                    yellowPlayer4Border.SetActive(true);
                    yellowPlayer4Btn.interactable = true;
                    yellowPlayer4.GetComponent<YellowPlayerFour>().enabled = true;
                }

                if((yellowMovementBlock.Count - yellowPlayer1Steps) >= selectDiceNumAnimation && yellowPlayer1Steps > 0 && (yellowMovementBlock.Count > yellowPlayer1Steps))
                {
                    yellowPlayer1Border.SetActive(true);
                    yellowPlayer1Btn.interactable = true;
                    yellowPlayer1.GetComponent<YellowPlayerOne>().enabled = true;
                }
                if ((yellowMovementBlock.Count - yellowPlayer2Steps) >= selectDiceNumAnimation && yellowPlayer2Steps > 0 && (yellowMovementBlock.Count > yellowPlayer2Steps))
                {
                    yellowPlayer2Border.SetActive(true);
                    yellowPlayer2Btn.interactable = true;
                    yellowPlayer2.GetComponent<YellowPlayerTwo>().enabled = true;
                }
                if ((yellowMovementBlock.Count - yellowPlayer3Steps) >= selectDiceNumAnimation && yellowPlayer3Steps > 0 && (yellowMovementBlock.Count > yellowPlayer3Steps))
                {
                    yellowPlayer3Border.SetActive(true);
                    yellowPlayer3Btn.interactable = true;
                    yellowPlayer3.GetComponent<YellowPlayerThree>().enabled = true;
                }
                if ((yellowMovementBlock.Count - yellowPlayer4Steps) >= selectDiceNumAnimation && yellowPlayer4Steps > 0 && (yellowMovementBlock.Count > yellowPlayer4Steps))
                {
                    yellowPlayer4Border.SetActive(true);
                    yellowPlayer4Btn.interactable = true;
                    yellowPlayer4.GetComponent<YellowPlayerFour>().enabled = true;
                }

                if (!yellowPlayer1Border.activeInHierarchy && !yellowPlayer2Border.activeInHierarchy&&!yellowPlayer3Border.activeInHierarchy && !yellowPlayer4Border.activeInHierarchy)
                {
                    yellowPlayer1Btn.interactable = false;
                    yellowPlayer2Btn.interactable = false;
                    yellowPlayer3Btn.interactable = false;
                    yellowPlayer4Btn.interactable = false;

                    yellowPlayer1.GetComponent<YellowPlayerOne>().enabled = false;
                    yellowPlayer2.GetComponent<YellowPlayerTwo>().enabled = false;
                    yellowPlayer3.GetComponent<YellowPlayerThree>().enabled = false;
                    yellowPlayer4.GetComponent<YellowPlayerFour>().enabled = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;
                    }
                }
                break;
            case "BLUE":

                if(selectDiceNumAnimation==6 && bluePlayer1Steps==0)
                {
                    bluePlayer1Border.SetActive(true);
                    bluePlayer1Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayer2Steps == 0)
                {
                    bluePlayer2Border.SetActive(true);
                    bluePlayer2Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayer3Steps == 0)
                {
                    bluePlayer3Border.SetActive(true);
                    bluePlayer3Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayer4Steps == 0)
                {
                    bluePlayer4Border.SetActive(true);
                    bluePlayer4Btn.interactable = true;
                }

                if ((blueMovementBlock.Count - bluePlayer1Steps) >= selectDiceNumAnimation && bluePlayer1Steps > 0 && (blueMovementBlock.Count > bluePlayer1Steps))
                {
                    bluePlayer1Border.SetActive(true);
                    bluePlayer1Btn.interactable = true;
                }
                if ((blueMovementBlock.Count - bluePlayer2Steps) >= selectDiceNumAnimation && bluePlayer2Steps > 0 && (blueMovementBlock.Count > bluePlayer2Steps))
                {
                    bluePlayer2Border.SetActive(true);
                    bluePlayer2Btn.interactable = true;
                }
                if ((blueMovementBlock.Count - bluePlayer3Steps) >= selectDiceNumAnimation && bluePlayer3Steps > 0 && (blueMovementBlock.Count > bluePlayer3Steps))
                {
                    bluePlayer3Border.SetActive(true);
                    bluePlayer3Btn.interactable = true;
                }
                if ((blueMovementBlock.Count - bluePlayer4Steps) >= selectDiceNumAnimation && bluePlayer4Steps > 0 && (blueMovementBlock.Count > bluePlayer4Steps))
                {
                    bluePlayer4Border.SetActive(true);
                    bluePlayer4Btn.interactable = true;
                }

                if (!bluePlayer1Border.activeInHierarchy && !bluePlayer2Border.activeInHierarchy && !bluePlayer3Border.activeInHierarchy && !bluePlayer4Border.activeInHierarchy)
                {
                    bluePlayer1Btn.interactable = false;
                    bluePlayer2Btn.interactable = false;
                    bluePlayer3Btn.interactable = false;
                    bluePlayer4Btn.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {

                        case 3:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;
                    }
                }
                break;
            case "GREEN":
                 if(selectDiceNumAnimation==6 && greenPlayer1Steps==0)
                {
                    greenPlayer1Border.SetActive(true);
                    greenPlayer1Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && greenPlayer2Steps == 0)
                {
                    greenPlayer2Border.SetActive(true);
                    greenPlayer2Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && greenPlayer3Steps == 0)
                {
                    greenPlayer3Border.SetActive(true);
                    greenPlayer3Btn.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && greenPlayer4Steps == 0)
                {
                    greenPlayer4Border.SetActive(true);
                    greenPlayer4Btn.interactable = true;
                }

                if ((greenMovementBlock.Count - greenPlayer1Steps) >= selectDiceNumAnimation && greenPlayer1Steps > 0 && (greenMovementBlock.Count > greenPlayer1Steps))
                {
                    greenPlayer1Border.SetActive(true);
                    greenPlayer1Btn.interactable = true;
                }
                if ((greenMovementBlock.Count - greenPlayer2Steps) >= selectDiceNumAnimation && greenPlayer2Steps > 0 && (greenMovementBlock.Count > greenPlayer2Steps))
                {
                    greenPlayer2Border.SetActive(true);
                    greenPlayer2Btn.interactable = true;
                }
                if ((greenMovementBlock.Count - greenPlayer3Steps) >= selectDiceNumAnimation && greenPlayer3Steps > 0 && (greenMovementBlock.Count > greenPlayer3Steps))
                {
                    greenPlayer3Border.SetActive(true);
                    greenPlayer3Btn.interactable = true;
                }
                if ((greenMovementBlock.Count - greenPlayer4Steps) >= selectDiceNumAnimation && greenPlayer4Steps > 0 && (greenMovementBlock.Count > greenPlayer4Steps))
                {
                    greenPlayer4Border.SetActive(true);
                    greenPlayer4Btn.interactable = true;
                }

                if (!greenPlayer1Border.activeInHierarchy && !greenPlayer2Border.activeInHierarchy && !greenPlayer3Border.activeInHierarchy && !greenPlayer4Border.activeInHierarchy)
                {
                    greenPlayer1Btn.interactable = false;
                    greenPlayer2Btn.interactable = false;
                    greenPlayer3Btn.interactable = false;
                    greenPlayer4Btn.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 4:
                            playerTurn = "RED";
                            InitializeDice();
                            break;
                    }
                }
                break;



        }
    }

    public void Checking()
    {
        if(totalRedInHouse==4)
        {
            redPlayer1.SetActive(false);
            redPlayer2.SetActive(false);
            redPlayer3.SetActive(false);
            redPlayer4.SetActive(false);

            yellowPlayer1.SetActive(false);
            yellowPlayer2.SetActive(false);
            yellowPlayer3.SetActive(false);
            yellowPlayer4.SetActive(false);

            bluePlayer1.SetActive(false);
            bluePlayer2.SetActive(false);
            bluePlayer4.SetActive(false);
            bluePlayer3.SetActive(false);

            greenPlayer1.SetActive(false);
            greenPlayer2.SetActive(false);
            greenPlayer3.SetActive(false);
            greenPlayer4.SetActive(false);


           // winningAS.PlayOneShot(winningAC);
            //redWinScreen.SetActive(true);
            GameCompletedCoroutine();
        }
        if (totalYellowInHouse == 4)
        {
            redPlayer1.SetActive(false);
            redPlayer2.SetActive(false);
            redPlayer3.SetActive(false);
            redPlayer4.SetActive(false);

            yellowPlayer1.SetActive(false);
            yellowPlayer2.SetActive(false);
            yellowPlayer3.SetActive(false);
            yellowPlayer4.SetActive(false);

            bluePlayer1.SetActive(false);
            bluePlayer2.SetActive(false);
            bluePlayer4.SetActive(false);
            bluePlayer3.SetActive(false);

            greenPlayer1.SetActive(false);
            greenPlayer2.SetActive(false);
            greenPlayer3.SetActive(false);
            greenPlayer4.SetActive(false);


           // winningAS.PlayOneShot(winningAC);
           // yellowWinScreen.SetActive(true);
            GameCompletedCoroutine();
        }
        if (totalBlueInHouse == 4)
        {
            redPlayer1.SetActive(false);
            redPlayer2.SetActive(false);
            redPlayer3.SetActive(false);
            redPlayer4.SetActive(false);

            yellowPlayer1.SetActive(false);
            yellowPlayer2.SetActive(false);
            yellowPlayer3.SetActive(false);
            yellowPlayer4.SetActive(false);

            bluePlayer1.SetActive(false);
            bluePlayer2.SetActive(false);
            bluePlayer4.SetActive(false);
            bluePlayer3.SetActive(false);

            greenPlayer1.SetActive(false);
            greenPlayer2.SetActive(false);
            greenPlayer3.SetActive(false);
            greenPlayer4.SetActive(false);


           // winningAS.PlayOneShot(winningAC);
           // blueWinScreen.SetActive(true);
            GameCompletedCoroutine();
        }
        if (totalGreenInHouse == 4)
        {
            redPlayer1.SetActive(false);
            redPlayer2.SetActive(false);
            redPlayer3.SetActive(false);
            redPlayer4.SetActive(false);

            yellowPlayer1.SetActive(false);
            yellowPlayer2.SetActive(false);
            yellowPlayer3.SetActive(false);
            yellowPlayer4.SetActive(false);

            bluePlayer1.SetActive(false);
            bluePlayer2.SetActive(false);
            bluePlayer4.SetActive(false);
            bluePlayer3.SetActive(false);

            greenPlayer1.SetActive(false);
            greenPlayer2.SetActive(false);
            greenPlayer3.SetActive(false);
            greenPlayer4.SetActive(false);


            //winningAS.PlayOneShot(winningAC);
           // greenWinScreen.SetActive(true);
            GameCompletedCoroutine();
        }
    }

    public void  ExitMethod()
    {
        SoundManager.buttonAusioSource.Play();
        confirmScreen.SetActive(true);
    }

    public void NoExitMethod()
    {
        SoundManager.buttonAusioSource.Play();
        confirmScreen.SetActive(false);
    }

    public void YesExitMethod()
    {
        SoundManager.buttonAusioSource.Play();
        SceneManager.LoadScene("Main");
    }

    public void GameCompletedCoroutine()
    {
        SoundManager.winningAusioSource.Play();
        gameCompletedScreen.SetActive(true);

    }

    public void YesCompletedGame()
    {
        SoundManager.buttonAusioSource.Play();
        SceneManager.LoadScene("Ludo");
    }

    public void NoCompletedGame()
    {
        SoundManager.buttonAusioSource.Play();
        SceneManager.LoadScene("Main ");


    }
         

}
