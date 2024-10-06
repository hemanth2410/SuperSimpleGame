using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Utilities;

public class ExplosionEffectsPool : PersistentSingleton<ExplosionEffectsPool>
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }
    [SerializeField] GameObject m_explosionPrefab;
    public PoolType poolType;
    public int maxPoolSize = 10;
    public bool collectionChecks = true;
    IObjectPool<GameObject> m_Pool;
    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                if (poolType == PoolType.Stack)
                    m_Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                else
                    m_Pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
            }
            return m_Pool;
        }
    }

    private void OnDestroyPoolObject(GameObject @object)
    {
        Destroy(@object);
    }

    private void OnReturnedToPool(GameObject @object)
    {
        @object.SetActive(false);
    }

    private void OnTakeFromPool(GameObject @object)
    {
        @object.SetActive(false);
    }

    private GameObject CreatePooledItem()
    {
        var go = Instantiate(m_explosionPrefab);
        go.GetComponent<Explosionhandler>().pool = Pool;
        go.transform.parent = this.transform;
        return go;
    }
}
