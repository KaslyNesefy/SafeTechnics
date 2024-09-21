using UnityEngine;

public class Behaviour_Printer : Behaviour_Electronics, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    public GameObject hintLight;

    private bool _isActivated { get; set; } = false;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IBehaviour_Deactivatable>().isActivated) { if (_isActivated) { Deactivate(); } else { Activate(); } }
    //    }
    //}

    public void Activate()
    {
        hintLight.SetActive(true);
        _isActivated = true;
    }

    public void Deactivate()
    {
        hintLight.SetActive(false);
        _isActivated = false;
    }

    public bool GetStatusActivation() => _isActivated;
}
