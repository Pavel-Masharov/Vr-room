using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class ShotingController : MonoBehaviour
{
    //[SerializeField] private XRRayInteractor _leftHandInteractor;
    //[SerializeField] private ActionBasedController _leftbasedController;

    [SerializeField] private CanvasDebuger _canvasDebuger;

    public XRController _rightHand;
    public XRController _leftHand;

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
        CheckClickButton();
        //bool pressed;
        //_rightHand.inputDevice.IsPressed(_buttonTrigger, out pressed);
        //if (pressed)
        //{
        //    string message = "Hello - " + _buttonTrigger;
        //    _canvasDebuger.SetTextDebug(message);
        //}
        // xr.get


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
}
