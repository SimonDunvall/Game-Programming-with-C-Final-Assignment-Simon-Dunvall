using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    public class CarController : MonoBehaviour
    {
        public float maxAngle;
        public float maxTorque;

        private WheelCollider[] wheelsColliders;

        public Transform frontLeftWheelTransform,
            frontRightWheelTransform,
            rearLeftWheelTransform,
            rearRightWheelTransform;

        private float angle, torque;

        public InputActionAsset primaryActions;
        private InputActionMap gameplayActionMap;
        private InputAction steeringAngleInputAction;
        private InputAction accelerationInputAction;

        private void Start()
        {
            wheelsColliders = GetComponentsInChildren<WheelCollider>();
        }

        private void Awake()
        {
            gameplayActionMap = primaryActions.FindActionMap("Gameplay");

            steeringAngleInputAction = gameplayActionMap.FindAction("Steering Angle");
            accelerationInputAction = gameplayActionMap.FindAction("Acceleration");

            steeringAngleInputAction.performed += GetAngleInput;
            steeringAngleInputAction.canceled += GetAngleInput;

            accelerationInputAction.performed += GetTorqueInput;
            accelerationInputAction.canceled += GetTorqueInput;
        }

        private void FixedUpdate()
        {
            foreach (WheelCollider wheel in wheelsColliders)
            {
                switch (wheel.transform.localPosition.z)
                {
                    case > 0:
                        wheel.steerAngle = angle;
                        break;
                    case < 0:
                        wheel.motorTorque = torque;
                        break;
                }
            }


            UpdateSingleWheel(wheelsColliders[0], frontLeftWheelTransform);
            UpdateSingleWheel(wheelsColliders[1], frontRightWheelTransform);
            UpdateSingleWheel(wheelsColliders[2], rearRightWheelTransform);
            UpdateSingleWheel(wheelsColliders[3], rearLeftWheelTransform);
        }

        private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            wheelCollider.GetWorldPose(out var pos, out var rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }

        private void OnEnable()
        {
            steeringAngleInputAction.Enable();
            accelerationInputAction.Enable();
        }

        private void OnDisable()
        {
            steeringAngleInputAction.Disable();
            accelerationInputAction.Disable();
        }

        private void GetTorqueInput(InputAction.CallbackContext context)
        {
            torque = context.ReadValue<float>() * maxTorque;
        }

        private void GetAngleInput(InputAction.CallbackContext context)
        {
            angle = context.ReadValue<float>() * maxAngle;
        }
    }
}