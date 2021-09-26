using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventTransform", menuName = "ScriptableObjects/GameEventTransform", order = 1)]
public class GameEventTransform : ScriptableObject
{
    public event Action<Transform> reciveEvent;
    public void CallEvnet(Transform trans)
    {
        if(reciveEvent != null)
            reciveEvent.Invoke(trans);
    }
}
