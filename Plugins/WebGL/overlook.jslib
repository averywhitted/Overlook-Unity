var overlookLib = {
    GameDidLoad : function(stringPointer){
        console.log("GAME HAS LOADED",this.remotesJSON);
        var jsonString = Pointer_stringify(stringPointer);
        ReactUnityWebGL.GameDidLoad(jsonString);
    },
};
mergeInto(LibraryManager.library, overlookLib);