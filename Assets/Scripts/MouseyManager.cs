using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.Playables;

public class MouseyManager : MonoBehaviour
{
    private InputAction mBackAction;
    public bool viewing;

    [SerializeField] MouseyMovement mMovement;
    [SerializeField] GameObject vCam, fadeCam;
    [SerializeField] PlayableDirector MouseyExit;

    private void Awake()
    {
        mBackAction = InputSystem.actions.FindAction("Back");
    }

    void Start()
    {
        mBackAction.started += _ => BackOut();
    }

    public void EnterMousey()
    {
        vCam.GetComponent<CinemachineCamera>().enabled = true;
        fadeCam.GetComponent<CinemachineCamera>().enabled = true;
        vCam.GetComponent<CinemachinePOVExtension>().enabled = true;
        fadeCam.GetComponent<CinemachinePOVExtension>().enabled = true;
        mMovement.enabled = true;
        viewing = true;
    }

    private void BackOut()
    {
        if(viewing)
        {
            MouseyExit.Play();
            vCam.GetComponent<CinemachinePOVExtension>().enabled = false;
            fadeCam.GetComponent<CinemachinePOVExtension>().enabled = false;
            mMovement.enabled = false;
            viewing = false;
        }
    }
}
