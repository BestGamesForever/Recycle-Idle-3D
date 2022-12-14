//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_GAME-NAME-FOLDER/_Scripts/_PlayerRelated/PlayerAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""436a08a5-61d0-453b-9559-24fe54a113de"",
            ""actions"": [
                {
                    ""name"": ""Delta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d3187500-4aaf-4eae-9fc1-7df241456753"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e05c30cc-29a3-4cf3-bcc7-98a9c47505f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""0c1b14c1-967c-4cdc-b726-8ba90595ffb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchRelease"",
                    ""type"": ""Button"",
                    ""id"": ""8019e9f7-842f-42a9-85ad-1d491fe1eb7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f9b48826-cb07-4b12-81ab-c6d7ac3313b4"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6260903b-77dc-4cfa-8dff-e013d5fd0db0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df9b8d0c-4270-4285-abde-44f8648502c4"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c5a94a-29f7-476b-aadd-a4f6fd09e7c5"",
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
                    ""id"": ""51198326-b756-4ef5-8450-5b7c8270620a"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93bf6c0d-987c-44a2-8177-37f759c2ed2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0745e1f-5a84-43ab-b15e-269128117f8a"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7afd1228-e108-4a67-b907-df251f841eba"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Delta = m_Movement.FindAction("Delta", throwIfNotFound: true);
        m_Movement_Position = m_Movement.FindAction("Position", throwIfNotFound: true);
        m_Movement_TouchPress = m_Movement.FindAction("TouchPress", throwIfNotFound: true);
        m_Movement_TouchRelease = m_Movement.FindAction("TouchRelease", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Delta;
    private readonly InputAction m_Movement_Position;
    private readonly InputAction m_Movement_TouchPress;
    private readonly InputAction m_Movement_TouchRelease;
    public struct MovementActions
    {
        private @PlayerAction m_Wrapper;
        public MovementActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Delta => m_Wrapper.m_Movement_Delta;
        public InputAction @Position => m_Wrapper.m_Movement_Position;
        public InputAction @TouchPress => m_Wrapper.m_Movement_TouchPress;
        public InputAction @TouchRelease => m_Wrapper.m_Movement_TouchRelease;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Delta.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Position.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPosition;
                @TouchPress.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchPress;
                @TouchRelease.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchRelease;
                @TouchRelease.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchRelease;
                @TouchRelease.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTouchRelease;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchRelease.started += instance.OnTouchRelease;
                @TouchRelease.performed += instance.OnTouchRelease;
                @TouchRelease.canceled += instance.OnTouchRelease;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnDelta(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchRelease(InputAction.CallbackContext context);
    }
}
