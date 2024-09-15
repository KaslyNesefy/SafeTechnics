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

        window1.GetComponent<IObjectBehaviour>().Deactivate(); //Windows
        window2.GetComponent<IObjectBehaviour>().Deactivate();
        window3.GetComponent<IObjectBehaviour>().Deactivate();
        mainSwitch.GetComponent<IObjectBehaviour>().Activate(); //Printer
        alarm.GetComponent<IObjectBehaviour>().Deactivate(); //LightSwitch
        pc.GetComponent<IObjectBehaviour>().Deactivate(); //PC
        pc.GetComponent<IObjectBehaviour>().isBurning = false;
        fireSoundPc.Stop();
        screen.GetComponent<IObjectBehaviour>().Deactivate();
        fireExtinguisherPlace.GetComponent<IObjectBehaviour>().Deactivate();// shit to place
        door.GetComponent<IObjectBehaviour>().Deactivate();
    }

    public void OnEnable()
    {
        window1.GetComponent<IObjectBehaviour>().Activate(); //Windows
        window2.GetComponent<IObjectBehaviour>().Activate();
        window3.GetComponent<IObjectBehaviour>().Activate();
        mainSwitch.GetComponent<IObjectBehaviour>().Activate(); //Printer
        alarm.GetComponent<IObjectBehaviour>().Deactivate(); //LightSwitch
        pc.GetComponent<IObjectBehaviour>().Deactivate(); //PC
        pc.GetComponent<IObjectBehaviour>().isBurning = true;
        fireSoundPc.Play();
        screen.GetComponent<IObjectBehaviour>().Activate();
        fireExtinguisherPlace.GetComponent<IObjectBehaviour>().Deactivate();// shit to place
        door.GetComponent<IObjectBehaviour>().Deactivate();
    }

    public void FixedUpdate()
    {
        if (GetComponent<Level3Logic>().enabled) { GetComponent<Level3Logic>().enabled = PauseMenuAct(); };

        TextWayCheck(alarm.GetComponent<IObjectBehaviour>().isActivated,
                     !mainSwitch.GetComponent<IObjectBehaviour>().isActivated,
                     !window1.GetComponent<IObjectBehaviour>().isActivated && 
                     !window2.GetComponent<IObjectBehaviour>().isActivated && 
                     !window3.GetComponent<IObjectBehaviour>().isActivated,
                     !pc.GetComponent<IObjectBehaviour>().isBurning, 
                     door.GetComponent<IObjectBehaviour>().isActivated);

        if (!window1.GetComponent<IObjectBehaviour>().isActivated &&
            !window2.GetComponent<IObjectBehaviour>().isActivated &&
            !window3.GetComponent<IObjectBehaviour>().isActivated &&
            !mainSwitch.GetComponent<IObjectBehaviour>().isActivated &&
            !pc.GetComponent<IObjectBehaviour>().isBurning &&
            alarm.GetComponent<IObjectBehaviour>().isActivated &&
            door.GetComponent<IObjectBehaviour>().isActivated)//Completing condition
        {
            if (GetComponent<Level3Logic>().enabled) { GetComponent<Level3Logic>().enabled = LevelEnd(); };
        }
    }
}