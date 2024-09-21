using UnityEngine;

public class Behaviour_PCScreen : Behaviour_Electronics, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    private bool _isActivated = false;

    public GameObject pc;

    public GameObject screenOff;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IBehaviour_Deactivatable>().isActivated) { if (_isActivated) { Deactivate(); pc.GetComponent<IBehaviour_Deactivatable>().Deactivate(); } else { Activate(); pc.GetComponent<IBehaviour_Deactivatable>().Activate(); } }
    //    }
    //}

    public void Activate()
    {
        screenOff.SetActive(false);
        //print("Deactivated...");
        _isActivated = true;
        //print("Screen switched on...");
    }

    public void Deactivate()
    {
        screenOff.SetActive(true);
        _isActivated = false;
    }

    public bool GetStatusActivation() => _isActivated;
}
