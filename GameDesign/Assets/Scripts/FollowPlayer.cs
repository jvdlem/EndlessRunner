using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = Vector3.zero;
    void Update()
    {
        this.transform.position = player.position + offset;
    }
}
