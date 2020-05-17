using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using DitzelGames;
using UnityEngine;

namespace Acorn
    /// <summary>
    /// This is a duplicate of FK_IK_switch, but 
    /// its only for `acorn_example.prefab` since
    /// that prefab is deprecated, and needs a separate
    /// controller to keep the main prefab cleaner.
    ///
    /// Controller for FK IK switches on all Acorn, 
    /// as well as Visibility ON/OFF for Handles, both on Edit and Play mode.
    /// </summary>
{
    public class FK_IK_switch_example : MonoBehaviour
    {
    // IK-FK Switch Variables

    // IK Script Component - FastIKLook
        [HideInInspector] public DitzelGames.FastIK.FastIKLook head_fastIKLook;
    // IK Script Component - FastIKFabric
        [HideInInspector] public DitzelGames.FastIK.FastIKFabric leftHand_fastIKFabric;
        [HideInInspector] public DitzelGames.FastIK.FastIKFabric rightHand_fastIKFabric;
        [HideInInspector] public DitzelGames.FastIK.FastIKFabric leftFoot_fastIKFabric;
        [HideInInspector] public DitzelGames.FastIK.FastIKFabric rightFoot_fastIKFabric;

        
    // Handle Renderers
        [HideInInspector] public MeshRenderer head_handleRenderer;
        [HideInInspector] public MeshRenderer[] leftHand_handleRenderer;
        [HideInInspector] public MeshRenderer[] rightHand_handleRenderer;
        [HideInInspector] public MeshRenderer[] leftFoot_handleRenderer;
        [HideInInspector] public MeshRenderer[] rightFoot_handleRenderer;
        [HideInInspector] public MeshRenderer[] root_handleRenderer;

    // Visibility Variables
        [Header("Handles Visibility (Play Mode)")]
        public bool handlesVis = true;
        
        private bool head_Vis = true;
        private bool leftHand_Vis = true;
        private bool rightHand_Vis = true;
        private bool leftFoot_Vis = true;
        private bool rightFoot_Vis =true;
        private bool root_Vis = true;

    // Match FK-IK Transform Variables

        [HideInInspector] public Transform leftHand;
        [HideInInspector] public Transform leftHand_IKHandle;
        [HideInInspector] public Transform rightHand;
        [HideInInspector] public Transform rightHand_IKHandle;
        [HideInInspector] public Transform leftFoot;
        [HideInInspector] public Transform leftFoot_IKHandle;
        [HideInInspector] public Transform rightFoot;
        [HideInInspector] public Transform rightFoot_IKHandle;

    // FK-IK Switch

    // All FK

        [Button("All FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void all_FK(){
            head_FK();
            leftHand_FK();
            rightHand_FK();
            leftFoot_FK();
            rightFoot_FK();

            Debug.Log("Switch All to FK");
        }

    // All IK
    
        [Button("All IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void all_IK(){
            head_IK();
            leftHand_IK();
            rightHand_IK();
            leftFoot_IK();
            rightFoot_IK();

            Debug.Log("Switch All to IK");
        }

    // Head
        [Button("Head FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void head_FK(){
            head_fastIKLook.enabled = false;
            head_handleRenderer.enabled = false; 

            Debug.Log("Switch Head to FK");      
        }

        [Button("Head IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void head_IK(){
            head_fastIKLook.enabled = true;
            head_handleRenderer.enabled = true;

            Debug.Log("Switch Head to IK");
        }

    // Left Hand

        [Button("Left Hand FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void leftHand_FK(){
            leftHand_fastIKFabric.enabled = false;
            
            for(int i = 0; i < leftHand_handleRenderer.Length; i++){
                leftHand_handleRenderer[i].enabled = false;
            }

            Debug.Log("Switch Left Hand to FK");
        }

        [Button("Left Hand IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void leftHand_IK(){
            leftHand_fastIKFabric.enabled = true;
            
            for(int i = 0; i < leftHand_handleRenderer.Length; i++){
                leftHand_handleRenderer[i].enabled = true;
            }
            
            // Match FK-IK Transforms
            leftHand_IKHandle.position = leftHand.position;
            leftHand_IKHandle.rotation = leftHand.rotation;

            Debug.Log("Switch Left Hand to IK, and Match IK to FK Position + Rotation");

        }

    // Right Hand

        [Button("Right Hand FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void rightHand_FK(){
            rightHand_fastIKFabric.enabled = false;
            
            for(int i = 0; i < rightHand_handleRenderer.Length; i++){
                rightHand_handleRenderer[i].enabled = false;
            }

            Debug.Log("Switch Right Hand to FK");
        }

        [Button("Right Hand IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void rightHand_IK(){
            rightHand_fastIKFabric.enabled = true;
            
            for(int i = 0; i < rightHand_handleRenderer.Length; i++){
                rightHand_handleRenderer[i].enabled = true;
            }
            
            // Match FK-IK Transforms
            rightHand_IKHandle.position = rightHand.position;
            rightHand_IKHandle.rotation = rightHand.rotation;

            Debug.Log("Switch Right Hand to IK, and Match IK to FK Position + Rotation");
        }


    // Left Foot

        [Button("Left Foot FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void leftFoot_FK(){
            leftFoot_fastIKFabric.enabled = false;
            
            for(int i = 0; i < leftFoot_handleRenderer.Length; i++){
                leftFoot_handleRenderer[i].enabled = false;
            }

            Debug.Log("Switch Left Foot to FK");
        }

        [Button("Left Foot IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void leftFoot_IK(){
            leftFoot_fastIKFabric.enabled = true;
            
            for(int i = 0; i < leftFoot_handleRenderer.Length; i++){
                leftFoot_handleRenderer[i].enabled = true;
            }
            
            // Match FK-IK Transforms
            leftFoot_IKHandle.position = leftFoot.position;
            leftFoot_IKHandle.rotation = leftFoot.rotation;

            Debug.Log("Switch Left Foot to IK, and Match IK to FK Position + Rotation");
        }


    // Right Foot

        [Button("Right Foot FK", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
        void rightFoot_FK(){
            rightFoot_fastIKFabric.enabled = false;
            
            for(int i = 0; i < rightFoot_handleRenderer.Length; i++){
                rightFoot_handleRenderer[i].enabled = false;
            }

            Debug.Log("Switch Right Foot to FK");
        }

        [Button("Right Foot IK", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void rightFoot_IK(){
            rightFoot_fastIKFabric.enabled = true;
            
            for(int i = 0; i < rightFoot_handleRenderer.Length; i++){
                rightFoot_handleRenderer[i].enabled = true;
            }
            
            // Match FK-IK Transforms
            rightFoot_IKHandle.position = rightFoot.position;
            rightFoot_IKHandle.rotation = rightFoot.rotation;

            Debug.Log("Switch Right Foot to IK, and Match IK to FK Position + Rotation");
        }

    // Visibility Functions
        void LateUpdate(){
            VisAll();  
        }
        void VisAll(){
            if(handlesVis == false){
                VisOff();      
            }
            else{
                VisOn();      
            }
        }
        void Vis(){

            head_handleRenderer.enabled = head_Vis;

            for(int i = 0; i < leftHand_handleRenderer.Length; i++){
            leftHand_handleRenderer[i].enabled = leftHand_Vis;
            } 
            for(int i = 0; i < rightHand_handleRenderer.Length; i++){
            rightHand_handleRenderer[i].enabled = rightHand_Vis;
            } 
            for(int i = 0; i < leftFoot_handleRenderer.Length; i++){
            leftFoot_handleRenderer[i].enabled = leftFoot_Vis;
            } 
            for(int i = 0; i < rightFoot_handleRenderer.Length; i++){
            rightFoot_handleRenderer[i].enabled = rightFoot_Vis;
            }         
            for(int i = 0; i < root_handleRenderer.Length; i++){
            root_handleRenderer[i].enabled = root_Vis;
            } 
        }


    // Visibility OFF Button
        [Button("Visibility OFF", ButtonMode.DisabledInPlayMode, ButtonSpacing.Before)]
            void VisOff(){
            head_handleRenderer.enabled = false;

            for(int i = 0; i < leftHand_handleRenderer.Length; i++){
            leftHand_handleRenderer[i].enabled = false;
            } 
            for(int i = 0; i < rightHand_handleRenderer.Length; i++){
            rightHand_handleRenderer[i].enabled = false;
            } 
            for(int i = 0; i < leftFoot_handleRenderer.Length; i++){
            leftFoot_handleRenderer[i].enabled = false;
            } 
            for(int i = 0; i < rightFoot_handleRenderer.Length; i++){
            rightFoot_handleRenderer[i].enabled = false;
            }         
            for(int i = 0; i < root_handleRenderer.Length; i++){
            root_handleRenderer[i].enabled = false;
            }            

            Debug.Log("Set Visibility OFF on all Handles");     
        }

    // Visibility ON Button
        [Button("Visibility ON", ButtonMode.DisabledInPlayMode, ButtonSpacing.After)]
        void VisOn(){
            head_handleRenderer.enabled = true;
            
            for(int i = 0; i < leftHand_handleRenderer.Length; i++){
            leftHand_handleRenderer[i].enabled = true;
            } 
            for(int i = 0; i < rightHand_handleRenderer.Length; i++){
            rightHand_handleRenderer[i].enabled = true;
            } 
            for(int i = 0; i < leftFoot_handleRenderer.Length; i++){
            leftFoot_handleRenderer[i].enabled = true;
            } 
            for(int i = 0; i < rightFoot_handleRenderer.Length; i++){
            rightFoot_handleRenderer[i].enabled = true;
            }         
            for(int i = 0; i < root_handleRenderer.Length; i++){
            root_handleRenderer[i].enabled = true;
            }    

            Debug.Log("Set Visibility ON on all Handles");
        }    
    }
}