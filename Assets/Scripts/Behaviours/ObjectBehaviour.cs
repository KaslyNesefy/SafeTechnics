using UnityEngine;

internal interface IObjectBehaviour
{
    bool isActivated { get; set; }
    bool isBurning { get; set; }

    void OnMouseOver();
    void OnMouseExit();
    void Activate();
    void Deactivate();
}

public class ObjectBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject canvasCursor;

    public GameObject mainSwitch;

    public GameObject fireExtinguisherPlace;

    public bool isBurning { get; set; } = false;

    public const float maxRange = PlayerBehavior.playerMaxRange;

    public void OnMouseExit() => canvasCursor.SetActive(false);
}
