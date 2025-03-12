using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject escapeMenu;
    private bool isMenuActive = false;

    void Start()
    {
        // Ensure the menu is initially inactive
        escapeMenu.SetActive(false);
        // Lock the cursor at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the active state of the menu within the canvas
            isMenuActive = !isMenuActive;
            escapeMenu.SetActive(isMenuActive);

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
