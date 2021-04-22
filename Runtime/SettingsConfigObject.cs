using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Settings Config", menuName = "Overlook/Settings Config Object")]
public class SettingsConfigObject : ScriptableObject
{
    public List<Setting> settings = new List<Setting>();
    
    [Serializable]
    public class Setting
    {
        [Header("Name")]
        public string settingName;
        
        [Header("Setting Info")]
        public string description;
        public string type;
        public string[] parameters;
        
        [Header("GameObject Info")]
        public string gameObjectName;
        public string methodName;

        private GameObject gameObject;
        public GameObject GetGameObject()
        {
            gameObject = GameObject.Find(gameObjectName);
        
            return gameObject;
        }
    }
}