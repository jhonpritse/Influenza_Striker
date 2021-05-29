using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo_Manager : MonoBehaviour
{

    private Transform _infoArea;
    private GameObject _previewsButton;
    private GameObject _nextButton;
    void Start()
    {
        _infoArea = GameObject.Find("Info Area").transform;
        _previewsButton = GameObject.Find("Previews_Button");
        _nextButton = GameObject.Find("Next_Button");
      
    }
    
    void Update()
    {
        _previewsButton.SetActive(!_infoArea.GetChild(0).gameObject.activeSelf);
        _nextButton.SetActive(!_infoArea.GetChild(_infoArea.childCount - 1).gameObject.activeSelf);
    }

    private int _indexNext;
    private int _next;
    public void NextDownPress_Button()
    {
        foreach (Transform child in _infoArea)
        {
            _next++;
            if (child.gameObject.activeSelf)
            {
                _indexNext = _next;
            }
        }
        _next = 0;
    }
    public void NextUpPress_Button()
    {
        _infoArea.GetChild(_indexNext-1).gameObject.SetActive(false);
       _infoArea.GetChild(_indexNext).gameObject.SetActive(true);
    }
   
    private int _indexP;
    private int _nextP;
    public void PreviewsDownPress_Button()
    {
        foreach (Transform child in _infoArea)
        {
            _nextP++;
            if (child.gameObject.activeSelf)
            {
                _indexP = _nextP;
            }
        }
        _nextP = 0;
    }
    public void PreviewsUpPress_Button()
    {
        _infoArea.GetChild(_indexP-1).gameObject.SetActive(false);
        _infoArea.GetChild(_indexP-2).gameObject.SetActive(true);
    }
    
    public void CloseInfo_Button()
    {
        gameObject.SetActive(false);
    }
}
