using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveObject : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particles;
    public Coroutine deathAnim { get; private set; }

    private int health;
    private int MAX_HEALTH = 100;


    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Death anim
    public IEnumerator Die()
    {
        // rotate
        _particles.enableEmission = true;

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }

    public void ReactToHit(int damage)
    {
        // get reference to wandering script
        health -= damage;

        if (health <= 0 && deathAnim == null)
            deathAnim = StartCoroutine(Die());
    }
}
