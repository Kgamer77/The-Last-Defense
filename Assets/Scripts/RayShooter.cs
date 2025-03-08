using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        // hide the cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;



    }

    private void OnGUI()
    {
        // add crosshair
        int size = 24;

        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            // Calculate center of screen
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            // Create a ray starting at middle of screen
            Ray ray = cam.ScreenPointToRay(point);

            // Create raycast obj to figure out what was hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                // For now print out coords of hit
                Debug.Log($"Hit: {hit.point}");

                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
                if (target != null) 
                {
                    if (target.deathAnim == null)
                        Messenger.Broadcast(GameEvent.ENEMY_HIT);
                    Debug.Log("Target Hit!");
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicatior(hit.point));
                }
                

                
            }
        }
    }

    // Coroutine
    // 
    private IEnumerator SphereIndicatior(Vector3 pos)
    {
        // Create sphere and set position to pos
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        // Last for one second then destroy
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }


}
