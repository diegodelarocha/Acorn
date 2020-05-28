using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SideSwapper : MonoBehaviour
{
    [SerializeField]
    Transform headIKHandle;

    [SerializeField]
    IKPair[] IKHandlePairs;

    Quaternion mirrorRotationNormal = new Quaternion(1, 0, 0, 0);

    Object[] undoObjects;

    [Button("Swap Side", ButtonSpacing.Before)]
    void SwapSide()
    {
        if (undoObjects == null)
        {
            undoObjects = IKHandlePairs.SelectMany(pair => new Transform[] { pair.leftIKHandle, pair.rightIKHandle })
            .Concat(new Transform[] { headIKHandle })
            .Select(s => s as Object)
            .ToArray();
        }

#if UNITY_EDITOR
        Undo.RecordObjects(undoObjects, "Swap Side");
#endif
        Vector3 newHeadPosition = headIKHandle.localPosition;
        newHeadPosition.x = -newHeadPosition.x;

        Quaternion newHeadRotation = headIKHandle.localRotation;
        newHeadRotation = mirrorRotationNormal * newHeadRotation * mirrorRotationNormal;

        headIKHandle.localPosition = newHeadPosition;
        headIKHandle.localRotation = newHeadRotation;



        for (int i = 0; i < IKHandlePairs.Length; i++)
        {
            Vector3 newRightPosition = IKHandlePairs[i].leftIKHandle.localPosition;
            newRightPosition.x = IKHandlePairs[i].rightIKHandle.localPosition.x;
            Quaternion newRightRotation = IKHandlePairs[i].leftIKHandle.localRotation;
            newRightRotation = mirrorRotationNormal * newRightRotation * mirrorRotationNormal;


            Vector3 newLeftPosition = IKHandlePairs[i].rightIKHandle.localPosition;
            newLeftPosition.x = IKHandlePairs[i].leftIKHandle.localPosition.x;
            Quaternion newLeftRotation = IKHandlePairs[i].rightIKHandle.localRotation;
            newLeftRotation = mirrorRotationNormal * newLeftRotation * mirrorRotationNormal;




            IKHandlePairs[i].leftIKHandle.localPosition = newLeftPosition;
            IKHandlePairs[i].leftIKHandle.localRotation = newLeftRotation;

            IKHandlePairs[i].rightIKHandle.localPosition = newRightPosition;
            IKHandlePairs[i].rightIKHandle.localRotation = newRightRotation;

            //IKHandles[i].transform.position = Vector3.Reflect(IKHandles[i].transform.position, transform.right);
        }
    }

    [System.Serializable]
    public class IKPair
    {
        public Transform leftIKHandle;
        public Transform rightIKHandle;
    }
}
