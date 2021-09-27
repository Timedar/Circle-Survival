using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, ActionMap.IGameplayActions
{
    public static InputReader current;
    ActionMap actionMap;
    public event UnityAction<Vector2> onClickStart = delegate {};
    public event UnityAction<Vector2> onClick2Start = delegate {};

    [HideInInspector] public Vector2 position;
    [HideInInspector] public bool tap;
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
                
                onClickStart.Invoke(position);
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

    public void OnMobileClick(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
        onClickStart.Invoke(position);
    }

    public void OnMobileClick2(InputAction.CallbackContext context)
    {
        onClick2Start.Invoke(context.ReadValue<Vector2>());
    }
}


