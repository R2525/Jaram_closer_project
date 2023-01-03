using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Intrinsics : MonoBehaviour
{
    // Start is called before the first frame update
    
    public struct ARCameraIntrinsics
    {
        public Vector2 ARFocalLength;
        public Vector2 ARPrincipalPoint;
        public Vector2Int ARImageDimensions;
        public float[] ARDistortion;

        internal ARCameraIntrinsics(Vector2 arFocalLength, Vector2 arPrincipalPoint,
                                     Vector2Int arImageDimensions, float[] arDistortion)
        {
            ARFocalLength = arFocalLength;
            ARPrincipalPoint = arPrincipalPoint;
            ARImageDimensions = arImageDimensions;
            ARDistortion = arDistortion;
        }
    }
}
