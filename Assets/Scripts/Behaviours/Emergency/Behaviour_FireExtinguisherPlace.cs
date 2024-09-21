using UnityEngine;

public class Behaviour_FireExtinguisherPlace : Behaviour_InteractableObject, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Pickable, IBehaviour_Placeable, IBehaviour_StatusPicked, IBehaviour_Interactable
{
    private bool _isActivated = false;
    private bool _isPicked = false;

    //public GameObject fireExtinguisherAtPlace;

    //public GameObject fireExtinguisherPlayer;

    //public void Start() => fireExtinguisherPlayer.SetActive(false);

    public void Activate()
    {
        //fireExtinguisherAtPlace.SetActive(false);
        //fireExtinguisherPlayer.SetActive(true);
        _isActivated = true;
    }

    public void Deactivate()
    {
        //fireExtinguisherAtPlace.SetActive(true);
        //fireExtinguisherPlayer.SetActive(false);
        _isActivated = false;
    }

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F)) { if (_isActivated) { Deactivate(); } else { Activate(); } }
    //    }
    //}

    public bool GetStatusActivation() => _isActivated;

    public void Pick()
    {
        throw new System.NotImplementedException();
    }

    public void Place()
    {
        throw new System.NotImplementedException();
    }

    public bool GetStatusPicked() => _isPicked;
}
