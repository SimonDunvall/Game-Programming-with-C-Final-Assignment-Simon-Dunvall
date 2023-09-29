using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    public class WheelDrive : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float maxTorque = 300f;
        private GameObject wheelShape;

        private WheelCollider[] m_Wheels;

        private float angle, torque;

        public InputActionAsset primaryActions;
        private InputActionMap gameplayActionMap;
        private InputAction steeringAngleInputAction;
        private InputAction accelerationInputAction;

        private void Start()
        {
            m_Wheels = GetComponentsInChildren<WheelCollider>();

            foreach (var wheel in m_Wheels)
            {
                if (wheelShape != null)
                {
                    Instantiate(wheelShape, wheel.transform, true);
                }
            }
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

        private void Update()
        {
            foreach (WheelCollider wheel in m_Wheels)
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

                if (wheel.transform.localPosition.z >= 0)
                {
                    wheel.motorTorque = torque;
                }

                if (!wheelShape) continue;
                wheel.GetWorldPose(out var p, out var q);

                Transform shapeTransform = wheel.transform.GetChild(0);

                if (wheel.name == "a0l" || wheel.name == "a1l" || wheel.name == "a2l")
                {
                    shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
                    shapeTransform.position = p;
                }
                else
                {
                    shapeTransform.position = p;
                    shapeTransform.rotation = q;
                }
            }
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