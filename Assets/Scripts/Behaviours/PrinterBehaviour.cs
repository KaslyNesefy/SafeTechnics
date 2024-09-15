using UnityEngine;

public class PrinterBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public GameObject hintLight;

    public bool isActivated { get; set; } = false;

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
        hintLight.SetActive(true);
        isActivated = true;
    }

    public void Deactivate()
    {
        hintLight.SetActive(false);
        isActivated = false;
    }
}
