using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

// json 파일 읽고 쓰기 참고 링크
// https://learnandcreate.tistory.com/751
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

    private bool first=false;
    // UserData Json 파일 첫 생성
    void First()
    {
        UserData userData = new UserData();
        userData.coins = 100;
        userData.levelCleared = new int[20] {0,0,0,0,0,0,0,0,0,0,
                                            0,0,0,0,0,0,0,0,0,0};
        userData.ball_skin = 0;
        userData.skin_purchased = new bool[14] {true, false, false, false, false, false, false, false, false, false,
                                                false, false, false, false};
        
        string json = JsonUtility.ToJson(userData);

        fileName = "PlayerData";
        path = Application.persistentDataPath + "/" + fileName +".Json";

        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    string fileName;
    string path;
    // 저장된 UserData 로드 (Start씬)
    public UserData myUser=null;
    void Load()
    {
        fileName = "PlayerData";
        path = Application.persistentDataPath + "/" + fileName + ".Json";

        if (!File.Exists(path))
            First();
            
        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);

        myUser = JsonUtility.FromJson<UserData>(json);
    }

    // 스테이지 클리어 후 데이터 수정
    public void Resave(int stageNum, int star, int coin)
    {
        myUser.levelCleared[stageNum] = star;
        myUser.coins += coin;
        GameManager.Instance.InitialCoin();

        System.IO.File.Delete(path);
        string json = JsonUtility.ToJson(myUser);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    
    public int stageNum = -1;

    
    // 공 구매 후 데이터 수정
    public void UpdatePurchase(int select)
    {
        myUser.skin_purchased[select] = true;

        System.IO.File.Delete(path);
        string json = JsonUtility.ToJson(myUser);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    
    // 공 스킨 변경 후 데이터 수정
    public void UpdateBall(int select)
    {
        
        myUser.ball_skin = select;

        System.IO.File.Delete(path);
        string json = JsonUtility.ToJson(myUser);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}
