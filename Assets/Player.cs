// GENERATED AUTOMATICALLY FROM 'Assets/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""da124219-28c0-488f-9ba3-baa95580c384"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""79c5a5d4-e455-4dc5-94d4-711bf37c8feb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""a4c05b4f-0592-43f7-93e3-679c785d42e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RTrig"",
                    ""type"": ""Button"",
                    ""id"": ""87b6b3ac-70ef-4a75-a96e-b7623dd3f032"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LStick"",
                    ""type"": ""Value"",
                    ""id"": ""bbce9d3f-18a9-4f83-bf64-31e58ebead3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""680efed2-66eb-46c2-9e3a-f95df470f2dd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de60164a-7a1c-4fb7-8d2c-367ab9f61e99"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""256c32f1-e6e8-499d-8c68-a994fbeca178"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""RTrig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KB"",
                    ""id"": ""9b9ac9e6-5318-45de-97e2-0bc781e6415f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd511f24-49bf-441c-89c3-7e21c476b9b9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c382be8-0625-4531-8cab-d05b48215070"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""033de343-c598-47ce-90c3-50925fc44017"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2406ef2a-06d1-4bb7-a0ab-f31c2f3e73b0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main"",
            ""bindingGroup"": ""Main"",
            ""devices"": []
        }
    ]
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_A = m_Main.FindAction("A", throwIfNotFound: true);
        m_Main_B = m_Main.FindAction("B", throwIfNotFound: true);
        m_Main_RTrig = m_Main.FindAction("RTrig", throwIfNotFound: true);
        m_Main_LStick = m_Main.FindAction("LStick", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_A;
    private readonly InputAction m_Main_B;
    private readonly InputAction m_Main_RTrig;
    private readonly InputAction m_Main_LStick;
    public struct MainActions
    {
        private @Player m_Wrapper;
        public MainActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Main_A;
        public InputAction @B => m_Wrapper.m_Main_B;
        public InputAction @RTrig => m_Wrapper.m_Main_RTrig;
        public InputAction @LStick => m_Wrapper.m_Main_LStick;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_MainActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_MainActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnB;
                @RTrig.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRTrig;
                @RTrig.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRTrig;
                @RTrig.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRTrig;
                @LStick.started -= m_Wrapper.m_MainActionsCallbackInterface.OnLStick;
                @LStick.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnLStick;
                @LStick.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnLStick;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @RTrig.started += instance.OnRTrig;
                @RTrig.performed += instance.OnRTrig;
                @RTrig.canceled += instance.OnRTrig;
                @LStick.started += instance.OnLStick;
                @LStick.performed += instance.OnLStick;
                @LStick.canceled += instance.OnLStick;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_MainSchemeIndex = -1;
    public InputControlScheme MainScheme
    {
        get
        {
            if (m_MainSchemeIndex == -1) m_MainSchemeIndex = asset.FindControlSchemeIndex("Main");
            return asset.controlSchemes[m_MainSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnRTrig(InputAction.CallbackContext context);
        void OnLStick(InputAction.CallbackContext context);
    }
}
