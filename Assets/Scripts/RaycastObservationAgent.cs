using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class RaycastObservationAgent : Agent
{
    public Transform target;
    public bool isDiscreting = true;
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

    // call by action
    public override void OnActionReceived(float[] vectorAction)
    {
        // add force to RollerAgent
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;
        var action = (int) vectorAction[0];
        if (action == 1) dirToGo = transform.forward;
        else if (action == 2) dirToGo = -transform.forward;
        else if (action == 3) rotateDir = -transform.up;
        else if (action == 4) rotateDir = transform.up;
        transform.Rotate(rotateDir, Time.deltaTime * 200f);
        rBody.AddForce(dirToGo * 0.4f, ForceMode.VelocityChange);

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
        if (isDiscreting)
        {
            actionsOut[0] = Input.GetAxis("Horizontal");
            actionsOut[1] = Input.GetAxis("Vertical");
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) actionsOut[0] = 1;
            else if (Input.GetKey(KeyCode.DownArrow)) actionsOut[0] = 2;
            else if (Input.GetKey(KeyCode.LeftArrow)) actionsOut[0] = 3;
            else if (Input.GetKey(KeyCode.RightArrow)) actionsOut[0] = 4;
        }
    }
}