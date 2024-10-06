using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Utilities;

public class BulletObjectPool : PersistentSingleton<BulletObjectPool>
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }
    [SerializeField] GameObject m_BulletPrefab;
    public PoolType poolType;
    public int maxPoolSize = 10;
    public bool collectionChecks = true;
    IObjectPool<Bullet> m_Pool;
    public IObjectPool<Bullet> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                if (poolType == PoolType.Stack)
                    m_Pool = new ObjectPool<Bullet>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                else
                    m_Pool = new LinkedPool<Bullet>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
            }
            return m_Pool;
        }
    }

    private void OnDestroyPoolObject(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void OnReturnedToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private Bullet CreatePooledItem()
    {
        var go = Instantiate(m_BulletPrefab);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.pool = Pool;
        go.transform.parent = this.transform;
        return bullet;
    }
}
