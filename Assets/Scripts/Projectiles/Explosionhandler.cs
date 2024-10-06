using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Explosionhandler : MonoBehaviour
{
    [SerializeField] float m_DisableTime;
    [SerializeField] AudioClip m_ExplosionSound;
    public IObjectPool<GameObject> pool;
    SoundData soundData;
    // Start is called before the first frame update
    private void OnEnable()
    {
        soundData = new SoundData();
        soundData.clip = m_ExplosionSound;
        var soundBuilder = SoundManager.Instance.CreateSoundBuilder();
        soundBuilder.WithRandomPitch().WithPosition(transform.position).Play(soundData);
        Debug.Log("Initiated play command");
        StartCoroutine(waitToPool());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitToPool()
    {
        yield return new WaitForSeconds(m_DisableTime);
        Debug.Log("Sending back to pool");
        pool.Release(gameObject);
    }
}
