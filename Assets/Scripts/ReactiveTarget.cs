using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ReactiveTarget : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particles;

    public int health;
    public int maxHealth;
    public int scoreValue;

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

    public void ReactToHit(int damage)
    {
        // get reference to wandering script
        WanderingAI behavior = gameObject.GetComponent<WanderingAI>();
        if (behavior != null )
        {
            behavior.setAlive(true);
        }

        if (health <= 0 && deathAnim == null)
        {
            deathAnim = StartCoroutine(Die());
            Messenger.Broadcast(GameEvent.ENEMY_KILLED);
            Messenger<int>.Broadcast(GameEvent.ENEMY_HIT, scoreValue);
        }
        else
            health -= damage;
    }

    public void SetScore(int wave)
    {
        scoreValue = 50 * (maxHealth / (10 * (int) Mathf.Pow((float)wave, 1.01f)));
    }
    
}
