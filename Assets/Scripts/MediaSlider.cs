using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaSlider : MonoBehaviour
{
    public Transform contentContainer;
    public GameObject slidePrefab;
    public SnapScroll snapScroll;

    [System.Serializable]
    public class SlidesList
    {
        [SerializeField]
        public List<Texture2D> textures;
    }

    [SerializeField]
    public List<SlidesList> slidesInSlides = new List<SlidesList>();

    public void Init(int slideId)
    {
        Clear();

        SpawnSlides(slidesInSlides[slideId - 1]);

        snapScroll.ScrollTo(0);
    }

    private void SpawnSlides(SlidesList texturesToSpawn)
    {
        foreach (Texture2D texture in texturesToSpawn.textures)
            Instantiate(slidePrefab, contentContainer).GetComponent<RawImage>().texture = texture;
    }

    private void Clear()
    {
        foreach (Transform child in contentContainer)
            Destroy(child.gameObject);
    }
}
