using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//Prototype implementation of rotate/drag/scroll behaviours for the general render
public class RenderObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IScrollHandler
{

    //camera
    public Camera viewingCamera;


    //camera controls / parameters

    //translations
    public float dragSensitivity = 0.2f;
    public float scrollSensitivity = 50f;


    //zooms
    //public float cameraCloseLimit = 0f;
    //public float cameraFarLimit = 20f;

    //new zooms
    public float minScale = 1.0f;
    public float maxScale = 2.5f;
    float current_scale;

    Material currentMat;

    Vector3 prevPos;
    Vector3 currentPos;

    Vector3 originalCameraPos;
    Vector3 originalObjectScale;
    private Vector3 objectPosition;


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        prevPos = currentPos = eventData.pressPosition;
    }

    //defining these behaviours using pointer clicks but they probably need a different input system setup for controllers?
    // - cam
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        currentPos = eventData.position;


        Vector2 dragDirection = currentPos - prevPos;
        dragDirection = dragDirection.normalized;

        //Debug.Log("drag");
        //currentMat.color = new Color(0, 0, 255);


        if (eventData.button == PointerEventData.InputButton.Left)
        {

            this.transform.Rotate(new Vector3(-dragDirection.y, dragDirection.x, 0f), Space.World);

        }
        /*
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(viewingCamera.orthographic){
            this.transform.position = viewingCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Vector3.Distance(transform.position, viewingCamera.transform.position)));
            }else{
                this.transform.position = viewingCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Vector3.Distance(viewingCamera.transform.position, Vector3.zero)));
            }
        }
        */

        prevPos = eventData.position;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //currentMat.color = new Color(0, 255, 0);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //currentMat.color = new Color(255, 0, 0);
    }

    void Start()
    {
        currentMat = GetComponent<Renderer>().material;
        originalCameraPos = viewingCamera.transform.position;
        current_scale = minScale;
        originalObjectScale = transform.localScale;
    }

    void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        current_scale += scroll * scrollSensitivity * Time.deltaTime;

        current_scale = Mathf.Clamp(current_scale, minScale, maxScale);

        transform.localScale = originalObjectScale * current_scale;

        /*
        if(!viewingCamera.orthographic){
            Vector3 direction = transform.transform.position - viewingCamera.transform.position; //get the direction of the movement
            Vector3 movement = Vector3.MoveTowards(viewingCamera.transform.position, transform.position, scroll * scrollSensitivity * Time.deltaTime);
            if(Vector3.Distance(transform.position, movement) > cameraCloseLimit && Vector3.Distance(originalCameraPos, movement) < cameraFarLimit){ //make sure we do not exceed the close/far limits (also distance calls every frame... yikes)
                viewingCamera.transform.position = movement;
            }
        }
        else {
            float newSize = viewingCamera.orthographicSize - (scroll * scrollSensitivity * Time.deltaTime);
            newSize = Mathf.Clamp(newSize, cameraCloseLimit, cameraFarLimit);
            viewingCamera.orthographicSize = newSize;
        }*/

        //float newCameraDistance = Mathf.Clamp(viewingCamera.transform.position.z, cameraFarLimit, cameraCloseLimit);
       // viewingCamera.transform.position = new Vector3(0f, 1f, newCameraDistance);
    }


    void IScrollHandler.OnScroll(PointerEventData eventData)
    {
        //viewingCamera.transform.Translate(0, 0, eventData.scrollDelta.y);
    }


}
