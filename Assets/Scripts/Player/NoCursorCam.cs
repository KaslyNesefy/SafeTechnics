using UnityEngine;

public class NoCursorCam : MonoBehaviour
{
    public GameObject startEscapeCamera;
    
    private void Start()
    {
        startEscapeCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startEscapeCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        if (startEscapeCamera.activeSelf && Input.GetMouseButtonDown(0))
        {
            startEscapeCamera.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }
}