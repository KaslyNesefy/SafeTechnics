using UnityEngine;

public class PCScreenBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public bool isActivated { get; set; } = false;

    public GameObject pc;

    public GameObject screenOff;

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IObjectBehaviour>().isActivated) { if (isActivated) { Deactivate(); pc.GetComponent<IObjectBehaviour>().Deactivate(); } else { Activate(); pc.GetComponent<IObjectBehaviour>().Activate(); } }
        }
    }

    public void Activate()
    {
        screenOff.SetActive(false);
        //print("Deactivated...");
        isActivated = true;
        //print("Screen switched on...");
    }

    public void Deactivate()
    {
        screenOff.SetActive(true);
        isActivated = false;
    }
}
