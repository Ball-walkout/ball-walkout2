using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글톤 구현 참고 링크
// https://m.blog.naver.com/os2dr/221536778783
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

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


    [SerializeField] private UIManager ui;
    // 피버 코인
    private int coin = 0;

    public int GetCoin()
    {
        return coin;
    }

    public void SetCoin(int _coin)
    {
        coin += _coin;
        ui.UpdateCoin();
    }

    // 점수
    private int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int _score)
    {
        score += _score;
        ui.UpdateScore();
    }

    [SerializeField] private Transform rails;
    // Start is called before the first frame update
    void Start()
    {
        // rails.GetComponentsInChildren<>
        // CreateCoins();
    }
 
    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CreateCoins()
    {
        
        return null;
    }
}
