using UnityEngine;

public class Level4Logic : MonoBehaviour
{
    public int phase = 1;

    public GameObject panelPauseMenu;
    public GameObject player;

    private void FixedUpdate()
    {
        switch (phase)
        {
            case 1://Start
                {

                    phase++;
                    break;
                }
            case 2://Process
                {

                    //PauseMenu activation
                    if (Input.GetKey(KeyCode.E))
                    {
                        panelPauseMenu.SetActive(true);
                    }
                    if (panelPauseMenu.activeSelf)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            panelPauseMenu.SetActive(false);
                            phase++;
                        }
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            panelPauseMenu.SetActive(false);
                        }
                    }

                    if (true)//Completing condition
                    {
                        phase++;
                    }
                    break;
                }
            case 3://End
                {
                    player.GetComponent<PlayerBehavior>().playerMode = PlayerBehavior.playerModeLevelWellDone;
                    GetComponent<Level1Logic>().enabled = false;
                    phase = 1;
                    break;
                }
        }
    }
}
