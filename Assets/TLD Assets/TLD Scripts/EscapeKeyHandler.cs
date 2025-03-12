using UnityEngine;

public class EscapeKeyHandler : MonoBehaviour
{
    public GameObject popupCanvas; // Assign your Popup Canvas here in the Inspector
    private bool isMenuActive = false;

    void Start()
    {
        // Ensure the popup canvas is initially inactive
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
        // Lock the cursor at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (popupCanvas != null)
            {
                // Toggle the active state of the popup canvas
                isMenuActive = !isMenuActive;
                popupCanvas.SetActive(isMenuActive);

                // Update the cursor lock state based on the menu active state
                if (isMenuActive)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
    }
}
