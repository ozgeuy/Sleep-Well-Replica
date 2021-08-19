using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetController : MonoBehaviour
{
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;
    [SerializeField] private GameObject[] bodyParts;

    [SerializeField] private Animator alarmClocksAnimator;

   [SerializeField] private Transform bodyIKTransform;
   
    private Vector3 offset;

    private float zCoord;
    private float _maxDistance = 0.1f;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isDragging)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                if (gameObject.tag == bodyParts[i].tag)
                {
                    transform.position = bodyParts[i].transform.position;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Clock")
        {
            Debug.Log("turned off");
            LevelManager.Instance.SetLevel();
            alarmClocksAnimator.enabled = false;
        }
    }

    private void OnMouseDrag()
    {
        for(int i =0; i < bodyParts.Length; i++)
        {
            if(gameObject.tag == bodyParts[i].tag)
            {
                isDragging = true;
                SetIKTransformPosition(bodyParts[i], _maxDistance);
            }
            
        }
       
        
     
    }
    private void OnMouseDown()
    {
        isDragging = false;
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void SetIKTransformPosition(GameObject bodyPart, float maxDistance)
    {
        if (Mathf.Abs(gameObject.transform.position.x - bodyPart.transform.position.x) <= maxDistance &&
        Mathf.Abs(gameObject.transform.position.y - bodyPart.transform.position.y) <= maxDistance)
        {
            
            transform.position = GetMouseWorldPosition() + offset;

        }
        else
        {        
            bodyIKTransform.position += new Vector3((gameObject.transform.position.x - bodyPart.transform.position.x) - maxDistance,
                (gameObject.transform.position.y - bodyPart.transform.position.y) - maxDistance, 0);

        }
    }
}
