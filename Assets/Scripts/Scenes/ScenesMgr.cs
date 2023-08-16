using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class ScenesMgr : SingletonAutoMono<ScenesMgr>
{
    public void LoadScene(string name)
    {

        //UIMgr.GetInstance().LoadPanel("SceneFade", 2);
        
       /* Addressables.LoadSceneAsync("stage0").Completed += (handle) =>
        {

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                UIMgr.GetInstance().CloseAllPanel();
                //main.scene = SceneManager.GetActiveScene();
            }
            //

            //Addressables.Release(handle);
        };*/
        
        //UIMgr.GetInstance().LoadPanel("SceneFade");
        Addressables.LoadSceneAsync(name).Completed += (handle) =>
        {
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {

                UIMgr.GetInstance().CloseAllPanel();
                //print("load access");
                //main.scene = SceneManager.GetActiveScene();

            }
        };
    }


}
