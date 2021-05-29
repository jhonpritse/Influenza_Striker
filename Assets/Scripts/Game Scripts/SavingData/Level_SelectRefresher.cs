using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_SelectRefresher : MonoBehaviour
{
        private Transform _levelButton;
        private Level_Manager _levelManager;
        private Transform _levelPanel;
   
   
       private void OnEnable()
       {
           
           _levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
           _levelPanel =  GameObject.Find("Level_Panel").transform;
           
           for (int i = 0; i < _levelManager.isLevelUnlocked.Length; i++)
           {
               _levelPanel.GetChild(i).GetComponent<Button>().interactable =_levelManager.isLevelUnlocked[i];
               if (_levelPanel.GetChild(i).GetComponent<Button>().interactable)
               {
                   _levelPanel.GetChild(i).Find("Text (TMP)").transform.GetComponent<TextMeshProUGUI>().text = "Level " + (i+1);
               }else if (!_levelPanel.GetChild(i).GetComponent<Button>().interactable)
               {
                   _levelPanel.GetChild(i).Find("Text (TMP)").transform.GetComponent<TextMeshProUGUI>().text = "Locked";
               }
           }
           
       }
   
        //
        // void SceneLoad(int i)
        // {
        //     SceneManager.LoadScene(i);
        // }
        // public void SceneLoad1()
        // {
        //     SceneLoad(1);
        // }
        // public void SceneLoad2()
        // {
        //     SceneLoad(2);
        // }
        // public void SceneLoad3()
        // {
        //     SceneLoad(3);
        // }
        // public void SceneLoad4()
        // {
        //     SceneLoad(4);
        // }
        // public void SceneLoad5()
        // {
        //     SceneLoad(5);
        // }
        // public void SceneLoad6()
        // {
        //     SceneLoad(6);
        // }
        // public void SceneLoad7()
        // {
        //     SceneLoad(7);
        // }
        // public void SceneLoad8()
        // {
        //     SceneLoad(8);
        // }
        // public void SceneLoad9()
        // {
        //     SceneLoad(9);
        // }
        // public void SceneLoad10()
        // {
        //     SceneLoad(10);
        // }
}
