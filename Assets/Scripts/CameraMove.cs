using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float zDis;

    private void Awake()
    {
        if(target != null)
        {
            zDis = target.position.z - transform.position.z;
        }
    }
    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.z = target.position.z - zDis;
        transform.position = pos;
    }
}
