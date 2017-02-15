using System;
using UnityEngine;

namespace Assets.Scripts.Triggers.Helpers
{
    public class ObjectChanger
    {
        private const float ROTATION_DEF = 180;

        private Vector3 objectInfo;
        private Quaternion objectRotation;
        private PlayerCameraFollow _cameraFollow;
        private Camera _camera;
        private float _rotationAnchor;
        private GameObject _mainObject;
        private PlayerScript _player;
        private bool _isCameraRestart;

        public ObjectChanger(GameObject gameObject, PlayerScript playerScript, PlayerCameraFollow cameraFollow, Camera camera, float? rotationAnchor, bool isCameraRestart)
        {
            _cameraFollow = cameraFollow;
            _camera = camera;
            _rotationAnchor = rotationAnchor.HasValue ? rotationAnchor.Value : ROTATION_DEF;
            _mainObject = gameObject;
            _player = playerScript;
            _isCameraRestart = isCameraRestart;
        }

        public void Change()
        {
            objectInfo = _mainObject.transform.transform.position;
            _camera.transform.Rotate(new Vector3(0, _camera.transform.rotation.y + _rotationAnchor, 0));
            objectRotation = _mainObject.transform.transform.rotation;
            _mainObject.transform.Rotate(objectRotation.x, objectRotation.y + _rotationAnchor, objectRotation.z);

            if(_isCameraRestart)
            {
                _cameraFollow.IsInvert = false;
                _player.IsInvert = false;
            }
            else
            {
                if (_cameraFollow.IsInvert)
                {
                    _cameraFollow.IsInvert = false;
                    _player.IsInvert = false;
                }
                else
                {
                    _cameraFollow.IsInvert = true;
                    _player.IsInvert = true;
                }
            }

            
        }
    }
}
