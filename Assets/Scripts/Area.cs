using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    private float desDis = 15;
    private AreaSpawner areaSpawner;
    private Transform playerTrans;

    public void Setup(AreaSpawner areaSpawner, Transform playerTransform)
    {
        this.areaSpawner = areaSpawner;
        this.playerTrans = playerTransform;
    }

    private void Update()
    {
        if(playerTrans.position.z - transform.position.z >= desDis)
        {
            areaSpawner.SpawnArea();
            Destroy(gameObject);
        }
    }
}
