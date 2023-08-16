using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MusicMgr : SingletonAutoMono<MusicMgr>
{
    //音乐大小
    public float musicValue = 1;
    public float soundValue = 1;
    //private float voiceValue = 1;

    //音效列表


    public AudioSource MusicPlayer;
    public AudioSource SoundPlayer;

    private AudioClip bgm = null;

    public Dictionary<string, AudioClip> soundDic = new Dictionary<string, AudioClip>();
    private void Start()
    {
        gameObject.AddComponent<AudioSource>();
        MusicPlayer = GetComponent<AudioSource>();
        MusicPlayer.loop = true;
        if (SoundPlayer == null)
        {
            GameObject sound = new GameObject();
            sound.name = "Sound";
            sound.AddComponent<AudioSource>();
            SoundPlayer = sound.GetComponent<AudioSource>();
        }
    }

    private void LoadMusic(string key)
    {
        AsyncOperationHandle<AudioClip> handle = Addressables.LoadAssetAsync<AudioClip>(key);
        handle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                bgm = handle.Result;
                PlayMusic(key);
            }
        };
    }


    private void LoadSound(string key)
    {
        if (!soundDic.ContainsKey(key))
        {
            AsyncOperationHandle<AudioClip> handle = Addressables.LoadAssetAsync<AudioClip>(key);
            handle.Completed += (handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    soundDic.Add(key, handle.Result);
                    PlaySound(key);
                }
            };
        }
        else
        {
            PlaySound(key);
        }

    }

    public void PlayMusic(string key)
    {
        if (bgm != null)
        {
            MusicPlayer.clip = bgm;
            MusicPlayer.volume = musicValue;
            MusicPlayer.Play();

        }
        else
        {
            LoadMusic(key);
        }
    }

    public void PlaySound(string key)
    {
        if (soundDic.ContainsKey(key))
        {
            SoundPlayer.clip = soundDic[key];
            SoundPlayer.volume = soundValue;
            SoundPlayer.Play();
        }
        else
        {
            LoadSound(key);
        }
    }

    public void ChangeMusicValue(float value)
    {
        musicValue = value;
        MusicPlayer.volume = musicValue;
    }
    public void ChangeSoundValue(float value)
    {
        soundValue = value;
        SoundPlayer.volume = soundValue;
    }




    /*private void Update()
    {
        for( int i = soundList.Count - 1; i >=0; --i )
        {
            if(!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }*/
    //public void PlayBkMusic(string name)
    //{
    /*if(bkMusic == null)
    {
        GameObject obj = new GameObject();
        obj.name = "BkMusic";
        bkMusic = obj.AddComponent<AudioSource>();
    }*/
    /*Bgm.LoadAssetAsync().Completed += (handle) =>
    {
        //如何在unity使用Addressable加载音乐并播放
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {

            audioSource.clip = handle.Result;
            audioSource.Play();
            print("bofang");
        }
    };*/
    //异步加载背景音乐 加载完成后 播放

    /*ResMgr.GetInstance().LoadAsync<AudioClip>("Music/BK/" + name, (clip) =>
    {
        bkMusic.clip = clip;
        bkMusic.loop = true;
        bkMusic.volume = bkValue;
        bkMusic.Play();
    });*/

    //}

    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    /* public void PauseBKMusic()
     {
         if (bkMusic == null)
             return;
         bkMusic.Pause();
     }*/

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    /*public void StopBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }*/

    /// <summary>
    /// 改变背景音乐 音量大小
    /// </summary>
    /// <param name="v"></param>
    /*public void ChangeBKValue(float v)
    {
        bkValue = v;
        if (bkMusic == null)
            return;
        bkMusic.volume = bkValue;
    }*/

    /// <summary>
    /// 播放音效
    /// </summary>
    /*public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callBack = null)
    {
        if(soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        //当音效资源异步加载结束后 再添加一个音效
        *//*ResMgr.GetInstance().LoadAsync<AudioClip>("Music/Sound/" + name, (clip) =>
        {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = isLoop;
            source.volume = soundValue;
            source.Play();
            soundList.Add(source);
            if(callBack != null)
                callBack(source);
        });*//*
    }*/

    /// <summary>
    /// 改变音效声音大小
    /// </summary>
    /// <param name="value"></param>
    /*public void ChangeSoundValue( float value )
    {
        soundValue = value;
        for (int i = 0; i < soundList.Count; ++i)
            soundList[i].volume = value;
    }

    /// <summary>
    /// 停止音效
    /// </summary>
    public void StopSound(AudioSource source)
    {
        if( soundList.Contains(source) )
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }*/

}