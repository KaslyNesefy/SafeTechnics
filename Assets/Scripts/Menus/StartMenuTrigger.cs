using UnityEngine;

public class StartMenuTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject tableTablet;
    public GameObject playerTablet;
    public GameObject doorText1;
    public GameObject doorText2;
    public GameObject playerCamera;
    public GameObject startMenu;
    public GameObject helpMenu;

    private int playerModeStartMenu = PlayerBehavior.playerModeStartMenu;
    private int playerModeHelpMenu = PlayerBehavior.playerModeHelpMenu;
    private int playerModeLevelsMenu = PlayerBehavior.playerModeLevelsMenu;
    private int timer = 0;

    //Start is called before the first frame update
    private void Start()
    {
        doorText2.SetActive(false);
        helpMenu.SetActive(false);
        startMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider) { if ((collider.tag == "Player") && (player.GetComponent<PlayerBehavior>().playerMode == playerModeStartMenu)) { startMenu.SetActive(true); } }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            switch (player.GetComponent<PlayerBehavior>().playerMode)
            {
                case 0://LevelsMenu
                    {
                        //To exit LevelMenu
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            tableTablet.SetActive(true);
                            playerTablet.SetActive(false);
                            startMenu.SetActive(true);
                            player.GetComponent<PlayerBehavior>().playerMode = playerModeStartMenu; //go to start menu
                        }
                        break;
                    }
                case 99998://HelpMenu
                    {
                        //To exit HelpMenu
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            helpMenu.SetActive(false);
                            playerCamera.SetActive(true);
                            player.GetComponent<PlayerBehavior>().playerMode = playerModeStartMenu; //go to start menu
                        }
                        break;
                    }
                case 99999://StartMenu
                    {
                        //To LevelMenu
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            tableTablet.SetActive(false);
                            playerTablet.SetActive(true);
                            startMenu.SetActive(false);
                            player.GetComponent<PlayerBehavior>().playerMode = playerModeLevelsMenu; //go to levels menu
                        }
                        //To HelpMenu
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            helpMenu.SetActive(true);
                            playerCamera.SetActive(false);
                            player.GetComponent<PlayerBehavior>().playerMode = playerModeHelpMenu; //switch to help menu
                        }
                        //To start Quiting
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            doorText1.SetActive(false);
                            doorText2.SetActive(true);
                            timer = 200;
                        }
                        //To CompleteQuiting
                        if (Input.GetKeyDown(KeyCode.R) && timer > 0)
                        {
                            Application.Quit();
                        }
                        if (timer <= 0)
                        {
                            doorText1.SetActive(true);
                            doorText2.SetActive(false);
                        }
                        if (timer > 0)
                        {
                            timer--;
                        }

                        break;
                    }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        startMenu.SetActive(false);
    }
}
