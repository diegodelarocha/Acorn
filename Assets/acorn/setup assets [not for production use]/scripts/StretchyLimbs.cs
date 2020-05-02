using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic kind of works, but haven't figured out numbers properly 😅

[ExecuteAlways]
public class StretchyLimbs : MonoBehaviour
{
// // Limbs Variables

//     //Left Leg 
//     [HideInInspector] public Transform leftLow_leg;
//     //Right Leg
//     [HideInInspector] public Transform rightUp_leg;
//     [HideInInspector] public Transform rightLow_leg;

//     //Left Arm 
//     [HideInInspector] public Transform leftUp_arm;
//     [HideInInspector] public Transform leftLow_arm;
//     //Right Arm
//     [HideInInspector] public Transform rightUp_arm;
//     [HideInInspector] public Transform rightLow_arm;

// Measurement Variables
    private float floorOffset = 0.2832183F;
    private float leftLegDistance;
    private float legLength = 2.473208F;
    public Transform leftUp_leg;
    public Transform leftLow_leg;
    public Transform leftFoot;
    public Transform leftFoot_IK;

    void Update(){
        Legs();
    }

    void Legs(){
        // Distance between the hip to the pivot of the IK leg
        leftLegDistance = (leftUp_leg.position - leftFoot_IK.position).magnitude;

        // leftUp leg scale Y
        float leftUp_leg_scaleY = leftUp_leg.localScale.y;
        float leftLow_leg_scaleY = leftLow_leg.localScale.y;

        // float leftFoot_scaleY = leftFoot.localScale.y;
        
        // Normalize scaleY values to 1 as the starting value 
        leftUp_leg_scaleY = leftLegDistance/legLength;
        leftLow_leg_scaleY = leftLegDistance/legLength;

        // leftFoot_scaleY = leftLegDistance/legLength;

        // If Distance is higher than leg distance, stretch
        if (leftLegDistance > legLength){
            leftUp_leg.localScale = new Vector3 (leftUp_leg.localScale.x,leftUp_leg_scaleY,leftUp_leg.localScale.z);
            leftLow_leg.localScale = new Vector3 (leftLow_leg.localScale.x,leftLow_leg_scaleY,leftLow_leg.localScale.z);

            // leftFoot.localScale = new Vector3 (leftFoot.localScale.x,leftFoot.localScale.y,leftFoot.localScale.z);
        }
        // Else
        else if (leftLegDistance == legLength || leftLegDistance < legLength){
            leftUp_leg.localScale = new Vector3 (leftUp_leg.localScale.x,leftUp_leg.localScale.y,leftUp_leg.localScale.z);
            leftLow_leg.localScale = new Vector3 (leftLow_leg.localScale.x,leftLow_leg.localScale.y,leftLow_leg.localScale.z);
        
            // leftFoot.localScale = new Vector3 (leftFoot.localScale.x,leftFoot.localScale.y,leftFoot.localScale.z);
        }
    }
}