using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public IObjectPool<Bullet> pool;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.isVisible)
        {
            // Do nothing, just chill
        }
        else
        {
            // Go back to pool
            pool.Release(this);
        }
    }
}
