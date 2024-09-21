using UnityEngine;

public class Behaviour_MainSwitch : Behaviour_Electronics, IBehaviour_Deactivatable, IBehaviour_Activatable, IBehaviour_StatusActivation, IBehaviour_Interactable
{
    //Add sound maybe?
    [SerializeField] private bool _isActivated = true;

    [SerializeField] private GameObject hintLight;
    [SerializeField] private GameObject[] electronics;

    //public void OnMouseOver()
    //{
    //    if (Vector3.Distance(GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= maxRange)
    //    {
    //        canvasCursor.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F)) 
    //        { 
    //            if (_isActivated) 
    //            { 
    //                Deactivate(); 
    //            } 
    //            else 
    //            { 
    //                Activate(); 
    //            } 
    //        }
    //    }
    //}
    private protected override void Start()
    {
        base.Start();
        MainSwitch = gameObject;
    }

    public void Activate()
    {
        hintLight.GetComponent<Light>().enabled = true;
        _isActivated = true;
    }

    public void Deactivate()
    {
        foreach (GameObject electronic in electronics) { electronic.GetComponent<IBehaviour_Deactivatable>().Deactivate(); }
        hintLight.GetComponent<Light>().enabled = false;
        _isActivated = false;
    }

    public bool GetStatusActivation() => _isActivated;
}
