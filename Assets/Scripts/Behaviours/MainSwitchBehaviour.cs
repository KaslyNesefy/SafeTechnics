using UnityEngine;

public class MainSwitchBehaviour : ObjectBehaviour, IObjectBehaviour
{
    //Add sound maybe?
    public bool isActivated { get; set; } = true;

    public GameObject hintLight;
    public GameObject[] electronics;

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) { if (isActivated) { Deactivate(); } else { Activate(); } }
        }
    }

    public void Activate()
    {
        hintLight.GetComponent<Light>().enabled = true;
        isActivated = true;
    }

    public void Deactivate()
    {
        foreach (GameObject electronic in electronics) { electronic.GetComponent<IObjectBehaviour>().Deactivate(); }
        hintLight.GetComponent<Light>().enabled = false;
        isActivated = false;
    }
}
