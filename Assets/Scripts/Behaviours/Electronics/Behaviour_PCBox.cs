using UnityEngine;

public class Behaviour_PCBox : Behaviour_Electronics, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    private bool _isActivated = false;

    public AudioSource cooler;
    public AudioSource fireSound;

    public GameObject screen;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IBehaviour_Deactivatable>().isActivated && !isBurning) { if (_isActivated) { Deactivate(); screen.GetComponent<IBehaviour_Deactivatable>().Deactivate(); } else { Activate(); screen.GetComponent<IBehaviour_Deactivatable>().Activate(); } }
    //        if (Input.GetKeyDown(KeyCode.F) && fireExtinguisherPlace.GetComponent<IBehaviour_Deactivatable>().isActivated && isBurning) { isBurning = false; fireSound.Stop(); }
    //    }
    //}

    public void Activate()
    {
        cooler.Play();
        _isActivated = true;
    }

    public void Deactivate()
    {
        cooler.Stop();
        _isActivated = false;
    }

    public bool GetStatusActivation() => _isActivated;
}
