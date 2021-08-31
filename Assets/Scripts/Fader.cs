using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Fader : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 0.3f;
        [SerializeField] private bool hasAlphaFade = true;

        private Vector3 defaultPosition;
        private Vector3 defaultScale;

        [Header("In")]
        [SerializeField] private float inScaleDelta = 1f;
        [SerializeField] private Vector3 inPositionDelta;

        [Header("Out")]
        [SerializeField] private float outScaleDelta = 1f;
        [SerializeField] private Vector3 outPositionDelta;

        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();

            defaultPosition = transform.localPosition;
            defaultScale = transform.localScale;
        }

        public void Fade(Vector3 startScale, Vector3 endScale, float startAlpha, float endAlpha, Vector3 startPosition, Vector3 endPosition, float time, Action onComplete = null) =>
            FadeInternal(startScale, endScale, startAlpha, endAlpha, startPosition, endPosition, time, onComplete);

        public void FadeIn()
        {
            gameObject.SetActive(true);
            _canvasGroup.interactable = false;

            var startScale = defaultScale * inScaleDelta;
            var endScale = defaultScale;

            var startAlpha = hasAlphaFade ? 0f : 1f;
            var endAlpha = 1f;

            var startPosition = defaultPosition - inPositionDelta;
            var endPosition = defaultPosition;

            FadeInternal(startScale, endScale, startAlpha, endAlpha, startPosition, endPosition, fadeTime, () => {
                _canvasGroup.interactable = true;
            });
        }

        public void FadeOut()
        {
            var startScale = defaultScale;
            var endScale = defaultScale * outScaleDelta;

            var startAlpha = 1f;
            var endAlpha = hasAlphaFade ? 0f : 1f;

            var startPosition = defaultPosition;
            var endPosition = defaultPosition - inPositionDelta;

            _canvasGroup.interactable = false;

            FadeInternal(startScale, endScale, startAlpha, endAlpha, startPosition, endPosition, fadeTime, () => {
                gameObject.SetActive(false);
            });
        }

        private void FadeInternal(Vector3 startScale, Vector3 endScale, float startAlpha, float endAlpha, Vector3 startPosition, Vector3 endPosition, float time, Action onComplete = null)
        {
            if (_rectTransform == null)
            {
                _rectTransform = GetComponent<RectTransform>();
            }
            
            _rectTransform.localScale = startScale;

            if (onComplete == null)
            {
                LeanTween.scale(_rectTransform, endScale, time).setEaseInOutSine();
            }
            else
            {
                LeanTween.scale(_rectTransform, endScale, time).setEaseInOutSine().setOnComplete(onComplete);
            }

            transform.localPosition = startPosition;
            LeanTween.moveLocal(_rectTransform.gameObject, endPosition, time).setEaseInOutSine().setOnComplete(onComplete);

            if (_canvasGroup == null)
                _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.alpha = startAlpha;
            _canvasGroup.LeanAlpha(endAlpha, time).setEaseInOutSine();
        }
    }
}