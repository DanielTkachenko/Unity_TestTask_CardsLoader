using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CardView : MonoBehaviour
{
    public SpriteRenderer IconSpriteRenderer => iconSpriteRenderer;
    public Transform FrontSide => frontSide;
    public Transform BackSide => backSide;
    public bool IsOpened => _isOpened;
    
    [SerializeField] private SpriteRenderer iconSpriteRenderer;
    [SerializeField] private Transform frontSide;
    [SerializeField] private Transform backSide;

    private bool _isOpened;

    public void SetFrontSideActive(bool isFrontSideActive)
    {
        frontSide.gameObject.SetActive(isFrontSideActive);
        backSide.gameObject.SetActive(!isFrontSideActive);
        _isOpened = isFrontSideActive;
    }

    public class Pool : MemoryPool<float, Vector3, CardView>
    {
        protected override void Reinitialize(float p1, Vector3 p2, CardView item)
        {
            item.transform.localScale = new Vector3(p1, p1, p1);
            item.transform.position = p2;
            item.SetFrontSideActive(false);
        }
    }
}
