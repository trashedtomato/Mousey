using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    private CinemachineBrain brain;
    [SerializeField] private CinemachineCamera[] cams;
    public int currentCam;

    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }

    public void CamEnable()
    {
        brain.DefaultBlend.Style = CinemachineBlendDefinition.Styles.Cut;
        cams[currentCam].enabled = true;
    }

    public void CamDisable()
    {
        brain.DefaultBlend.Style = CinemachineBlendDefinition.Styles.EaseIn;
        cams[currentCam].enabled = false;
    }
}
