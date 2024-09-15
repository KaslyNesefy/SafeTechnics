using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    public GameObject playerTablet;
    

    public const float playerMaxRange = 1.8f;

    public static int playerModeStartMenu = 99999;
    public static int playerModeHelpMenu = 99998;
    public static int playerModeLevelWellDone = 99997;
    public static int playerModeLevelOutOfTime = 99996;
    public static int playerModeLevelInterrupted = 99995;
    public static int playerModeLevelsMenu = 0;
    public int playerMode = playerModeStartMenu;
    /*Reserved Modes
    99999-StartMenu
    99998-Help
    99997-LevelDone
    99996-LevelOutOfTime
    99995-LevelInterrupt
    0-LevelMenu
    1-1st Level
    2-2nd Level
    3-3rd Level
    4-4th Level
    5-5th Level*/

    public int kurisuappears = 0;
    public GameObject kurisu;

    // Start is called before the first frame update
    private void Start()
    {
        playerTablet.SetActive(false);
        kurisu.SetActive(false);
        GetComponent<Level1Logic>().enabled = false;
        GetComponent<Level2Logic>().enabled = false;
        GetComponent<Level3Logic>().enabled = false;
        GetComponent<Level4Logic>().enabled = false;
        GetComponent<Level5Logic>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (playerMode == playerModeLevelsMenu)
        {
            playerMode = Input.GetKeyDown(KeyCode.Alpha1) ? 1 : playerMode;
            playerMode = Input.GetKeyDown(KeyCode.Alpha2) ? 2 : playerMode;
            playerMode = Input.GetKeyDown(KeyCode.Alpha3) ? 3 : playerMode;
            playerMode = Input.GetKeyDown(KeyCode.Alpha4) ? 4 : playerMode;
            playerMode = Input.GetKeyDown(KeyCode.Alpha5) ? 5 : playerMode;
        }
        if (Input.GetKeyDown(KeyCode.F)) { kurisuappears++; }
        if (kurisuappears > 7) { kurisu.SetActive(true); }
    }
}
