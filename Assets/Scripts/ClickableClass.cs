using Unity.VisualScripting;
using UnityEngine;

public class ClickableClass : MonoBehaviour
{
    public virtual void OnClick()
    {
        Debug.Log(this.GetType().Name + " Clicked");
    }
}
