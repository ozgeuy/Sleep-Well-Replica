﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPlacements : MonoBehaviour
{
    [SerializeField] private Transform leftFootIKTransform;
    [SerializeField] private Transform rightFootIKTransform;
    [SerializeField] private Transform leftHandIKTransform;
    [SerializeField] private Transform rightHandIKTransform;

    private Animator animator;



   

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //#region ray'in carptigi cismin pozisyonunu mouse'a bagli degistiriyor
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
            
        //    if (hit.transform.tag == "IKTransform")
        //    {


        //        hit.transform.position = hit.point;
                
        //    }

        //}
        //#endregion
    }

    public void OnAnimatorIK()
    {
        if (animator)
        {
            #region Left foot
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);

            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootIKTransform.position);
            #endregion

            #region Right foot
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);

            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootIKTransform.position);
            #endregion

            #region Left Hand
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKTransform.position);
            #endregion

            #region Right Hand
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTransform.position);
            #endregion
        }
    }
}
