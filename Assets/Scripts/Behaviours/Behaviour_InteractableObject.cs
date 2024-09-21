using UnityEngine;

public class Behaviour_InteractableObject : MonoBehaviour, IBehaviour_Interactable
{
    [SerializeField] private GameObject player;
    private protected virtual void Start() => player = FindObjectOfType<Player>().gameObject;
    public void OnMouseEnter() => player.GetComponent<IPlayer>().ShowInteractiveCursor();
    public void OnMouseExit() => player.GetComponent<IPlayer>().HideInteractiveCursor();
}
