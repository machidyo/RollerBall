# RollerBall
<img src="https://user-images.githubusercontent.com/1772636/93848991-fcf75780-fce5-11ea-8852-2311a067f035.gif" width=640 />

This was made with reference to [RollerBall](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Learning-Environment-Create-New.md) for the following purposes.
1. For measuring the learning time of ML-Agents
2. For a sample (practice) of learning methods possible with ML-Agents

# Prerequisite
Enviroment | Version
-----------|-----------------
Windows    | 10
Python     | 3.7.9
TensorFlow | 2.3.0
Unity      | 2019.4.10f1
ML-Agents  | Release6

# Single or Multi and other options
## Scenes
Scene name              | Agent | Sample yaml 
------------------------|-------|---------------------------
SingleScene             |  1    | RollerBall.yaml
MultiScene              |  4    | RollerBall.yaml 

## Learning time measurement results
The time is measured until the Mean Reward reaches 1.000.
Since each measurement is performed once, a few seconds is within the margin of error.

UnityEditor/Build | CPU/GPU | Single/Multi | Time(s)  | CPU Usage(%)  | remarks
------------------|---------|--------------|----------|---------------|---------------------
UnityEditor       | CPU     | Single       | 68       | 25            | 
UnityEditor       | GPU     | Single       | 71       | 25            | set GPU at Behavior
Build             | CPU     | Single       | 86       | 13            | \*1
Multi run         | CPU     | Multi exe    | 55       | 35            | --num-envs=4
Multi agents      | CPU     | Multi agents | 21       | 25            | four agents

\*1 The build version is slower than UnityEditor because Python and the build app are competing for CPU.

# Trainer types, actions and observations
## Conditions
Conditions | Scene name         | Trainer type  | Action     | Observation | Sample yaml 
-----------|--------------------|---------------|------------|-------------|---------------------------
1          | SingleScene        | PPO           | Continuous | Vector      | RollerBall.yaml
2          | SingleScene        | SAC           | Continuous | Vector      | SacEx.yaml
3          | DiscreteScene      | PPO           | Discrete   | Vector      | DiscreteScene.yaml
4          | VisualObservation  | PPO           | Continuous | Visual      | VisualObservation.yaml
5          | RaycastObservation | PPO           | Discrete   | Raycast     | RaycastObservation.yaml

## Mesurement results
<img src="https://user-images.githubusercontent.com/1772636/94011110-d61e4b80-fde1-11ea-8f46-4d04127dca64.jpg" width=640 />

The time and number of steps are measured until the Mean Reward reaches 1.000.
Since each measurement is performed once, a few seconds is within the margin of error.
Algorithm   | Time(s) | Steps(k)     | Remarks
------------|---------|--------------|------------
PPO         |   68    | 13           |
SAC         |  191    | 121          |
PPO         |  159    | 31           |
SAC         | 1177    | 138          |
PPO         | 1318    | 236          | \*1

\*1 It took too long to learn, so I stopped halfway through.
