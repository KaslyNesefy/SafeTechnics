using UnityEngine;

public class NoCursorCam : MonoBehaviour
{
    public GameObject startEscapeCamera;
    public GameObject canvasCursor;
    
    // Start is called before the first frame update
    private void Start()
    {
        startEscapeCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        canvasCursor.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startEscapeCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (startEscapeCamera.activeSelf && Input.GetMouseButtonDown(0))
        {
            startEscapeCamera.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}