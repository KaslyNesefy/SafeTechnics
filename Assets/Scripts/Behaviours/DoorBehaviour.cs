using UnityEngine;
using System.Collections;

public class DoorBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public bool isActivated { get; set; } = false;

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) { if (isActivated) { Deactivate(); } else { Activate(); } }
        }
    }

    public void Activate() => isActivated = true;

    public void Deactivate() => isActivated = false;
}
