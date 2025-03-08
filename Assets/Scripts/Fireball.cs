using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        ReactiveObject reactiveObject = other.GetComponent<ReactiveObject>();

        if (character != null)
        {
            Debug.Log("Player Hit!");
            character.Hurt(damage);
        }

        if (reactiveObject != null) 
        {
            Debug.Log("Object hit!");
            reactiveObject.ReactToHit(damage);
        }

        Destroy(gameObject);
    }
}
