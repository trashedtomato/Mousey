using Unity.Cinemachine;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{
    private InputAction mBackAction;
    private CinemachineBrain brain;
    [SerializeField] private CinemachineCamera[] cams;
    [SerializeField] PlayableDirector CamExit;
    public int currentCam;
    public bool viewing;
    private void Awake()
    {
        mBackAction = InputSystem.actions.FindAction("Back");
    }

    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
        mBackAction.started += _ => BackOut();
    }

    public void CamEnable()
    {
        brain.DefaultBlend.Style = CinemachineBlendDefinition.Styles.Cut;
        cams[currentCam].enabled = true;
        viewing = true;
    }

    public void CamDisable()
    {
        brain.DefaultBlend.Style = CinemachineBlendDefinition.Styles.EaseIn;
        cams[currentCam].enabled = false;
        viewing = false;
    }

    public void SwapCam(int cam)
    {
        if (cam != currentCam)
        {
            cams[cam].enabled = true;
            cams[currentCam].enabled = false;
            currentCam = cam;
        }
    }

    private void BackOut()
    {
        if (viewing)
        {
            CamExit.Play();
        }
    }
}
