using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [field: SerializeField] public FixedJoystick MoveJoystick { get; private  set; }
    [field: SerializeField] public FixedJoystick RotateJoystick { get; private set; }
}