using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[CreateAssetMenu]

public class NewBehaviourScript : MonoBehaviour
{
    public UnityEvent OGCs;
    public UnityEvent OGCp;
    public UnityEvent OGCc;

    /*
    public UnityEvent OSampleEvents;
    public UnityEvent OSampleEventp;
    public UnityEvent OSampleEventc;
    */

    private PlayerInputActions _inputActions;


    // Start is called before the first frame update
    void Awake()
    {
        _inputActions.Player.GrabCard.started += OnGrabCardStarted;
        _inputActions.Player.GrabCard.performed += OnGrabCardPerformed;
        _inputActions.Player.GrabCard.canceled += OnGrabCardCanceled;

        /*
        _inputActions.SampleMap.SampleAction.started += OnSampleActionStarted;
        _inputActions.SampleMap.SampleAction.performed += OnSampleActionPerformed;
        _inputActions.SampleMap.SampleAction.canceled += OnSampleActionCanceled;
        */
    }

    private void OnGrabCardStarted(InputAction.CallbackContext ctx)
    {
        OGCs.Invoke();
    }
    private void OnGrabCardPerformed(InputAction.CallbackContext ctx)
    {
        OGCp.Invoke();
    }
    private void OnGrabCardCanceled(InputAction.CallbackContext ctx)
    {
        OGCc.Invoke();
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
