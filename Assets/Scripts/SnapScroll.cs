using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScroll : MonoBehaviour
{
    public float animationSpeed = 10f;
    public float slideWidth = 720f;

    public bool isScrolling;
    public bool isAutoScrollingToTarget;

    [SerializeField] int currentSlide = 0;
    [SerializeField] Vector2 targetPosition;
    RectTransform rectTransform;

    public void SetIsScrolling (bool _isScrolling) {
        isScrolling = _isScrolling;
        isAutoScrollingToTarget = false;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ScrollToDelta(int direction) {
        int targetSlide = Mathf.Clamp(currentSlide + direction, 0, transform.childCount - 1);
        Debug.Log(targetSlide);
        ScrollTo(targetSlide);
    }

    public void ScrollTo(int slideIndex) {
        isAutoScrollingToTarget = true;
        currentSlide = slideIndex;

        targetPosition = new Vector2(-slideIndex * slideWidth, 0);
    }

    void FixedUpdate()
    {
        if (isScrolling) return;

        if (!isAutoScrollingToTarget) {
            float nearestLeft = Mathf.Abs(rectTransform.anchoredPosition.x % slideWidth);
            float nearestRight = Mathf.Abs(slideWidth - nearestLeft);

            float minDistance = Mathf.Min(nearestLeft, nearestRight);

            bool autoslideDirectionToLeft = minDistance == nearestLeft;

            targetPosition = new Vector2(rectTransform.anchoredPosition.x + minDistance * (autoslideDirectionToLeft ? 1f : -1f), 0);

            currentSlide = (int) -(targetPosition.x / slideWidth);
        }

        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * animationSpeed);
    }
}
