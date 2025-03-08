using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // projectile
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;


    public float speed = 3f;
    public float obstacleRange = 5f;
    public const float _baseSpeed = 3f;

    private bool isAlive;

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    
    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = _baseSpeed * value;
    }

    // Start is called before the first frame update
    void Start()
    {
        // set to alive
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
        // create ray in dir of movement
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            // get reference to hit obj
            GameObject hitObj = hit.transform.gameObject;

            if (hitObj.GetComponent<PlayerCharacter>() || hitObj.GetComponent<ReactiveObject>()) 
            {
                if (fireball ==  null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }

            // if hit and less obstacle range turn around
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }

        }
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }
}
