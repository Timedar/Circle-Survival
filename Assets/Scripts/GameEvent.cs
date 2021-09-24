using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEvent", order = 1)]
public class GameEvent : ScriptableObject
{
    public event Action reciveEvent;
    public void CallEvnet()
    {
        if(reciveEvent != null)
            reciveEvent();
    }


}
