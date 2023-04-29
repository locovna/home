using UnityEngine;

namespace ProjectHome.GameCore.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _panSpeed = 20f;
        [SerializeField] private float _panBorderThickness = 10f;
        [SerializeField] private Vector2 _panLimit = new Vector2(90, 90);
        [SerializeField] private float _scrollSpeed = 10f;
        [SerializeField] private float _minY = 10f;
        [SerializeField] private float _maxY = 20f;

        // todo: refactor cheat functionality
        public bool disableMouseCameraController = false;

        void Update()
        {
            UpdateCameraPositionWithoutMouse();
        }

        void UpdateCameraPosition()
        {
            // store current camera position
            var pos = transform.position;

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _panBorderThickness)
            {
                pos.z += _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderThickness)
            {
                pos.z -= _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderThickness)
            {
                pos.x += _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a") || Input.mousePosition.x <= _panBorderThickness)
            {
                pos.x -= _panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _camera.orthographicSize -= scroll * _scrollSpeed * 100f * Time.deltaTime;

            // Mathf.Clamp(value to limit, limit range) 
            pos.x = Mathf.Clamp(pos.x, -_panLimit.x, _panLimit.x);
            pos.z = Mathf.Clamp(pos.z, -_panLimit.y, _panLimit.y);
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minY, _maxY);

            transform.position = pos;
        }

        void UpdateCameraPositionWithoutMouse()
        {
            // store current camera position
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.z += _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("s"))
            {
                pos.z -= _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                pos.x += _panSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                pos.x -= _panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _camera.orthographicSize -= scroll * _scrollSpeed * 100f * Time.deltaTime;

            // Mathf.Clamp(value to limit, limit range) 
            pos.x = Mathf.Clamp(pos.x, -_panLimit.x, _panLimit.x);
            pos.z = Mathf.Clamp(pos.z, -_panLimit.y, _panLimit.y);
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minY, _maxY);

            transform.position = pos;
        }
    }
}