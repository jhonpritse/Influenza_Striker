using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Almanac_CardRefresher : MonoBehaviour
{
    private Transform _virusCardInfo;
    private Almanac_Manager _almanacManager;
    private Transform _almanacCardHolder;


    private void OnEnable()
    {
        _virusCardInfo = GameObject.Find("VirusCardInfo").transform;
        _almanacManager = GameObject.Find("Almanac_Manager").GetComponent<Almanac_Manager>();
        _almanacCardHolder =  GameObject.Find("AlmanacCard_Holder").transform;
        
        for (int i = 0; i < _almanacManager.isCardUnlocked.Length; i++)
        {
            _almanacCardHolder.GetChild(i).GetComponent<Button>().interactable =_almanacManager.isCardUnlocked[i];
            if (_almanacCardHolder.GetChild(i).GetComponent<Button>().interactable)
            {
                _almanacCardHolder.GetChild(i).Find("Text (TMP)").gameObject.SetActive(false);
            }
        }
        
    }


     void Card(int i)
    {
        _virusCardInfo.GetChild(i-1).gameObject.SetActive(true);
        
    }
     public void Card1()
     {
         Card(1);
     }
     public void Card2()
     {
         Card(2);
     }
     public void Card3()
     {
         Card(3);
     }
     public void Card4()
     {
         Card(4);
     }
     public void Card5()
     {
         Card(5);
     }
     public void Card6()
     {
         Card(6);
     }
     public void Card7()
     {
         Card(7);
     }
     public void Card8()
     {
         Card(8);
     }
     public void Card9()
     {
         Card(9);
     }
     public void Card10()
     {
         Card(10);
     }
}
