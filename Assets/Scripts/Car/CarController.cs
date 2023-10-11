using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float maxAngle;
        [SerializeField] private float maxTorque;

        private WheelCollider[] wheelsColliders;
        private Transform[] wheelsTransforms;

        [SerializeField] private Transform frontLeftWheelTransform,
            frontRightWheelTransform,
            rearLeftWheelTransform,
            rearRightWheelTransform;

        private float angle, torque;

        [SerializeField] private InputActionAsset primaryActions;
        private InputActionMap gameplayActionMap;
        private InputAction steeringAngleInputAction;
        private InputAction accelerationInputAction;

        private void Start()
        {
            wheelsColliders = GetComponentsInChildren<WheelCollider>();
            wheelsTransforms = new[]
            {
                frontLeftWheelTransform,
                frontRightWheelTransform,
                rearLeftWheelTransform,
                rearRightWheelTransform
            };
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

            for (int i = 0; i < wheelsColliders.Count(); i++)
            {
                UpdateSingleWheel(wheelsColliders[i], wheelsTransforms[i]);
            }
        }

        private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
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