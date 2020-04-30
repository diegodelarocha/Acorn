using UnityEditor;
using UnityEngine;
 
namespace Infrastructure.Editor
{
    public class avatarCreator
    {
        [MenuItem("Tools/AvatarTools/CreateAvatarMask")]
        private static void CreateAvatarMask()
        {
            GameObject activeGameObject = Selection.activeGameObject;
 
            if (activeGameObject != null)
            {
                AvatarMask avatarMask = new AvatarMask();
 
                avatarMask.AddTransformPath(activeGameObject.transform);
 
                var path = string.Format("Assets/{0}.mask", activeGameObject.name.Replace(':', '_'));
                AssetDatabase.CreateAsset(avatarMask, path);
            }
        }
 
        [MenuItem("Tools/AvatarTools/CreateAvatar")]
        private static void CreateAvatar()
        {
            GameObject activeGameObject = Selection.activeGameObject;
 
            if (activeGameObject != null)
            {
                Avatar avatar = AvatarBuilder.BuildGenericAvatar(activeGameObject, "");
                avatar.name = activeGameObject.name;
                Debug.Log(avatar.isHuman ? "is human" : "is generic");
 
                var path = string.Format("Assets/{0}.ht", avatar.name.Replace(':', '_'));
                AssetDatabase.CreateAsset(avatar, path);
            }
        }
    }
}