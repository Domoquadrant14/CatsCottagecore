using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private float zoomTarget;

    [SerializeField]
    private float multiplier = 2f, minZoom = 1f, maxZoom = 10f, smoothTime = .1f;
    private float velocity = 0f;

    [SerializeField]
    private SpriteRenderer mapRenderer;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    [SerializeField]
    private float camLerpSpeed;

    private Vector3 dragOrigin;
    private float mouseScroll;
    private Vector3 currentMousePos;
    private Vector3 lastMousePos;
    private Vector3 zoomFocalPoint;

    [SerializeField]
    float mouseMoveThreshold;

    [SerializeField]
    float camOrthoSizeMouseLimiter;

    Vector3 camPos;


    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }


    // Start is called before the first frame update
    void Start()
    {
        camPos = cam.transform.position;
        currentMousePos = Input.mousePosition;
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        PanCamera();
        mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        ZoomCamera(mouseScroll);
    }


    private void PanCamera()
    {

        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            //print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);

            cam.transform.position = ClampCamera(cam.transform.position + difference);  

        }

     
    }

  

    private void ZoomCamera(float mouse)
    {
        currentMousePos = Input.mousePosition;
        zoomTarget -= mouse * multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoomTarget, ref velocity, smoothTime);
       
       
        
        if (mouse > 0)
        {

            if( mouseMoveThreshold < Vector3.Distance(currentMousePos, lastMousePos))
            {
                zoomFocalPoint = cam.ScreenToWorldPoint(currentMousePos);

                lastMousePos = currentMousePos;
                camPos = new Vector3(zoomFocalPoint.x, zoomFocalPoint.y, cam.transform.position.z);
                
            }
            else
            {
                camPos = new Vector3(zoomFocalPoint.x, zoomFocalPoint.y, cam.transform.position.z);
                
            }

            
            
        }
        else if( mouse < 0)
        {
            cam.transform.position = camPos;
        }

        if(cam.transform.position != camPos && mouseMoveThreshold >= Vector3.Distance(currentMousePos, lastMousePos))
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, camLerpSpeed * Time.deltaTime);
        }
        cam.transform.position = ClampCamera(cam.transform.position);
        
      
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
