using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    [System.Serializable]
    public class AlmanacData
    {
        //TODO set variable to be savable
        public bool[] isCardState ;    
      
        
        public AlmanacData(Almanac_Manager almanacManager)
        {
            isCardState = new bool[almanacManager.isCardUnlocked.Length];
            
            for (int i = 0; i < almanacManager.isCardUnlocked.Length; i++)
            {
                // Debug.Log("Update in almanac Data " + i + " " +    isCardState[i]  + " from almatac > "+ almanac.isCardUnlocked[i]);
                isCardState[i] = almanacManager.isCardUnlocked[i];
            }
            
        }
    }
