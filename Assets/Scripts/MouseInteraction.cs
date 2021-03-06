using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    private Camera cam;
    private bool isDragging;
    private GameObject selectedObj;

    private int draggableMask;
    private int interactionMask;

    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        isDragging = false;

        draggableMask = LayerMask.GetMask("Draggable");
        interactionMask = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 10.0f, draggableMask))
            {
                if (hit.collider != null)
                {
                    selectedObj = hit.collider.gameObject;
                    isDragging = true;
                }
            }
        }
        if (isDragging)
        {
            Vector3 pos = mousePos();
            selectedObj.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 10.0f, interactionMask))
            {
                if (hit.collider != null)
                {
                    IInteractionBehavior behavior = hit.collider.gameObject.GetComponent<IInteractionBehavior>();
                    if(behavior != null)
                    {
                        behavior.interact();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 10.0f, draggableMask))
            {
                if (hit.collider != null)
                {
                    Ingredient ingredient = hit.collider.gameObject.GetComponent<Ingredient>();
                    if (ingredient != null)
                    {
                        GameManager.instance.setPopUp(ingredient);
                    }
                }
            }
        }
    }

    Vector3 mousePos()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
    }
}
