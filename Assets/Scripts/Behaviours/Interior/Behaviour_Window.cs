using UnityEngine;

public class Behaviour_Window : Behaviour_InteractableObject, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    private bool _isActivated = false;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F)) { if (_isActivated) { Deactivate(); } else { Activate(); } }
    //    }
    //}

    public void Activate()
    {
        GetComponent<AudioSource>().Play();
        _isActivated = true;
    }

    public void Deactivate()
    {
        GetComponent<AudioSource>().Stop();
        _isActivated = false;
    }

    public bool GetStatusActivation() => _isActivated;
}
