using UnityEngine;

public class InputManager : MonoBehaviour {
    public enum InputType { PC, Controller }
    public InputType inputType { get; private set; }

    private bool controllerUsed;

    void Awake() {
        InputBindings.initializeBindings();
    }

    void Update() {
        if (!Input.anyKeyDown) return;
        controllerUsed = InputBindings.checkForAnyControllerInput();
        SetInputType(controllerUsed ? InputType.Controller : InputType.PC);
    }

    private void SetInputType(InputType _inputType) {
        if (inputType == _inputType) return;
        inputType = _inputType;
        // Debug log
        // Update UI
    }

    public bool PressedAttack() {
        return getKeyDown(InputBindings.getBindings(Action.Attack));
    }

    public bool PressedJump() {
        return getKeyDown(InputBindings.getBindings(Action.Jump));
    }

    public bool PressedBlock() {
        return getKeyDown(InputBindings.getBindings(Action.Block));
    }

    public bool Pressed(Action action) {
        return getKeyDown(InputBindings.getBindings(action));
    }

    public float GetMovement() {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetVertical() {
        return Input.GetAxisRaw("Vertical");
    }

    public bool getKeyDown(Bindings bind) {
        return Input.GetKeyDown(controllerUsed ? bind.controller : bind.keyboard);
    }

    public bool getKey(Bindings bind) {
        return Input.GetKey(controllerUsed ? bind.controller : bind.keyboard);
    }

    public bool getKeyUp(Bindings bind) {
        return Input.GetKeyUp(controllerUsed ? bind.controller : bind.keyboard);
    }

}
