using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "InputReader")]
public class PlayerInputSO : ScriptableObject, GameInput.IPlayerActions
{
    public event UnityAction OpenMenu;
    public event UnityAction DefaultAttack;
    public event UnityAction StrongAttack;
    public event UnityAction Blocking;
    public event UnityAction Evade;
    public event UnityAction TriggerEvent;
    public event UnityAction Shot;
    public event UnityAction WhirlWind;
    public event UnityAction<Vector2> PlayerMovement;

    public bool isBlocking;

    private GameInput _gameInput;
   
    private void OnEnable()
    {
        if(_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Player.SetCallbacks(this);
        }

        _gameInput.Player.Enable();
    }
    
    private void OnDisable()
    {
        _gameInput.Player.Disable();
    }

  
    public void OnMovement(InputAction.CallbackContext context)
    {
        PlayerMovement?.Invoke(context.ReadValue<Vector2>());        
    }

    public void OnDefaultAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DefaultAttack?.Invoke(); 
        }
    }

    public void OnStrongAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StrongAttack?.Invoke();
        }
    }

    public void OnTriggerEvent(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            TriggerEvent?.Invoke();
        }
    }

    public void OnBlocking(InputAction.CallbackContext context)
    {
        
            if (context.performed)
            {
                isBlocking = true;
                Blocking?.Invoke();
            }

            if (context.canceled)
            {
                isBlocking = false;
            }
             
    }

    public void OnEvade(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Evade?.Invoke();
        }
           
    }

    public void OnWhirlwindAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            WhirlWind?.Invoke();
        }
    }

    public void OnCrossBowShot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shot?.Invoke();
        }

    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OpenMenu?.Invoke();
        }
    }
}
