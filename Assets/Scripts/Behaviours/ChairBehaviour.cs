using UnityEngine;

public class ChairBehaviour : ObjectBehaviour, IObjectBehaviour
{
    public bool isActivated { get; set; } = false;
    private Vector3 position = new Vector3(-0.6857586f, 0.01225924f, -2.06534f);
    private Quaternion rotation = new Quaternion(0f, -180f, 0f, 0f);

    public void OnMouseOver()
    {
        if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
        {
            canvasCursor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) { if (isActivated) { Deactivate(); } else { Activate(); } }
        }
    }

    public void Deactivate()
    {
        GetComponent<Transform>().position = position;
        GetComponent<Transform>().rotation = rotation;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        isActivated = false;
    }

    public void Activate()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        isActivated = true;
    }
}
