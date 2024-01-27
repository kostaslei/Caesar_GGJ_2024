using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class PlayerInputEvents : MonoBehaviour
{
    /*
    public UnityEvent OSampleEvents;
    public UnityEvent OSampleEventp;
    public UnityEvent OSampleEventc;
    */

    private PlayerInputActions _inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new PlayerInputActions();

        /*
        _inputActions.SampleMap.SampleAction.started += OnSampleActionStarted;
        _inputActions.SampleMap.SampleAction.performed += OnSampleActionPerformed;
        _inputActions.SampleMap.SampleAction.canceled += OnSampleActionCanceled;
        */
    }

    /*
    private void OnSampleActionStarted(InputAction.CallbackContext ctx)
    {
        OSampleEvents.Invoke();
    }
    private void OnSampleActionPerformed(InputAction.CallbackContext ctx)
    {
        OSampleEventp.Invoke();
    }
    private void OnSampleActionCanceled(InputAction.CallbackContext ctx)
    {
        OSampleEventc.Invoke();
    }
    */
}
