using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Acorn
{
    public class SideSwapper : MonoBehaviour
    {
        /// <summary>
        ///Mirror's poses, useful for stuff like walk cycles.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        Transform[] individualSwaps;

        [SerializeField]
        [HideInInspector]
        IKPair[] swapPairs;

        Quaternion mirrorRotationNormal = new Quaternion(1, 0, 0, 0);

        Object[] undoObjects;

        [Button("Swap Side", ButtonSpacing.Before)]
        void SwapSide()
        {

            swapPairs = swapPairs.OrderByDescending(s => GetChildDepth(s.leftIKHandle)).ToArray();
            individualSwaps = individualSwaps.OrderByDescending(s => GetChildDepth(s)).ToArray();

            undoObjects = swapPairs.SelectMany(pair => new Transform[] { pair.leftIKHandle, pair.rightIKHandle })
            .Concat(individualSwaps)
            .Select(s => s as Object)
            .ToArray();

            Vector3 mirrorNomral = transform.right;
            //mirrorRotationNormal = new Quaternion(transform.right.x, transform.right.y, transform.right.z, 0);



#if UNITY_EDITOR
            Undo.RecordObjects(undoObjects, "Swap Side");
#endif



            for (int i = 0; i < swapPairs.Length; i++)
            {

                Vector3 newRightPosition = MirrorPosition(swapPairs[i].leftIKHandle.localPosition);
                Quaternion newRightRotation = MirrorQuaternion(swapPairs[i].leftIKHandle.localRotation);


                Vector3 newLeftPosition = MirrorPosition(swapPairs[i].rightIKHandle.localPosition);
                Quaternion newLeftRotation = MirrorQuaternion(swapPairs[i].rightIKHandle.localRotation);




                swapPairs[i].leftIKHandle.localPosition = newLeftPosition;
                swapPairs[i].leftIKHandle.localRotation = newLeftRotation;

                swapPairs[i].rightIKHandle.localPosition = newRightPosition;
                swapPairs[i].rightIKHandle.localRotation = newRightRotation;

            }

            for (int i = 0; i < individualSwaps.Length; i++)
            {

                Vector3 newIndividualPosition = MirrorPosition(individualSwaps[i].localPosition);

                Quaternion newIndividualRotation = MirrorQuaternion(individualSwaps[i].localRotation);

                individualSwaps[i].localPosition = newIndividualPosition;
                individualSwaps[i].localRotation = newIndividualRotation;
            }
        }
        Vector3 MirrorPosition(Vector3 position)
        {
            Vector3 normal = transform.right;
            return Vector3.Reflect(position, normal);
        }
        Quaternion MirrorQuaternion(Quaternion quaternion)
        {
            Vector3 normal = transform.right;

            Quaternion mirrorNormalQuat = new Quaternion(normal.x, normal.y, normal.z, 0).normalized;
            return mirrorNormalQuat * quaternion * mirrorNormalQuat;
        }


        Quaternion GetRelativeRotation(Quaternion parentRotation, Quaternion childRotation)
        {
            return Quaternion.Inverse(parentRotation) * childRotation;
        }

        static int GetChildDepth(Transform child)
        {
            SideSwapper thisScript = child.GetComponentInParent<SideSwapper>();
            if (!thisScript)
            {
                return -1;
            }
            int depthIndex = 0;
            Transform currentParent = child.parent;
            while (currentParent.transform != thisScript.transform)
            {
                depthIndex++;
                currentParent = currentParent.parent;
            }
            return depthIndex;
        }

        [System.Serializable]
        public class IKPair
        {
            public Transform leftIKHandle;
            public Transform rightIKHandle;
        }
    }
}