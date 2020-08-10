// GENERATED AUTOMATICALLY FROM 'Assets/InputAssets/Saving.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SaveInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SaveInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Saving"",
    ""maps"": [
        {
            ""name"": ""Saving"",
            ""id"": ""4120c5c6-9b9f-45a2-834e-31a9f7b892ee"",
            ""actions"": [
                {
                    ""name"": ""F2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""30f47257-41d4-4e01-bc7e-b39388cb6b7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F4"",
                    ""type"": ""PassThrough"",
                    ""id"": ""194d5765-206e-4664-8d6b-f45bd96f453d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F5"",
                    ""type"": ""Button"",
                    ""id"": ""8f08a23f-e29b-4e27-83e8-01e66e4d8498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""4d430b17-b72b-4f70-8292-33ba8b3c3e53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3e4c57c-f606-4e72-b1f6-a381bd2aee92"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""491c9c05-eeeb-4e70-b794-f8a93776e1ec"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""479e5cb8-8069-4979-84a6-8b06a739cd94"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09219c0e-29a9-443e-8c2f-11afbacef96f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Saving
        m_Saving = asset.FindActionMap("Saving", throwIfNotFound: true);
        m_Saving_F2 = m_Saving.FindAction("F2", throwIfNotFound: true);
        m_Saving_F4 = m_Saving.FindAction("F4", throwIfNotFound: true);
        m_Saving_F5 = m_Saving.FindAction("F5", throwIfNotFound: true);
        m_Saving_F = m_Saving.FindAction("F", throwIfNotFound: true);
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

    // Saving
    private readonly InputActionMap m_Saving;
    private ISavingActions m_SavingActionsCallbackInterface;
    private readonly InputAction m_Saving_F2;
    private readonly InputAction m_Saving_F4;
    private readonly InputAction m_Saving_F5;
    private readonly InputAction m_Saving_F;
    public struct SavingActions
    {
        private @SaveInputActions m_Wrapper;
        public SavingActions(@SaveInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @F2 => m_Wrapper.m_Saving_F2;
        public InputAction @F4 => m_Wrapper.m_Saving_F4;
        public InputAction @F5 => m_Wrapper.m_Saving_F5;
        public InputAction @F => m_Wrapper.m_Saving_F;
        public InputActionMap Get() { return m_Wrapper.m_Saving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SavingActions set) { return set.Get(); }
        public void SetCallbacks(ISavingActions instance)
        {
            if (m_Wrapper.m_SavingActionsCallbackInterface != null)
            {
                @F2.started -= m_Wrapper.m_SavingActionsCallbackInterface.OnF2;
                @F2.performed -= m_Wrapper.m_SavingActionsCallbackInterface.OnF2;
                @F2.canceled -= m_Wrapper.m_SavingActionsCallbackInterface.OnF2;
                @F4.started -= m_Wrapper.m_SavingActionsCallbackInterface.OnF4;
                @F4.performed -= m_Wrapper.m_SavingActionsCallbackInterface.OnF4;
                @F4.canceled -= m_Wrapper.m_SavingActionsCallbackInterface.OnF4;
                @F5.started -= m_Wrapper.m_SavingActionsCallbackInterface.OnF5;
                @F5.performed -= m_Wrapper.m_SavingActionsCallbackInterface.OnF5;
                @F5.canceled -= m_Wrapper.m_SavingActionsCallbackInterface.OnF5;
                @F.started -= m_Wrapper.m_SavingActionsCallbackInterface.OnF;
                @F.performed -= m_Wrapper.m_SavingActionsCallbackInterface.OnF;
                @F.canceled -= m_Wrapper.m_SavingActionsCallbackInterface.OnF;
            }
            m_Wrapper.m_SavingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @F2.started += instance.OnF2;
                @F2.performed += instance.OnF2;
                @F2.canceled += instance.OnF2;
                @F4.started += instance.OnF4;
                @F4.performed += instance.OnF4;
                @F4.canceled += instance.OnF4;
                @F5.started += instance.OnF5;
                @F5.performed += instance.OnF5;
                @F5.canceled += instance.OnF5;
                @F.started += instance.OnF;
                @F.performed += instance.OnF;
                @F.canceled += instance.OnF;
            }
        }
    }
    public SavingActions @Saving => new SavingActions(this);
    public interface ISavingActions
    {
        void OnF2(InputAction.CallbackContext context);
        void OnF4(InputAction.CallbackContext context);
        void OnF5(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
    }
}
