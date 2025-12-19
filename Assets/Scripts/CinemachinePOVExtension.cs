using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float clampAngle = 80f;

    private Vector3 startingRotation;
    private InputAction mLookAction;
    private Vector2 mLook;

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.rotation = transform.parent.rotation;
    }

    void Start()
    {
        mLookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        GetMousePos();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = mLook;
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

    private void GetMousePos()
    {
        mLook = mLookAction.ReadValue<Vector2>();
    }
}
