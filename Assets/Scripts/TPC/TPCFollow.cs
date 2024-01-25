using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public abstract class TPCFollow : TPCBase
    {
        public TPCFollow(Transform cameraTransform, Transform playerTransform)
            : base(cameraTransform, playerTransform)
        {
        }

        public override void Update()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            //// Double comments as this is from the script
            //// Now we calculate the camera transformed axes.
            //// We do this because our camera's rotation might have changed
            //// in the derived class Update implementations. Calculate the new 
            //// forward, up and right vectors for the camera.
            //calculate the camera transformed axes with the current camera rotation
            Vector3 forward = mCameraTransform.rotation * Vector3.forward;
            Vector3 right = mCameraTransform.rotation * Vector3.right;
            Vector3 up = mCameraTransform.rotation * Vector3.up;

            //// For this we first calculate the targetPos
            // calculate the targeted position for the camera, which is the player transform position
            Vector3 targetPos = mPlayerTransform.position;

            //calculate the desired position for the camera based on the targeted position and the offset of the camera
            Vector3 desiredPosition = CameraDesiredPosition(targetPos, CameraOffSet(forward,right,up));

            //lerp the desired position to be a smooth move
            CameraPositionLerp(desiredPosition);
        }

        //// Add the camera offset to the target position.
        //// Note that we cannot just add the offset.
        //// You will need to take care of the direction as well.
        private Vector3 CameraDesiredPosition(Vector3 targetPos, Vector3 offset)
        {
            //return the calculated desired position by adding the targeted positon and the offset of the camera position
            return targetPos + offset;
        }

        //// We then calculate the offset in the camera's coordinate frame. 
        private Vector3 CameraOffSet(Vector3 forward, Vector3 right, Vector3 up)
        {
            //calculate each offset of the camera position
            Vector3 forwardOffSet = forward * CameraConstants.CameraPositionOffset.z;
            Vector3 rightOffSet = right * CameraConstants.CameraPositionOffset.x;
            Vector3 upOffSet = up * CameraConstants.CameraPositionOffset.y;

            //add it all together
            Vector3 offset = forwardOffSet + rightOffSet + upOffSet;
            return offset;
        }

        //// Finally, we change the position of the camera, 
        //// not directly, but by applying Lerp.
        private void CameraPositionLerp(Vector3 desiredPosition)
        {
            //lerp the position to smoothly interpolate between the current camera position to the desired position
            Vector3 position = Vector3.Lerp(mCameraTransform.position, desiredPosition, Time.deltaTime * CameraConstants.Damping);
            //update the camera position
            mCameraTransform.position = position;
        }
    }
}