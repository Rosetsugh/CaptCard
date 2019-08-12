using System;
using UnityEngine;
// ReSharper disable UnusedMember.Local

namespace Assets.Scripts.Swipe {
    public class SwipeController : MonoBehaviour
    {
        [Range(0f,1f)]
        public float ThrowableFactor;
        [Range(0f, 1f)]
        public float ChoiceTriggerFactor;
        private TranslationController translation;
        private RotationController rotation;
        private ScaleController scale;

        private float touchStartPos;

        private void Start()
        {
            CardState.LockCard = false;
            translation = GetComponentInChildren<TranslationController>();
            rotation = GetComponentInChildren<RotationController>();
            scale = GetComponentInChildren<ScaleController>();
        }

        private void Update()
        {
            if (CardState.LockCard) return;
            if (Input.touches.Length > 0)
            {
                var phase = Input.touches[0].phase;
                switch (phase)
                {
                    case TouchPhase.Began:
                        touchStartPos = Input.touches[0].position.x;
                        break;
                    case TouchPhase.Moved:
                        translation.TranslateCard();
                        rotation.RotateCard();
                        scale.ScaleCard();
                        if (Input.touches[0].position.x - touchStartPos > Screen.width * ChoiceTriggerFactor)
                        {
                            CardState.IsCardOnRight = true;

                            CardState.IsCardOnLeft = false;
                            CardState.IsCardOnReallyLeft = false;

                            CardState.IsCardOnReallyRight = Input.touches[0].position.x - touchStartPos > Screen.width * ThrowableFactor;
                        }
                        else if (touchStartPos - Input.touches[0].position.x > Screen.width * ChoiceTriggerFactor)
                        {
                            CardState.IsCardOnLeft = true;

                            CardState.IsCardOnRight = false;
                            CardState.IsCardOnReallyRight = false;

                            CardState.IsCardOnReallyLeft = touchStartPos - Input.touches[0].position.x > Screen.width * ThrowableFactor;
                        }
                        else
                        {
                            CardState.IsCardOnRight = false;
                            CardState.IsCardOnLeft = false;
                        }
                        break;
                    case TouchPhase.Ended:
                        if (Input.touches[0].position.x - touchStartPos > Screen.width * ThrowableFactor)
                        {
                            //Debug.Log("Right Throw");
                            CardState.ThrowRight = true;
                            CardState.ThrowLeft = false;
                            CardState.IsCardThrownable = true;
                            CardState.LockCard = true;
                        }
                        if (touchStartPos - Input.touches[0].position.x > Screen.width * ThrowableFactor)
                        {
                            //Debug.Log("Left Throw");
                            CardState.ThrowLeft = true;
                            CardState.ThrowRight = false;
                            CardState.IsCardThrownable = true;
                            CardState.LockCard = true;
                        }
                        break;
                    case TouchPhase.Stationary:
                        break;
                    case TouchPhase.Canceled:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                translation.ResetPositionOfCard();
                rotation.ResetRotationOfCard();
                scale.ResetScaleOfCard();
            }
        }
    }
}
