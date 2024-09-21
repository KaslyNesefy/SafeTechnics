using UnityEngine;

public class Level2Logic : LevelLogic, ILevelLogic
{
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject printer;
    public GameObject chair;
    public GameObject lightSwitch;
    public GameObject pc;
    public GameObject screen;

    public void OnDisable()
    {
        TextOut();

        window1.GetComponent<IBehaviour_Activatable>().Activate(); //Windows
        window2.GetComponent<IBehaviour_Activatable>().Activate();
        window3.GetComponent<IBehaviour_Activatable>().Activate();
        printer.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //Printer
        chair.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //Chair
        lightSwitch.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //LightSwitch
        pc.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //PC
        screen.GetComponent<IBehaviour_Deactivatable>().Deactivate();
    }
    public void OnEnable()
    {
        window1.GetComponent<IBehaviour_Activatable>().Activate(); //Windows
        window2.GetComponent<IBehaviour_Activatable>().Activate();
        window3.GetComponent<IBehaviour_Activatable>().Activate();
        printer.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //Printer
        chair.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //Chair
        lightSwitch.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //LightSwitch
        pc.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //PC
        screen.GetComponent<IBehaviour_Deactivatable>().Deactivate();
    }

    public void FixedUpdate()
    {
        if (GetComponent<Level2Logic>().enabled) { GetComponent<Level2Logic>().enabled = PauseMenuAct(); };

        TextWayCheck(printer.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     pc.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     chair.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),    
                     !window1.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() && !window2.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() && !window3.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     lightSwitch.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation());

        if (!window1.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !window2.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !window3.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            printer.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            chair.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            lightSwitch.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            pc.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation())//Completing condition
        {
            //if (GetComponent<Level2Logic>().enabled) { GetComponent<Level2Logic>().enabled = LevelEnd(); };
        }
    }
}