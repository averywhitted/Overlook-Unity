using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Remotes Config", menuName = "Overlook/Remote Config Object")]
public class RemoteConfigObject : ScriptableObject
{
    public List<Remote> remotes;

    [Serializable]
    public class Remote
    {
        public string remoteName;
        public List<Instrument> instruments;


        [Serializable]
        public class Instrument
        {
            [Header("After entering a name and selecting a type, only fill out ONE of the parameter fields.\n")]
            [Header("NAME")]
            public string instrumentName;

            [Header("TYPE")] public bool isWasd;
            public bool isSlider;
            public bool isButton;
            public bool isJoystick;
            public bool isThreeColumn;

            [Header("WASD PARAMETERS")] public string wOnChange_gameObject;
            public string wOnChange_method;
            public string aOnChange_gameObject;
            public string aOnChange_method;
            public string sOnChange_gameObject;
            public string sOnChange_method;
            public string dOnChange_gameObject;
            public string dOnChange_method;

            [Header("SLIDER PARAMETERS")] public int slider_min;
            public int slider_max;
            public float slider_step;
            public string slider_onChange_gameObject;
            public string slider_onChange_method;

            [Header("BUTTON PARAMETERS")] public string button_buttonText;
            public string button_onChange_gameObject;
            public string button_onChange_method;

            [Header("JOYSTICK PARAMETERS")] public int joystick_throttle;
            public string joystick_onChange_gameObject;
            public string joystick_onChange_method;

            [Header("THREE COLUMN PARAMETERS")] public string threeColumn_left_buttonText;
            public string threeColumn_center_buttonText;
            public string threeColumn_right_buttonText;
            public string threeColumn_left_onChange_gameObject;
            public string threeColumn_center_onChange_gameObject;
            public string threeColumn_right_onChange_gameObject;
            public string threeColumn_left_onChange_method;
            public string threeColumn_center_onChange_method;
            public string threeColumn_right_onChange_method;
        }
    }
    /*
    public Instrument wasd;
    public Instrument slider;
    public Instrument button;
    public Instrument joystick;
    public Instrument threeColumn;

    
    public Instrument()
    {
        if (isWasd)
        {
            instrumentName = "wasd";
            wasd = new Wasd(
                new OnChange(wOnChange_method, wOnChange_gameObject), 
                new OnChange(aOnChange_method, aOnChange_gameObject), 
                new OnChange(sOnChange_method, sOnChange_gameObject), 
                new OnChange(dOnChange_method, dOnChange_gameObject) 
                );
        }
        if (isSlider)
        {
            instrumentName = "slider";
            slider = new Slider(
                slider_min, 
                slider_max, 
                slider_step,  
                new OnChange(slider_onChange_method, slider_onChange_gameObject)
                );
        }
        if (isButton)
        {
            instrumentName = "button";
            button = new Button(
                button_buttonText,
                new OnChange(button_onChange_method, button_onChange_gameObject)
                );
        }
        if (isJoystick)
        {
            instrumentName = "joystick";
            joystick = new Joystick(
                joystick_throttle,
                new OnChange(button_onChange_method, button_onChange_gameObject)
                );
        }
        if (isThreeColumn)
        {
            instrumentName = "threeColumn";
            threeColumn = new ThreeColumn(
                threeColumn_left_buttonText,
                threeColumn_center_buttonText,
                threeColumn_right_buttonText,
                new OnChange(threeColumn_left_onChange_method, threeColumn_left_onChange_gameObject),
                new OnChange(threeColumn_center_onChange_method, threeColumn_center_onChange_gameObject),
                new OnChange(threeColumn_right_onChange_method, threeColumn_right_onChange_gameObject)
                );
        }
    }
    
}

[Serializable]
public class OnChange
{
    public string gameObject;
    public string method;

    public OnChange(string _gameObject, string _method)
    {
        gameObject = _gameObject;
        method = _method;
    }
}

[Serializable]
public class Wasd : Instrument
{
    public OnChange w_onChange;
    public OnChange a_onChange;
    public OnChange s_onChange;
    public OnChange d_onChange;

    public Wasd(OnChange _wONChange, OnChange _aONChange, OnChange _sONChange, OnChange _dONChange)
    {
        w_onChange = _wONChange;
        a_onChange = _aONChange;
        s_onChange = _sONChange;
        d_onChange = _dONChange;
    }
}

[Serializable]
public class Slider : Instrument
{
    public int min;
    public int max;
    public float step;
    public OnChange onChange;

    public Slider(int _min, int _max, float _step, OnChange _onChange)
    {
        min = _min;
        max = _max;
        step = _step;
        onChange = _onChange;
    }

}

[Serializable]
public class Button : Instrument
{
    public string buttonText;
    public OnChange onChange;

    public Button(string _buttonText, OnChange _onChange)
    {
        buttonText = _buttonText;
        onChange = _onChange;
    }
}

[Serializable]
public class Joystick : Instrument
{
    public int throttle;
    public OnChange onChange;

    public Joystick(int _throttle, OnChange _onChange)
    {
        throttle = _throttle;
        onChange = _onChange;
    }
}

[Serializable]
public class ThreeColumn : Instrument
{
    public string left_buttonText;
    public string center_buttonText;
    public string right_buttonText;
    public OnChange left_onChange;
    public OnChange center_onChange;
    public OnChange right_onChange;

    public ThreeColumn(string _leftButtonText, string _centerButtonText, string _rightButtonText, OnChange _leftONChange, OnChange _centerONChange, OnChange _rightONChange)
    {
        left_buttonText = _leftButtonText;
        center_buttonText = _centerButtonText;
        right_buttonText = _rightButtonText;
        left_onChange = _leftONChange;
        center_onChange = _centerONChange;
        right_onChange = _rightONChange;
    }
}
*/
}
