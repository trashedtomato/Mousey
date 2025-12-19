using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class TransitionClickScript : ClickableClass
{
    [SerializeField] PlayableDirector transitionCutscene;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public override void OnClick()
    {
        base.OnClick();
        transitionCutscene.Play();
        col.enabled = false;
    }

    private void LeaveComputer()
    {
        col.enabled = true;
    }
}
