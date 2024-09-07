using System;
using UnityEngine;

namespace Arkanoid.Scripts
{
    public class InputHandler {
        private bool isLocked;
        
        private Action onLeftAndRightReleased;
        private Action onLeftButtonPressed;
        private Action onRightButtonPressed;
        private Action onThrowBallButtonPressed;

        public Action OnLeftAndRightReleased {
            get => onLeftAndRightReleased;
            set => onLeftAndRightReleased = value;
        }

        public Action OnLeftButtonPressed
        {
            get => onLeftButtonPressed;
            set => onLeftButtonPressed = value;
        }

        public Action OnRightButtonPressed
        {
            get => onRightButtonPressed;
            set => onRightButtonPressed = value;
        }

        public Action OnThrowBallButtonPressed
        {
            get => onThrowBallButtonPressed;
            set => onThrowBallButtonPressed = value;
        }

        public void Update() {
            if (isLocked) {
                return;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                onLeftButtonPressed?.Invoke();
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                onRightButtonPressed?.Invoke();
            } else {
                onLeftAndRightReleased?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                onThrowBallButtonPressed?.Invoke();
            }
        }

        public void LockInput() {
            isLocked = true;
        }

        public void UnlockInput() {
            isLocked = false;
        }
    }
}