using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public SettingsConfigObject settingsConfigObject;
    private Dictionary<string, SettingsConfig> settingsConfigDictionary = new Dictionary<string, SettingsConfig>();

    public RemoteConfigObject remoteConfigObject;
    private Dictionary<string, RemoteConfig> remotesConfigDictionary = new Dictionary<string, RemoteConfig>();
    
    //Import Overlook JS functions from a JSLib file. 
    [DllImport("__Internal")]
    private static extern void GameDidLoad(string gameData);
    
    //On Start(), create a JSON from a SettingsJson class instance with all the
    //info needed for Overlook-level settings UI, as well as a JSON from a
    //RemotesJson class instance with all the info needed for Overlook remotes. 
    //**NOTE: This needs to happen inside of the MonoBehavior-derived class so
    //we can take advantage of the Start() method. 
    private void Start()
    {
        NewSettingsConfigDictionary(settingsConfigObject);
        NewRemotesConfigDictionary(remoteConfigObject);

        var settings = JsonUtility.ToJson(new SettingsJson(settingsConfigDictionary));
        var remotes = JsonUtility.ToJson(new RemotesJson(remotesConfigDictionary));

        var gameData = JsonUtility.ToJson(new GameDataJson(settings, remotes));
        
        Debug.Log(gameData);
        GameDidLoad(gameData);
    }

    [Serializable]
    public class GameDataJson
    {
        public string settings;
        public string remotes;

        public GameDataJson(string _settings, string _remotes)
        {
            settings = _settings;
            remotes = _remotes;
        }
    }
/*
    ____  _      __  _                        _          
   / __ \(_)____/ /_(_)___  ____  ____ ______(_)__  _____
  / / / / / ___/ __/ / __ \/ __ \/ __ `/ ___/ / _ \/ ___/
 / /_/ / / /__/ /_/ / /_/ / / / / /_/ / /  / /  __(__  ) 
/_____/_/\___/\__/_/\____/_/ /_/\__,_/_/  /_/\___/____/  
                                                         
*/

    //NewSettingsConfigDictionary takes in a SettingsConfigObject and creates a non-serializable
    //Dictionary<> of key/value pairs that goes "Setting Name = Setting, Setting Name = Setting, etc...".

    void NewSettingsConfigDictionary(SettingsConfigObject _settingsConfigObject)
    {
        foreach (var setting in _settingsConfigObject.settings)
        {
            settingsConfigDictionary.Add(
                setting.settingName,
                new SettingsConfig(
                    setting.settingName,
                    setting.description,
                    setting.type,
                    setting.parameters
                )
                );
        }
    }
    
    //NewRemotesConfigDictionary takes in a RemoteConfigObject and creates a non-serializable 
    //Dictionary<> of key/value pairs that goes "Remote Name = RemoteConfig, Remote Name = RemoteConfig, etc...".

    void NewRemotesConfigDictionary(RemoteConfigObject _remoteConfigObject)
    {
        foreach (var remote in _remoteConfigObject.remotes)
        {
            remotesConfigDictionary.Add(
                remote.remoteName,
                new RemoteConfig(
                    remote.remoteName,
                    JsonUtility.ToJson(new InstrumentConfig(remote.instruments))
                    )
                );
        }
    }
}
/*
       __                     
      / /________  ____  _____
 __  / / ___/ __ \/ __ \/ ___/
/ /_/ (__  ) /_/ / / / (__  ) 
\____/____/\____/_/ /_/____/  

*/                      

//SettingsJson is a class whose constructor function takes in a non-serializable Dictionary,.
//of Setting Name = SettingConfig key/value pairs and turns it into a serializable List<> that
//goes "Setting Name, Setting Config, Setting Name, Setting Config, etc...".
[Serializable]
public class SettingsJson
{
    public List<string> settings = new List<string>();
    
    public SettingsJson(Dictionary<string, SettingsConfig> _settingsConfigDictionary)
    {
        foreach (var entry in _settingsConfigDictionary)
        {
            settings.Add(entry.Key);
            settings.Add(JsonUtility.ToJson(entry.Value));
        }
    }
}

//RemotesJson is a class whose constructor function takes in a non-serializable Dictionary<>
//of Remote Name = RemoteConfig key/value pairs and turns it into a serializable List<> that
//goes "Remote Name, Remote Config, Remote Name, Remote Config, etc...".

[Serializable]
public class RemotesJson
{
    public List<string> remotes = new List<string>();

    public RemotesJson(Dictionary<string, RemoteConfig> _remoteConfigDictionary)
    {
        foreach (var entry in _remoteConfigDictionary)
        {
            remotes.Add(entry.Key);
            remotes.Add(JsonUtility.ToJson(entry.Value));
        }
    }
}

/*
   ______            _____           
  / ____/___  ____  / __(_)___ ______
 / /   / __ \/ __ \/ /_/ / __ `/ ___/
/ /___/ /_/ / / / / __/ / /_/ (__  ) 
\____/\____/_/ /_/_/ /_/\__, /____/  
                       /____/        
*/


[Serializable]
public class SettingsConfig
{
    public string name;
    public string description;
    public string type;
    public string[] parameters;

    public SettingsConfig(string _name, string _description, string _type, string[] _parameters)
    {
        name = _name;
        description = _description;
        type = _type;
        parameters = _parameters;
    }
}

[Serializable]
public class RemoteConfig
{
    public string remoteName;
    public string instruments;
    

    public RemoteConfig(string _remoteName, string _instruments)
    {
        remoteName = _remoteName;
        instruments = _instruments;
    }
}

public class InstrumentConfig
{
    public List<string> instruments = new List<string>();

    public InstrumentConfig(List<RemoteConfigObject.Remote.Instrument> instrumentsFromObject)
    {
        foreach (var instrument in instrumentsFromObject)
        {
            instruments.Add(JsonUtility.ToJson(instrument));
        }
    }
}



