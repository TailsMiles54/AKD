using Input;
using UnityEngine;
using Utils;
using Zenject;

namespace Character
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speedModifier;
        [SerializeField] private float _rotationSpeed;

        private FixedJoystick _movementJoystick;
        private FixedJoystick _rotateJoystick;
    
        [Inject]
        public void Construct(JoystickController joystickController)
        {
            _movementJoystick = joystickController.MoveJoystick.ThrowIfArgumentNull();
            _rotateJoystick = joystickController.RotateJoystick.ThrowIfArgumentNull();
        }
    
        private void Update()
        {
            MoveCharacter();
            RotateCharacter();
        }

        private void MoveCharacter()
        {
            Vector3 direction = new Vector3(_movementJoystick.Horizontal, 0f, _movementJoystick.Vertical);
        
            Vector3 movement = transform.TransformDirection(direction);
        
            _rigidbody.velocity = movement.normalized * _speedModifier;
        }

        private void RotateCharacter()
        {
            float horizontalInput = _rotateJoystick.Horizontal;
            float verticalInput = _rotateJoystick.Vertical;

            if (horizontalInput != 0 || verticalInput != 0)
            {
                transform.Rotate(new Vector3(-verticalInput * _rotationSpeed, horizontalInput * _rotationSpeed, -transform.rotation.z));
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
    }
}