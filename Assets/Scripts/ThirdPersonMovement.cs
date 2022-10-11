using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private MovementCaracteristics _characteristics;

    private float _vertical;

    private readonly string STR_VERTICAL = "Vertical";

    private const float DISTANCE_OFFSET_CAMERA = 5f;

    private CharacterController _controller;

    private Vector3 _direction;
    private Quaternion _look;

    private Vector3 TargetRotate => _camera.forward * DISTANCE_OFFSET_CAMERA;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.visible = _characteristics.VisibleCursor;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Rotate();
    }

    private void Movement()
    {
        if (_controller.isGrounded)
        {
            _vertical = Input.GetAxis(STR_VERTICAL);

            _direction = transform.TransformDirection(_vertical, 0f, 0f).normalized;
        }

        _direction.y -= _characteristics.Gravity * Time.deltaTime;
        Vector3 dir = _direction * _characteristics.MovementSpeed * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            dir = Vector3.zero;
        }

        _controller.Move(dir);
    }

    private void Rotate()
    {
        Vector3 target = TargetRotate;
        target.y = 0;

        _look = Quaternion.LookRotation(target);

        float speed = _characteristics.AngularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed);

    }
}
