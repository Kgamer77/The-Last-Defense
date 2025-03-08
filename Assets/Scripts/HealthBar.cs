using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Need these for knowing player heath value and moving the health bar
    PlayerCharacter character;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        character =  GetComponentInParent<Canvas>().GetComponentInParent<PlayerCharacter>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Just to make sure there is a player
        if (character != null)
        {
            // Change the scale of the health bar on the x so it shrinks when you take damage
            rectTransform.localScale = new Vector3(character.getHealth() / 5.0f, 1, 1);

            // Move the heath bar so it stays at the left edge of the panel behind it
            if (character.getHealth() >= 0)
            {
                rectTransform.position = new Vector3(200 * character.getHealth() / 5.0f, 50);
            }
        }
    }
}
