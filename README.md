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

# Learning time measurement results
Method         | Learning time(s)  | CPU Usage(%)  | remarks
---------------|-------------------|---------------|------------------------------
UnityEditor    | 68                | 25            | CPU
GPU            | 71                | 25            | set GPU at Behavior and \*1
Build          | 86                | 13            | \*2
Multi run      | 55                | 35            | --num-envs=4
Multi agents   | 21                | 25            | four agents, UnityEditor

\*1 Since each measurement is performed once, a few seconds is within the margin of error.
\*2 The build version is slower than UnityEditor because Python and the build app are competing for CPU.

# Leaning method
Scene name              | Agent | Trainer type  | Sample yaml 
------------------------|-------|---------------|---------------------------
SingleScene             |  1    | PPO           | RollerBall.yaml
SingleScene or others   |  x    | SAC           | SacEx.yaml
MultiScene              |  4    | PPO           | RollerBall.yaml 
DiscreteScene           |  1    | PPO           | DiscreteScene.yaml
VisualObservation       |  1    | PPO           | VisualObservation.yaml
RaycastObservation      |  1    | PPO           | RaycastObservation.yaml
