using UnityEngine;

public class Level1Logic : LevelLogic, ILevelLogic
{
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject printer;
    public GameObject chair;
    public GameObject lightSwitch;
    public GameObject pc;
    public GameObject screen;

    public void OnEnable()
    {
        window1.GetComponent<IObjectBehaviour>().Activate(); //Windows
        window2.GetComponent<IObjectBehaviour>().Activate();
        window3.GetComponent<IObjectBehaviour>().Activate();
        printer.GetComponent<IObjectBehaviour>().Activate(); //Printer
        chair.GetComponent<IObjectBehaviour>().Activate(); //Chair
        lightSwitch.GetComponent<IObjectBehaviour>().Activate(); //LightSwitch
        pc.GetComponent<IObjectBehaviour>().Activate(); //PC
        screen.GetComponent<IObjectBehaviour>().Activate();
    }

    public void OnDisable()
    {
        TextOut();

        window1.GetComponent<IObjectBehaviour>().Deactivate(); //Windows
        window2.GetComponent<IObjectBehaviour>().Deactivate();
        window3.GetComponent<IObjectBehaviour>().Deactivate();
        printer.GetComponent<IObjectBehaviour>().Deactivate(); //Printer
        chair.GetComponent<IObjectBehaviour>().Deactivate(); //Chair
        lightSwitch.GetComponent<IObjectBehaviour>().Deactivate(); //LightSwitch
        pc.GetComponent<IObjectBehaviour>().Deactivate(); //PC
        screen.GetComponent<IObjectBehaviour>().Deactivate();
    }

    public void FixedUpdate()
    {
        if (GetComponent<Level1Logic>().enabled) { GetComponent<Level1Logic>().enabled = PauseMenuAct(); };

        TextWayCheck(!printer.GetComponent<IObjectBehaviour>().isActivated,
                     !pc.GetComponent<IObjectBehaviour>().isActivated,
                     !chair.GetComponent<IObjectBehaviour>().isActivated,
                     !window1.GetComponent<IObjectBehaviour>().isActivated && !window2.GetComponent<IObjectBehaviour>().isActivated && !window3.GetComponent<IObjectBehaviour>().isActivated,
                     !lightSwitch.GetComponent<IObjectBehaviour>().isActivated);

        if (!window1.GetComponent<IObjectBehaviour>().isActivated &&
            !window2.GetComponent<IObjectBehaviour>().isActivated &&
            !window3.GetComponent<IObjectBehaviour>().isActivated &&
            !printer.GetComponent<IObjectBehaviour>().isActivated &&
            !chair.GetComponent<IObjectBehaviour>().isActivated &&
            !lightSwitch.GetComponent<IObjectBehaviour>().isActivated &&
            !pc.GetComponent<IObjectBehaviour>().isActivated) //Completing condition
        {
            if (GetComponent<Level1Logic>().enabled) { GetComponent<Level1Logic>().enabled = LevelEnd(); };
        }
    }
}