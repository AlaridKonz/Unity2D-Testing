using UnityEngine;

public static class ControllerKey {
    public static KeyCode Square         {get; private set;} = KeyCode.Joystick1Button0;
    public static KeyCode X              {get; private set;} = KeyCode.Joystick1Button1;
    public static KeyCode Circle         {get; private set;} = KeyCode.Joystick1Button2;
    public static KeyCode Triangle       {get; private set;} = KeyCode.Joystick1Button3;
    public static KeyCode L1             {get; private set;} = KeyCode.Joystick1Button4;
    public static KeyCode R1             {get; private set;} = KeyCode.Joystick1Button5;
    public static KeyCode L2             {get; private set;} = KeyCode.Joystick1Button6;
    public static KeyCode R2             {get; private set;} = KeyCode.Joystick1Button7;
    public static KeyCode Share          {get; private set;} = KeyCode.Joystick1Button8;
    public static KeyCode Options        {get; private set;} = KeyCode.Joystick1Button9;
    public static KeyCode L3             {get; private set;} = KeyCode.Joystick1Button10;
    public static KeyCode R3             {get; private set;} = KeyCode.Joystick1Button11;
    public static KeyCode PS             {get; private set;} = KeyCode.Joystick1Button12;
    public static KeyCode PadPress       {get; private set;} = KeyCode.Joystick1Button13;

    public static string LeftStickX     {get; private set;} = "X-Axis";
    public static string LeftStickY     {get; private set;} = "Y-Axis"; // inverted?
    public static string RightStickX    {get; private set;} = "3rd Axis";
    public static string RightStickY    {get; private set;} = "4th Axis"; // inverted?
    public static string L2Axis         {get; private set;} = "5th Axis"; // -1 to 1 range. -1 unpressed, 1 fully pressed
    public static string R2Axis         {get; private set;} = "6th Axis"; // -1 to 1 range. -1 unpressed, 1 fully pressed
    public static string DPadX          {get; private set;} = "7rd Axis";
    public static string DPadY          {get; private set;} = "8th Axis"; // inverted?
}
