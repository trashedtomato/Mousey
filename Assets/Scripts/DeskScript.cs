using UnityEngine;
using Unity.Cinemachine;

public class DeskScript : ClickableClass
{
    [SerializeField] CinemachineCamera deskCam;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public override void OnClick()
    {
        base.OnClick();
        deskCam.enabled = true;
        col.enabled = false;
    }

    private void LeaveDesk()
    {
        deskCam.enabled = false;
        col.enabled = true;
    }
}
