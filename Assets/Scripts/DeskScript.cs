using Unity.Cinemachine;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeskScript : ClickableClass
{
    [SerializeField] CinemachineCamera deskCam;
    private InputAction mBackAction;
    private CinemachineBrain brain;
    private Collider col;
    private bool viewing;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        mBackAction = InputSystem.actions.FindAction("Back");
        brain = FindFirstObjectByType<CinemachineBrain>();
    }

    private void Start()
    {
        col = GetComponent<Collider>();
        mBackAction.started += _ => LeaveDesk();
    }

    public override void OnClick()
    {
        deskCam.enabled = true;
        col.enabled = false;
    }

    private void LeaveDesk()
    {
        if(deskCam.name == brain.ActiveVirtualCamera.Name && brain.ActiveBlend == null)
        {
            deskCam.enabled = false;
            col.enabled = true;
        }
    }
}
