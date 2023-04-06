using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static DataManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // UserData Json 파일 첫 생성
    void First()
    {
        UserData userData = new UserData();
        userData.coins = 0;
        userData.levelCleared = new int[30] {0,0,0,0,0,0,0,0,0,0,
                                            0,0,0,0,0,0,0,0,0,0,
                                            0,0,0,0,0,0,0,0,0,0};
        
        string json = JsonUtility.ToJson(userData);

        string fileName = "PlayerData";
        string path = Application.dataPath + "/" + fileName +".Json";

        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    // 저장된 UserData 로드
    public UserData myUser=null;
    void Load()
    {
        string fileName = "PlayerData";
        string path = Application.dataPath + "/" + fileName + ".Json";

        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);

        myUser = JsonUtility.FromJson<UserData>(json);
    }

    public void Resave(UserData newdata)
    {

    }
    
}
