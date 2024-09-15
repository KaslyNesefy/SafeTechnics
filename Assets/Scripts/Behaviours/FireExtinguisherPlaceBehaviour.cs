using UnityEngine;

public class FireExtinguisherPlaceBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public bool isActivated { get; set; } = false;

    public GameObject fireExtinguisherAtPlace;

    public GameObject fireExtinguisherPlayer;

    public void Start() => fireExtinguisherPlayer.SetActive(false);

    public void Activate()
    {
        fireExtinguisherAtPlace.SetActive(false);
        fireExtinguisherPlayer.SetActive(true);
        isActivated = true;
    }

    public void Deactivate()
    {
        fireExtinguisherAtPlace.SetActive(true);
        fireExtinguisherPlayer.SetActive(false);
        isActivated = false;
    }

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) { if (isActivated) { Deactivate(); } else { Activate(); } }
        }
    }
}
