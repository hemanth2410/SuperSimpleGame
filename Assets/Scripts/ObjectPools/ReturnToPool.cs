using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    public Bullet bullet;
    public IObjectPool<Bullet> pool;

    void Start()
    {
        bullet = GetComponent<Bullet>();
    }

    void onBoundsExited()
    {
        // Return to the pool
        pool.Release(bullet);
    }
}
