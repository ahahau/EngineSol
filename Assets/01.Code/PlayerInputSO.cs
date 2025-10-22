using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _01.Code
{
    [CreateAssetMenu(fileName = "InputSystem", menuName = "Input/InputSystem", order = 0)]
    public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
    {
        public Vector2 movement;
        public Action<bool> OnBuildingModeKeyPressed;
        public Action OnAttackKeyPressed;
        private Controls _controls;
        private bool _isBuildingMode = false;
        private Vector2 _worldPosition; //이게 마우스의 월드 좌표
        private Vector2 _screenPosition;
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnAttackKeyPressed?.Invoke();
            }
        }
        public Vector2 GetWorldPosition()
        {
            Camera mainCam = Camera.main; 
            Debug.Assert(mainCam != null, "No main camera in this scene");
            
            Ray cameraRay = mainCam.ScreenPointToRay(_screenPosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hit, mainCam.farClipPlane))
            {
                _worldPosition = hit.point;
            }

            return _worldPosition;
        }
        public void OnBuildingMode(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _isBuildingMode = !_isBuildingMode;
                OnBuildingModeKeyPressed?.Invoke(_isBuildingMode);
            }
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            _screenPosition = context.ReadValue<Vector2>();
        }
    }
}