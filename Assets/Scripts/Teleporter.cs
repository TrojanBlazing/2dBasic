using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform Teleport;

public Transform GetTeleport()
    {
        return Teleport;
    }
   
}
