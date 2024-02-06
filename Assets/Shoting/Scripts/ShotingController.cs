using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class ShotingController : MonoBehaviour
{

    [SerializeField] private CanvasDebuger _canvasDebuger;

    [SerializeField] public XRController _rightHand;
    [SerializeField] public XRController _leftHand;

    //[SerializeField] XRRayInteractor

    public InputHelpers.Button _buttonTrigger;
    public InputHelpers.Button _buttonGrip;
    public InputHelpers.Button _grip;
    public InputHelpers.Button _trigger;
    public InputHelpers.Button _primaryButton;
    public InputHelpers.Button _primaryTouch;
    public InputHelpers.Button _secondaryButton;
    public InputHelpers.Button _secondaryTouch;

    private List<InputHelpers.Button> _listTypesButtons = new()
    {
        InputHelpers.Button.Grip,
        InputHelpers.Button.GripButton,
        InputHelpers.Button.Trigger,
        InputHelpers.Button.TriggerButton,

        InputHelpers.Button.PrimaryTouch,
        InputHelpers.Button.PrimaryButton,
        InputHelpers.Button.SecondaryTouch,
        InputHelpers.Button.SecondaryButton,
    };


    void Update()
    {
        //CheckClickButton();     
        CheckClickTriggerButton();
    }


    private void CheckClickButton()
    {
        foreach (var button in _listTypesButtons)
        {
            bool pressed;
            _rightHand.inputDevice.IsPressed(button, out pressed);

            if (pressed)
            {
                string message = "Right - " + button.ToString();
                _canvasDebuger.SetTextDebug(message);
            }
        }

        foreach (var button in _listTypesButtons)
        {
            bool pressed;
            _leftHand.inputDevice.IsPressed(button, out pressed);

            if (pressed)
            {
                string message = "Left - " + button.ToString();
                _canvasDebuger.SetTextDebug(message);
            }
        }
    }

    private void CheckClickTriggerButton()
    {
        bool pressedRight;
        _rightHand.inputDevice.IsPressed(_buttonTrigger, out pressedRight);
        if (pressedRight)
        {
            _canvasDebuger.SetTextDebug("Shot");
            _rightHand.model.GetComponent<Gun>().Shot(() => {
                _canvasDebuger.SetTextDebug("Hit");
                _rightHand.SendHapticImpulse(1, 0.25f);
            });
        }

        bool pressedLeft;
        _leftHand.inputDevice.IsPressed(_buttonTrigger, out pressedLeft);
        if (pressedLeft)
        {           
            _canvasDebuger.SetTextDebug("Shot");
            _leftHand.model.GetComponent<Gun>().Shot(() => { 
                _canvasDebuger.SetTextDebug("Hit");
                _leftHand.SendHapticImpulse(1, 0.25f);
            });
        }

    }

   
}
