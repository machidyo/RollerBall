using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public CuriostyAgent agent;
    public int CheckPointId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player is hit on me(" + CheckPointId + ").");
            agent.EnterCheckPoint(CheckPointId);
        }
    }
}
