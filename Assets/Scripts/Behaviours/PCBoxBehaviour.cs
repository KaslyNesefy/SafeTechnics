using UnityEngine;

public class PCBoxBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public bool isActivated { get; set; } = false;

    public AudioSource cooler;
    public AudioSource fireSound;

    public GameObject screen;

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IObjectBehaviour>().isActivated && !isBurning) { if (isActivated) { Deactivate(); screen.GetComponent<IObjectBehaviour>().Deactivate(); } else { Activate(); screen.GetComponent<IObjectBehaviour>().Activate(); } }
            if (Input.GetKeyDown(KeyCode.F) && fireExtinguisherPlace.GetComponent<IObjectBehaviour>().isActivated && isBurning) { isBurning = false; fireSound.Stop(); }
        }
    }

    public void Activate()
    {
        cooler.Play();
        isActivated = true;
    }

    public void Deactivate()
    {
        cooler.Stop();
        isActivated = false;
    }
}
