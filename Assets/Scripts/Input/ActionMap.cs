// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/ActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionMap"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c5a12bce-3856-46b9-b1a3-c1d46ceb31d6"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""d1f16f6c-835d-474e-93ac-c217be21d3ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""b6bee053-7937-4ff6-9d9e-8a50a40e383b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MobileClick"",
                    ""type"": ""Button"",
                    ""id"": ""cbede09a-c569-459d-9902-2ec7e43b7a0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MobileClick2"",
                    ""type"": ""Button"",
                    ""id"": ""602208b4-d40d-462a-9bbe-ed5ce436bd3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da84ab85-37e0-4a48-8f83-6d4b186a5f7e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3673eb58-6865-4b6f-bf5a-7c465fe047df"",
                    ""path"": ""<Touchscreen>/primaryTouch/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""MobileClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe88d5ff-e054-486c-bc25-ed06cf6daa43"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93dc1cf2-41ce-436c-822c-6ba8b42a334d"",
                    ""path"": ""<Touchscreen>/touch1/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""MobileClick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": []
        },
        {
            ""name"": ""Computer"",
            ""bindingGroup"": ""Computer"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Click = m_Gameplay.FindAction("Click", throwIfNotFound: true);
        m_Gameplay_Position = m_Gameplay.FindAction("Position", throwIfNotFound: true);
        m_Gameplay_MobileClick = m_Gameplay.FindAction("MobileClick", throwIfNotFound: true);
        m_Gameplay_MobileClick2 = m_Gameplay.FindAction("MobileClick2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Click;
    private readonly InputAction m_Gameplay_Position;
    private readonly InputAction m_Gameplay_MobileClick;
    private readonly InputAction m_Gameplay_MobileClick2;
    public struct GameplayActions
    {
        private @ActionMap m_Wrapper;
        public GameplayActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Gameplay_Click;
        public InputAction @Position => m_Wrapper.m_Gameplay_Position;
        public InputAction @MobileClick => m_Wrapper.m_Gameplay_MobileClick;
        public InputAction @MobileClick2 => m_Wrapper.m_Gameplay_MobileClick2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Position.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @MobileClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick;
                @MobileClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick;
                @MobileClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick;
                @MobileClick2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick2;
                @MobileClick2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick2;
                @MobileClick2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMobileClick2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @MobileClick.started += instance.OnMobileClick;
                @MobileClick.performed += instance.OnMobileClick;
                @MobileClick.canceled += instance.OnMobileClick;
                @MobileClick2.started += instance.OnMobileClick2;
                @MobileClick2.performed += instance.OnMobileClick2;
                @MobileClick2.canceled += instance.OnMobileClick2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    private int m_ComputerSchemeIndex = -1;
    public InputControlScheme ComputerScheme
    {
        get
        {
            if (m_ComputerSchemeIndex == -1) m_ComputerSchemeIndex = asset.FindControlSchemeIndex("Computer");
            return asset.controlSchemes[m_ComputerSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnMobileClick(InputAction.CallbackContext context);
        void OnMobileClick2(InputAction.CallbackContext context);
    }
}
