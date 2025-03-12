using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public GameObject canvas1; // Assign the first Canvas GameObject in the Inspector
    public GameObject canvas2; // Assign the second Canvas GameObject in the Inspector
    private GameObject activeCanvas; // Tracks the currently active Canvas

    void Start()
    {
        // Ensure that only canvas1 is active at the start
        if (canvas1 != null) canvas1.SetActive(true);
        if (canvas2 != null) canvas2.SetActive(false);
        activeCanvas = canvas1;

        // Lock the cursor at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between the two canvases
            if (activeCanvas == canvas1)
            {
                canvas1.SetActive(false);
                canvas2.SetActive(true);
                activeCanvas = canvas2;

                // Unlock and show the cursor to allow interaction with the second canvas
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                activeCanvas = canvas1;

                // Lock and hide the cursor again
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
