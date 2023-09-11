using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    [SerializeField] private GameObject ParticlePrefap;
    [SerializeField] private float size;
    
    public void ParticleSpawn()
    {
        GameObject particle = Instantiate(ParticlePrefap, transform.position+new Vector3(0,1,0), transform.rotation);
        particle.transform.localScale = Vector3.one * size;
    }
}
