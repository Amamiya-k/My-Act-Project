using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;
using System.Xml;
using UnityEngine.UIElements;

public class UIMgr : SingletonAutoMono<UIMgr>
{

    public Transform canvas;
    public Transform healthBarCanvas;
    public Transform eventSystem;
    public Transform BeginPanel;
    public GameObject sceneFade;
    public Dictionary<string, GameObject> panelList = new Dictionary<string, GameObject>();
    public Dictionary<int, GameObject> healthBarList = new Dictionary<int, GameObject>();
    public List<Transform> UItransforms = new List<Transform>();

    public int currentLayer = 0;


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        /*Addressables.LoadAssetAsync<GameObject>("HealthBarCanvas").Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject obj = Instantiate(handle.Result);
                obj.name = "HealthBarCanvas";
                DontDestroyOnLoad(obj);
                healthBarCanvas = obj.transform;
            }
        };*/
        Addressables.LoadAssetAsync<GameObject>("Canvas").Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject obj = Instantiate(handle.Result);
                obj.name = "Canvas";
                
                DontDestroyOnLoad(obj);
                canvas = obj.transform;


                for(int i = 0; i < 10; i++)
                {
                    UItransforms.Add(canvas.GetChild(i));
                }

            }
        };

        Addressables.LoadAssetAsync<GameObject>("EventSystem").Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject obj = Instantiate(handle.Result);
                obj.name = "EventSystem";
                DontDestroyOnLoad(obj);
                eventSystem = obj.transform;
            }
        };


    }

    public void Start()
    {
    }


    public void LoadPanel(string name)
    {
        if(!panelList.ContainsKey(name))
        {
            Addressables.LoadAssetAsync<GameObject>(name).Completed += (handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject obj = Instantiate(handle.Result);

                    obj.name = name;
                    
                    panelList.Add(name, obj);

                    obj.transform.SetParent(UItransforms[currentLayer], false);
                    
                    currentLayer++;

                }
            };
        }
        else
        {
            panelList[name].gameObject.SetActive(true);
            panelList[name].transform.SetParent(UItransforms[currentLayer], false);
            currentLayer++;

        }
    }

    public GameObject GetPanel(string name)
    {
        if (panelList.ContainsKey(name))
        {
            //print(panelList[name].name); 
            return panelList[name].gameObject;
        }
        else return null;
    }


    public void ClosePanel(string name)
    {
        if (panelList.ContainsKey(name) ) //&& name != "SceneFade"
        {
            panelList[name].gameObject.SetActive(false);
            currentLayer--;
        }
        else return;
    }

    public void CloseFade(string name)
    {
        if (panelList.ContainsKey(name))
        {
            panelList[name].gameObject.SetActive(false);
        }
        else return;
    }

    public void CloseAllPanel()
    {
        foreach (KeyValuePair<string, GameObject> item in panelList)
        {
            ClosePanel(item.Key);
        }

    }


    public void Fade()
    {
        if(sceneFade == null)
        {
            Addressables.LoadAssetAsync<GameObject>("SceneFade").Completed += (handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject obj = Instantiate(handle.Result);
                    obj.name = "SceneFade";
                    obj.transform.SetParent(canvas, false);
                    sceneFade = obj;
                }
            };
        }
        else
        {
            sceneFade.gameObject.SetActive(true);
        }
    }
}


