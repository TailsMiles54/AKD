using UnityEngine;

namespace Input
{
    public class JoystickController : MonoBehaviour
    {
        [field: SerializeField] public FixedJoystick MoveJoystick { get; private  set; }
        [field: SerializeField] public FixedJoystick RotateJoystick { get; private set; }
    }
}