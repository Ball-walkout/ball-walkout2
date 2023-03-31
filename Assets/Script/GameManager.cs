using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

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

    private TouchMove ball;
    private PathFollower pf;
    private void Start() {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<TouchMove>();
        pf = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
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

    // 타임어택
    public bool timerOn = true;
    public float time=0, min, sec;
    private void Update()
    {
        if(timerOn)
        {
            time += Time.deltaTime;
            sec = (int)time % 60;
            min = (int)time / 60 % 60;

            // 2분 초과 시 게임오버
            if(min>=2)
            {
                GameFail();
            }
        }
        if(ui == null)
        {
            ui = FindObjectOfType<UIManager>();
        }
    }

    public void TurnOnTime()
    {
        Time.timeScale=1;
    }

    // 부스터 닿을 시 씬 느려지게
    public Vector3 preVelocity;
    public IEnumerator SlowMotion()
    {
        if(ball == null)
            ball = GameObject.FindGameObjectWithTag("Player").GetComponent<TouchMove>();
        preVelocity = ball.rig.velocity;
        Time.timeScale = 0.5f;
        // 배경 흐리게, 공 가속 멈추기, 적 속도 멈추기
        ball.rig.velocity = Vector3.zero*100;
        ball.Rallentare();
        ball.rig.velocity = Vector3.zero;
        pf.speed = 0;

        // 3초 후 원상복귀
        int num=0;
        while (num < 3)
        {
            num++;
            yield return new WaitForSeconds(1f);
        }
        Time.timeScale = 1f;
    }

    public void GameFail()
    {
        timerOn = false;
        ui.GameOver();
    }

    // 골인 후 점수 계산
    public int star=0;
    public void StageClear()
    {
        if(min * 60 + sec <= 40)
            star = 3;
        else if(min * 60 + sec <= 50)
            star = 2;
        else
            star = 1;
    }

    
}
