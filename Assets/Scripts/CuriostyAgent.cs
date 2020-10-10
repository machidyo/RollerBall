using System;
using System.Linq;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class CuriostyAgent : Agent
{
    private Rigidbody rBody;
    private bool[] checkPointFlags = new bool[4];

    public override void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // as starting episode
    public override void OnEpisodeBegin()
    {
        // Debug.Log("START OnEpisodeBegin");

        for (var i = 0; i < checkPointFlags.Length; i++)
        {
            checkPointFlags[i] = false;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
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

        // Debug.Log("Ooops, -0.001 points.");
        AddReward(-0.001f);
    }

    public void EnterCheckPoint(int checkPoint)
    {
        // Debug.Log($"INFO (checkpoint, checkPointCount) = ({checkPoint}, -)");
        // Debug.Log(string.Join(", ", checkPointFlags));

        checkPointFlags[checkPoint] = true;

        // goal check
        if (checkPointFlags.Count(flag => flag) >= 4)
        {
            Debug.Log("Goal!! add 2 points!");
            AddReward(2.0f);
            EndEpisode();
            return;
        }

        // if agent back a check point, set false at next check point 
        var next = (checkPoint + 1) % checkPointFlags.Length;
        checkPointFlags[next] = false;
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow)) actionsOut[0] = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) actionsOut[0] = 2;
        else if (Input.GetKey(KeyCode.LeftArrow)) actionsOut[0] = 3;
        else if (Input.GetKey(KeyCode.RightArrow)) actionsOut[0] = 4;
    }
}