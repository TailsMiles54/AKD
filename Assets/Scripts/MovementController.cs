using UnityEngine;
using Zenject;

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
        Vector3 direction = new Vector3(_movementJoystick.Horizontal, 0f, _movementJoystick.Vertical);
        
        // Преобразуем направление в мировые координаты
        Vector3 movement = transform.TransformDirection(direction);
        
        // Устанавливаем скорость Rigidbody
        _rigidbody.velocity = movement.normalized * _speedModifier;
        
        RotateCharacter();
        
    }

    private void RotateCharacter()
    {
        // Получаем ввод для горизонтального и вертикального вращения
        float horizontalInput = _rotateJoystick.Horizontal; // Ввод для горизонтального вращения
        float verticalInput = _rotateJoystick.Vertical; // Ввод для вертикального вращения

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.Rotate(new Vector3(-verticalInput * _rotationSpeed, horizontalInput * _rotationSpeed, -transform.rotation.z));
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
}