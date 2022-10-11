using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField][Range(1f, 5f)] private float _angularSpeed = 1f;
    [SerializeField] private Transform _target;
    private float _angleY;


    // Start is called before the first frame update
    void Start()
    {
        _angleY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) _angleY -= _angularSpeed;
        if (Input.GetKey(KeyCode.D)) _angleY += _angularSpeed;

        transform.position = _target.position;
        transform.rotation = Quaternion.Euler(0f, _angleY, 0f);

    }
}
