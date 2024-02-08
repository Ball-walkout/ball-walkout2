using System.Collections.Generic;
using UnityEngine;

namespace DragJump
{
    public class DragJumpUtility
    {
        private bool isDrag = false;
        private float initTouchTime, initTouchY;
        private float lastTouchTime, lastTouchY;
        private float lastSpeed;
        private Touch touch;

        private float jumpMinTime = 0.1f, jumpMaxTime = 0.6f;
        private float jumpMinHeightRatio = 0.2f;
        public void SetJumpTime(float minTime = 0.1f, float maxTime = 0.6f)
        {
            jumpMinTime = minTime;
            jumpMaxTime = maxTime;
        }
        public void SetJumpRatio(float heightRatio = 0.2f)
        {
            jumpMinHeightRatio = heightRatio;
        }
        public bool GetJumpDrag()
        {
            if(Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if(!isDrag)
                {
                    isDrag = true;
                    initTouchTime = Time.time;
                    initTouchY = touch.position.y;
                }
            }
            if(isDrag && touch.phase == TouchPhase.Ended)
            {
                isDrag = false;
                touch = Input.GetTouch(0);
                lastTouchTime = Time.time;
                lastTouchY = touch.position.y;
            }
            if(!isDrag && lastTouchTime - initTouchTime >= jumpMinTime
                    && lastTouchTime - initTouchTime <= jumpMaxTime)
            {
                if(lastTouchY - initTouchY >= Screen.height * jumpMinHeightRatio)
                {
                    lastSpeed = (lastTouchY - initTouchY) / Screen.height /(lastTouchTime - initTouchTime);
                    initTouchTime = lastTouchTime = initTouchY = lastTouchY = 0f;
                    return true;
                }
            }
            return false;
        }
        public float GetJumpSpeed()
        {
            return lastSpeed;
        }
    }
}