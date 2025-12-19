using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D cursor, cursorClicked;
    private PlayerControls controls;
    private Camera mainCam;

    private void Awake()
    {
        controls = new PlayerControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        controls.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        controls.Office.Click.started += _ => StartClick();
        controls.Office.Click.performed += _ => EndClick();
    }

    private void StartClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }

    private void DetectObject()
    {
        Ray ray = mainCam.ScreenPointToRay(controls.Office.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Clickable")
            {
                hit.collider.gameObject.GetComponent<ClickableClass>().OnClick();
            }

            if(hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }

        /*RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {
                Debug.Log("Hit All: " + hits[i].collider.name);
            }
        }*/
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
