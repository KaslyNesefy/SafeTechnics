using UnityEngine;

public class Level3Logic : LevelLogic, ILevelLogic
{
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject mainSwitch;
    public GameObject alarm;
    public GameObject pc;
    public GameObject screen;
    public GameObject fireExtinguisherPlace;
    public GameObject door;
    public AudioSource fireSoundPc;

    public void OnDisable()
    {
        TextOut();

        window1.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //Windows
        window2.GetComponent<IBehaviour_Deactivatable>().Deactivate();
        window3.GetComponent<IBehaviour_Deactivatable>().Deactivate();
        mainSwitch.GetComponent<IBehaviour_Activatable>().Activate(); //Printer
        alarm.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //LightSwitch
        pc.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //PC
        pc.GetComponent<IBehaviour_Extinguishable>().Extinguish();
        fireSoundPc.Stop();
        screen.GetComponent<IBehaviour_Deactivatable>().Deactivate();
        fireExtinguisherPlace.GetComponent<IBehaviour_Deactivatable>().Deactivate();// shit to place
        door.GetComponent<IBehaviour_Deactivatable>().Deactivate();
    }

    public void OnEnable()
    {
        window1.GetComponent<IBehaviour_Activatable>().Activate(); //Windows
        window2.GetComponent<IBehaviour_Activatable>().Activate();
        window3.GetComponent<IBehaviour_Activatable>().Activate();
        mainSwitch.GetComponent<IBehaviour_Activatable>().Activate(); //Printer
        alarm.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //LightSwitch
        pc.GetComponent<IBehaviour_Deactivatable>().Deactivate(); //PC
        pc.GetComponent<IBehaviour_Burnable>().Burn();
        fireSoundPc.Play();
        screen.GetComponent<IBehaviour_Activatable>().Activate();
        fireExtinguisherPlace.GetComponent<IBehaviour_Deactivatable>().Deactivate();// shit to place
        door.GetComponent<IBehaviour_Deactivatable>().Deactivate();
    }

    public void FixedUpdate()
    {
        if (GetComponent<Level3Logic>().enabled) { GetComponent<Level3Logic>().enabled = PauseMenuAct(); };

        TextWayCheck(alarm.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     !mainSwitch.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     !window1.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
                     !window2.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
                     !window3.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation(),
                     !pc.GetComponent<IBehaviour_StatusBurning>().GetStatusBurning(),
                     door.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation());

        if (!window1.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !window2.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !window3.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !mainSwitch.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation() &&
            !pc.GetComponent<IBehaviour_StatusBurning>().GetStatusBurning() &&
            alarm.GetComponent<IBehaviour_StatusBurning>().GetStatusBurning() &&
            door.GetComponent<IBehaviour_StatusActivation>().GetStatusActivation())//Completing condition
        {
            //if (GetComponent<Level3Logic>().enabled) { GetComponent<Level3Logic>().enabled = LevelEnd(); };
        }
    }
}