using UnityEngine;

public class StartMenuTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject tableTablet;
    [SerializeField] private GameObject playerTablet;
    [SerializeField] private GameObject doorTextPrepareQuit;
    [SerializeField] private GameObject doorTextQuit;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject helpMenu;

    private StateMenu_Start _startMenuState;

    //private int playerModeStartMenu = Player.playerModeStartMenu;
    //private int playerModeHelpMenu = Player.playerModeHelpMenu;
    //private int playerModeLevelsMenu = Player.playerModeLevelsMenu;
    private int _exitDesicionTimer = 0;

    //Start is called before the first frame update
    private void Start()
    {
        startMenu.SetActive(false);
        _startMenuState = new StateMenu_Start(player.GetComponent<Player>(), doorTextQuit, helpMenu, startMenu);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.CompareTag("Player")) && (player.GetComponent<Player>().GetCurrentState() is State_Idle))
        {
            player.GetComponent<Player>().SetNewState(_startMenuState);
            startMenu.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!collider.CompareTag("Player"))
            return;

        switch (player.GetComponent<Player>().GetCurrentState())
        {
            //case StateMenu_Levels://LevelsMenu
            //    {
            //        //To exit LevelMenu
            //        if (Input.GetKeyDown(KeyCode.E))
            //        {
            //            tableTablet.SetActive(true);
            //            playerTablet.SetActive(false);
            //            startMenu.SetActive(true);
            //            player.GetComponent<Player>().SetNewState(_startMenuState); //go to start menu
            //        }
            //        break;
            //    }
            //case StateMenu_Help://HelpMenu
            //    {
            //        //To exit HelpMenu
            //        if (Input.GetKeyDown(KeyCode.E))
            //        {
            //            helpMenu.SetActive(false);
            //            playerCamera.SetActive(true);
            //            player.GetComponent<Player>().SetNewState(_startMenuState); //go to start menu
            //        }
            //        break;
            //    }
            case StateMenu_Start://StartMenu
                {
                    //To LevelMenu
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        player.GetComponent<Player>().SetNewState(new StateMenu_Levels(player.GetComponent<Player>(), tableTablet, playerTablet, startMenu)); //go to levels menu
                    }
                    //To HelpMenu
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        player.GetComponent<Player>().SetNewState(new StateMenu_Help(player.GetComponent<Player>(), helpMenu, playerCamera));
                    }
                    //player.GetComponent<Player>().SetNewState(new HelpMenuState(player.GetComponent<Player>())); //switch to help menu
                    //To start Quiting
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorTextPrepareQuit.SetActive(false);
                        doorTextQuit.SetActive(true);
                        _exitDesicionTimer = 200;
                    }
                    //To CompleteQuiting
                    if (Input.GetKeyDown(KeyCode.R) && _exitDesicionTimer > 0)
                        Application.Quit();
                    if (_exitDesicionTimer <= 0)
                    {
                        doorTextPrepareQuit.SetActive(true);
                        doorTextQuit.SetActive(false);
                    }
                    if (_exitDesicionTimer > 0)
                        _exitDesicionTimer--;

                    break;
                }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        startMenu.SetActive(false);
        if (player.GetComponent<Player>().GetCurrentState() is StateMenu_Start)
            player.GetComponent<Player>().SetNewState(new State_Idle(player.GetComponent<Player>()));
    }
}
