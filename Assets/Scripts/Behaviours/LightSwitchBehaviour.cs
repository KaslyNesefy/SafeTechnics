using UnityEngine;

public class LightSwitchBehaviour : ObjectBehaviour, IObjectBehaviour
{
    //Add sound maybe?
    public bool isActivated { get; set; } = false;
    public GameObject[] lamps;
    public GameObject hintLight;

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IObjectBehaviour>().isActivated) { if (isActivated) { Deactivate(); } else { Activate(); } }
        }
    }

    public void Activate()
    {
        foreach (GameObject lamp in lamps) { lamp.GetComponent<Light>().enabled = true; }
        hintLight.GetComponent<Light>().enabled = true;
        isActivated = true;
    }

    public void Deactivate()
    {
        foreach (GameObject lamp in lamps) { lamp.GetComponent<Light>().enabled = false; }
        hintLight.GetComponent<Light>().enabled = false;
        isActivated = false;
    }
}
