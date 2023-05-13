using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 offSet;

    void Start()
    {
        offSet = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
