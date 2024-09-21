using UnityEngine;

public class Behaviour_Kurisu : MonoBehaviour
{
    private int _kurisuappears = 0;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _kurisuappears++;
        if (_kurisuappears > 15)
            gameObject.SetActive(true);
    }
}
