﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class RollerAgent : Agent
{
    public Transform target;
    private Rigidbody rBody;

    public override void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // as starting episode
    public override void OnEpisodeBegin()
    {
        if (transform.localPosition.y < 0)
        {
            rBody.angularVelocity = Vector3.zero;
            rBody.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        }

        var randx = Random.value * 8 - 4;
        var randz = Random.value * 8 - 4;
        target.localPosition = new Vector3(randx, 0.5f, randz);
    }

    // call by observation
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.localPosition);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }

    // call by action
    public override void OnActionReceived(float[] vectorAction)
    {
        // add force to RollerAgent
        var controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rBody.AddForce(controlSignal * 10);

        // when RollerAgent arrive target
        var distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 1.42f)
        {
            AddReward(1.0f);
            EndEpisode();
        }

        // when RollerAgent fall out on floor
        if (transform.position.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        actionsOut[1] = Input.GetAxis("Vertical");
    }
}
