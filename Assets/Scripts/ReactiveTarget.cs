using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particles;
    public Coroutine deathAnim {  get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _particles.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Death anim
    public IEnumerator Die()
    {
        // rotate
        this.transform.Rotate(-75, 0, 0);

        _particles.enableEmission = true;

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }

    public void ReactToHit()
    {
        // get reference to wandering script
        WanderingAI behavior = gameObject.GetComponent<WanderingAI>();
        if (behavior != null )
        {
            behavior.setAlive(true);
        }

        if (deathAnim == null )
            deathAnim = StartCoroutine(Die());
    }
}
