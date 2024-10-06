using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public IObjectPool<Bullet> pool;
    bool freshlySpawnned;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        freshlySpawnned = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.isVisible)
        {
            freshlySpawnned = false;
        }
        else if(freshlySpawnned && !spriteRenderer.isVisible)
        {
            // Do nothing, just chill
            // Handling this so bullet dont get destroyed if spawned outside the screen
        }
        else if(!freshlySpawnned && !spriteRenderer.isVisible)
        {
            // Go back to pool
            pool.Release(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pool.Release(this);
        // releasing back to pool
        var k = ExplosionEffectsPool.Instance.Pool.Get();
        k.transform.position = transform.position;
        k.SetActive(true);
    }
}
