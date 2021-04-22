using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class GameDataFromOverlook : MonoBehaviour
{
    //public GameDataToOverlook gameDataToOverlook;
    [HideInInspector]
    public List<SettingsConfigObject> settingsConfigObjects;

    //Create references to all the GameObjects that have settings functions on them.
    private List<GameObject> allGameObjects;
    
    private void Start()
    {
        //settingsConfigObjects = gameDataToOverlook.allSettingsConfigObjects;
        allGameObjects = new List<GameObject>();
        
        //Set those object's values using the list of Settings Config Objects.
        for (int i = 0; i < settingsConfigObjects.Count; i++)
        {
            //allGameObjects.Add(settingsConfigObjects[i].GetGameObject());
        }
    }
    
    class SettingBreakdown
    {
        public string key;
        public string value;

        public SettingBreakdown(string _key, string _value)
        {
            key = _key;
            value = _value;
        }
    }

    class SettingsContainer
    {
        public static List<object> items;
    }
    
    public void ParseSettings(string settingsJson)
    {
        var settingsObject = JsonUtility.FromJson<SettingsContainer>("{\"items\":" + settingsJson + "}");
        
        foreach (SettingBreakdown setting in SettingsContainer.items)
        {
            CallMethodOnGameObject(setting.key, setting.value);
        }
    }
    
    //Add all methods to change game settings here.
    void CallMethodOnGameObject(string method, object parameter)
    {
        /*
        string _gameObject = "";
        string _method = "";
        foreach (var settingsConfigObject in settingsConfigObjects)
        {
            if (settingsConfigObject.settingName == method)
            {
                _gameObject = settingsConfigObject.gameObjectName;
                _method = settingsConfigObject.methodName;
            }
        }
        GameObject.Find(_gameObject).SendMessage(_method, parameter);
        */
    }
}


