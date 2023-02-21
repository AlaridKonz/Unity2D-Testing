using System.Collections.Generic;
using UnityEngine;

public static partial class InputBindings {
    private static Dictionary<Action, Bindings> bindings = new Dictionary<Action, Bindings>();

    public static void initializeBindings() {
        bindings.Add(Action.Attack, new Bindings(KeyCode.Mouse1, ControllerKey.X));
        bindings.Add(Action.Block, new Bindings(KeyCode.Mouse2, ControllerKey.Square));
        bindings.Add(Action.Jump, new Bindings(KeyCode.Space, ControllerKey.Circle));
        bindings.Add(Action.Interact, new Bindings(KeyCode.E, ControllerKey.Triangle));

    }

    public static bool checkForAnyControllerInput() {
        foreach (Bindings bind in bindings.Values) {
            if (Input.GetKeyDown(bind.controller)) return true;
        }
        return false;
    }

    public static Bindings getBindings(Action action) {
        return bindings.GetValueOrDefault(action, null);
    }
}

public class Bindings {
    public KeyCode keyboard { get; private set; }
    public KeyCode controller { get; private set; }
    public Bindings(KeyCode _keyboard, KeyCode _controller) {
        keyboard = _keyboard;
        controller = _controller;
    }
}