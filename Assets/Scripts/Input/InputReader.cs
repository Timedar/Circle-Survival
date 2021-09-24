using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, ActionMap.IGameplayActions
{
    public static InputReader current;
    ActionMap actionMap;
    public Vector2 position;
    public bool tap;
    private void Awake() {
        current = this;
        actionMap = new ActionMap();
        actionMap.Gameplay.SetCallbacks(current);
    }

    private void OnEnable() {
        actionMap.Enable();
    }

    private void OnDisable() {
        actionMap.Disable();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                tap = true;
                Debug.Log("Click");
                break;
            case InputActionPhase.Performed:
                tap = false;
                break;
        }
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }
}


