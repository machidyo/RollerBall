# RollerBall
<img src="https://user-images.githubusercontent.com/1772636/93848991-fcf75780-fce5-11ea-8852-2311a067f035.gif" width=640 />

# 説明
これは[RollerBall](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Learning-Environment-Create-New.md)を参考につくっていて、ML-Agents の学習時間の計測用に作ったものです。

# 学習時間の計測結果
手法           | 学習時間（秒）  | CPU使用率  | 補足
---------------|-----------------|-----------|----------------------
UnityEditor    | 68             | 25        | CPU
GPU            | 71             | 25        | Behavior Parameter に GPU を設定、※1
ビルド         | 86             | 13        | ※2
複数同時起動    | 55             | 35        | --num-envs=4
Agent 複製     | 21             | 25        | 複製4つ、UnityEditor

※1 それぞれ1回の測定なので、数秒は誤差の範囲
※2 ビルド版が UnityEditor より遅くなっているのは、Python とビルドアプリがCPUを食い合っているためだと思われる

# Enviroment
* Windows10
* Python 3.7.9
* TensorFlow 2.3.0
* Unity 2019.4.10f1
* ML-Agent Release6
