using UnityEngine;

public class Behaviour_LightSwitch : Behaviour_Electronics, IBehaviour_Activatable, IBehaviour_Deactivatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    //Add sound maybe?
    private bool _isActivated = false;
    [SerializeField] private GameObject[] lamps;
    [SerializeField] private GameObject hintLight;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F) && mainSwitch.GetComponent<IBehaviour_Object>().isActivated)
    //            if (isActivated)
    //            {
    //                Deactivate();
    //            }
    //            else
    //            {
    //                Activate();
    //            }
    //    }
    //}

    public bool GetStatusActivation() => _isActivated;

    public void Activate()
    {
        foreach (GameObject lamp in lamps)
        {
            lamp.GetComponent<Light>().enabled = true;
        }
        hintLight.GetComponent<Light>().enabled = true;
        _isActivated = true;
    }

    public void Deactivate()
    {
        foreach (GameObject lamp in lamps)
        {
            lamp.GetComponent<Light>().enabled = false;
        }
        hintLight.GetComponent<Light>().enabled = false;
        _isActivated = false;
    }
}
