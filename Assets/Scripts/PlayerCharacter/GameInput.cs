// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerCharacter/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8cc29694-4bb4-446e-aa88-dba815cd19b0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2b0cc12b-3837-4fa9-9f42-8e6b8e8094d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DefaultAttack"",
                    ""type"": ""Button"",
                    ""id"": ""6aafc771-e8c5-44e1-8897-297fd1400ede"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrongAttack"",
                    ""type"": ""Button"",
                    ""id"": ""07b1e32f-dca3-418e-adf1-f9a17acce230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerEvent"",
                    ""type"": ""Button"",
                    ""id"": ""8bed69e4-49bc-472a-a89b-45639004ab68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blocking"",
                    ""type"": ""Value"",
                    ""id"": ""266c44a8-126d-4bd5-b5b0-1834494ff4a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Evade"",
                    ""type"": ""Button"",
                    ""id"": ""bfa08cbd-ac57-4004-8312-60f5b80541bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WhirlwindAttack"",
                    ""type"": ""Button"",
                    ""id"": ""07c55d12-6789-4ce6-bcd6-486c75d7075e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrossBowShot"",
                    ""type"": ""Button"",
                    ""id"": ""f364c00b-4857-4643-930a-40fed42516ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""a48f79f1-75b5-4178-bc62-0536d49c5a9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""34ca04d4-a604-4db7-b0cd-9d5876da25e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""53e7206b-42fd-4005-9037-f8f16b17b9a9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""36de13a7-0ec6-4509-a809-49b09ac8d611"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81072bcc-6deb-4d28-9dd2-8afc291c35f1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87e330ab-c350-4247-ac10-54b22a5e0626"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""119d74c7-755e-48e3-8d89-8e9077c540cb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""DefaultAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6974c620-2ca3-4274-9b4e-d80a9cd87240"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""StrongAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a426df16-7f67-4f2d-9f32-13204262397e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""TriggerEvent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31ada209-78a2-47d1-94e4-f4f2bbd4122c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Blocking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1d93369-73a2-4b32-b857-f92607fab782"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""Evade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2b8d0d7-a45a-4851-9a7b-7d83d0c05660"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""WhirlwindAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2304336-d695-4f25-bf41-381352cbd167"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInput"",
                    ""action"": ""CrossBowShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d794c55-d713-4f49-870e-211c337fcc00"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CrossBowShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""543c477a-c561-4150-a0a8-c40917d9a91b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GameInput"",
            ""bindingGroup"": ""GameInput"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_DefaultAttack = m_Player.FindAction("DefaultAttack", throwIfNotFound: true);
        m_Player_StrongAttack = m_Player.FindAction("StrongAttack", throwIfNotFound: true);
        m_Player_TriggerEvent = m_Player.FindAction("TriggerEvent", throwIfNotFound: true);
        m_Player_Blocking = m_Player.FindAction("Blocking", throwIfNotFound: true);
        m_Player_Evade = m_Player.FindAction("Evade", throwIfNotFound: true);
        m_Player_WhirlwindAttack = m_Player.FindAction("WhirlwindAttack", throwIfNotFound: true);
        m_Player_CrossBowShot = m_Player.FindAction("CrossBowShot", throwIfNotFound: true);
        m_Player_OpenMenu = m_Player.FindAction("OpenMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_DefaultAttack;
    private readonly InputAction m_Player_StrongAttack;
    private readonly InputAction m_Player_TriggerEvent;
    private readonly InputAction m_Player_Blocking;
    private readonly InputAction m_Player_Evade;
    private readonly InputAction m_Player_WhirlwindAttack;
    private readonly InputAction m_Player_CrossBowShot;
    private readonly InputAction m_Player_OpenMenu;
    public struct PlayerActions
    {
        private @GameInput m_Wrapper;
        public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @DefaultAttack => m_Wrapper.m_Player_DefaultAttack;
        public InputAction @StrongAttack => m_Wrapper.m_Player_StrongAttack;
        public InputAction @TriggerEvent => m_Wrapper.m_Player_TriggerEvent;
        public InputAction @Blocking => m_Wrapper.m_Player_Blocking;
        public InputAction @Evade => m_Wrapper.m_Player_Evade;
        public InputAction @WhirlwindAttack => m_Wrapper.m_Player_WhirlwindAttack;
        public InputAction @CrossBowShot => m_Wrapper.m_Player_CrossBowShot;
        public InputAction @OpenMenu => m_Wrapper.m_Player_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @DefaultAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefaultAttack;
                @DefaultAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefaultAttack;
                @DefaultAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefaultAttack;
                @StrongAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                @StrongAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                @StrongAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                @TriggerEvent.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerEvent;
                @TriggerEvent.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerEvent;
                @TriggerEvent.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerEvent;
                @Blocking.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlocking;
                @Blocking.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlocking;
                @Blocking.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlocking;
                @Evade.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEvade;
                @Evade.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEvade;
                @Evade.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEvade;
                @WhirlwindAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhirlwindAttack;
                @WhirlwindAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhirlwindAttack;
                @WhirlwindAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhirlwindAttack;
                @CrossBowShot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrossBowShot;
                @CrossBowShot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrossBowShot;
                @CrossBowShot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrossBowShot;
                @OpenMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @DefaultAttack.started += instance.OnDefaultAttack;
                @DefaultAttack.performed += instance.OnDefaultAttack;
                @DefaultAttack.canceled += instance.OnDefaultAttack;
                @StrongAttack.started += instance.OnStrongAttack;
                @StrongAttack.performed += instance.OnStrongAttack;
                @StrongAttack.canceled += instance.OnStrongAttack;
                @TriggerEvent.started += instance.OnTriggerEvent;
                @TriggerEvent.performed += instance.OnTriggerEvent;
                @TriggerEvent.canceled += instance.OnTriggerEvent;
                @Blocking.started += instance.OnBlocking;
                @Blocking.performed += instance.OnBlocking;
                @Blocking.canceled += instance.OnBlocking;
                @Evade.started += instance.OnEvade;
                @Evade.performed += instance.OnEvade;
                @Evade.canceled += instance.OnEvade;
                @WhirlwindAttack.started += instance.OnWhirlwindAttack;
                @WhirlwindAttack.performed += instance.OnWhirlwindAttack;
                @WhirlwindAttack.canceled += instance.OnWhirlwindAttack;
                @CrossBowShot.started += instance.OnCrossBowShot;
                @CrossBowShot.performed += instance.OnCrossBowShot;
                @CrossBowShot.canceled += instance.OnCrossBowShot;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_GameInputSchemeIndex = -1;
    public InputControlScheme GameInputScheme
    {
        get
        {
            if (m_GameInputSchemeIndex == -1) m_GameInputSchemeIndex = asset.FindControlSchemeIndex("GameInput");
            return asset.controlSchemes[m_GameInputSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDefaultAttack(InputAction.CallbackContext context);
        void OnStrongAttack(InputAction.CallbackContext context);
        void OnTriggerEvent(InputAction.CallbackContext context);
        void OnBlocking(InputAction.CallbackContext context);
        void OnEvade(InputAction.CallbackContext context);
        void OnWhirlwindAttack(InputAction.CallbackContext context);
        void OnCrossBowShot(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
