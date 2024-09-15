using UnityEngine;
using UnityEngine.UI;

internal interface ILevelLogic
{
    void FixedUpdate();
    void OnEnable();
    void OnDisable();
}

public class LevelLogic : MonoBehaviour
{
    public GameObject player;
    public GameObject panelPauseMenu;

    //UI
    public Text textWay1;
    public Text textWay2;
    public Text textWay3;
    public Text textWay4;
    public Text textWay5;

    public void TextWayCheck(bool condition1, bool condition2, bool condition3, bool condition4, bool condition5)
    {
        textWay1.enabled = condition1 ? false : true;
        textWay2.enabled = condition2 ? false : true;
        textWay3.enabled = condition3 ? false : true;
        textWay4.enabled = condition4 ? false : true;
        textWay5.enabled = condition5 ? false : true;
    }

    public void TextOut()
    {
        textWay1.text = "";
        textWay2.text = "";
        textWay3.text = "";
        textWay4.text = "";
        textWay5.text = "";
    }

    //PauseMenu
    public bool PauseMenuAct()
    {
        if (Input.GetKeyDown(KeyCode.E)) { panelPauseMenu.SetActive(true); }
        if (panelPauseMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                panelPauseMenu.SetActive(false);
                player.GetComponent<PlayerBehavior>().playerMode = PlayerBehavior.playerModeLevelInterrupted;
                return false;
            }
            if (Input.GetKeyDown(KeyCode.Q)) { panelPauseMenu.SetActive(false); }
            return true;
        }
        else { return true; }
    }

    public bool LevelEnd() { player.GetComponent<PlayerBehavior>().playerMode = PlayerBehavior.playerModeLevelWellDone; return false; }
}
