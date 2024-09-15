using UnityEngine;

public class AlarmBehaviour : ObjectBehaviour, IObjectBehaviour
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

    public void Activate()
    {
        GetComponent<AudioSource>().Play();
        isActivated = true;
    }

    public void Deactivate()
    {
        GetComponent<AudioSource>().Stop();
        isActivated = false;
    }
}
