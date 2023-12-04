using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Demo1
{
    public class UIManager : MonoBehaviour
    {
        public float fadeTime;
        public CanvasGroup canvasGroup;
        public RectTransform rectTransform;
        public List<GameObject> items = new List<GameObject>();
        public AudioClip popupSFX;

        private AudioSource audioSource;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        public void PanelfadeIn(){
            canvasGroup.alpha = 0f;
            rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
            rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
            canvasGroup.DOFade(1, fadeTime);
            StartCoroutine(ItemsAnimation());
        }

        public void PanelfadeOut(){
            canvasGroup.alpha = 1f;
            rectTransform.transform.localPosition = new Vector3(0f, 0, 0f);
            rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
            canvasGroup.DOFade(0, fadeTime);
        }

        IEnumerator ItemsAnimation(){
            foreach(var item in items){
                item.transform.localScale = Vector3.zero;
            }
            foreach(var item in items){
                audioSource.PlayOneShot(popupSFX);
                item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
