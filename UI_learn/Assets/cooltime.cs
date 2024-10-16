using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class cooltime : MonoBehaviour
{
    public GameObject hideSkillButton;
    public GameObject textpros;
    public TextMeshProUGUI hideSkillTimeTexts;
    public Image hideSkillimage;
    private bool isHideskill = false;
    private bool flag=false;//스킬 사용시 true로 전환
    public float skilltime;// public으로 쿨타임 저장
    private float getSkilltime = 0;
     
    void Start()
    {
        hideSkillTimeTexts=textpros.GetComponent<TextMeshProUGUI>();//시작이 되면 hideSkillTimeTexts 생성
        hideSkillButton.SetActive(false);//hideSkillButton버튼 비활성
        
    }

    
    void Update()
    {
        HideSkillchk();
    }
    public void HideSkillSetting()
    {
        if (! flag)//스킬 사용안했다. 라는 식으로 설정
        {//flag=false면 실행 가능

            getSkilltime = skilltime;//스킬 쿨타임 받아옴
            isHideskill = true;//활성화 되면 실행
            hideSkillButton.SetActive(true);//활성화
           flag=true;//실행 되서 스킬다시 누르지 못하게 true 로 전환
        }
       
    }
    private void HideSkillchk()
    {
        if(isHideskill)//true묜
        {
            StartCoroutine(skilltimechk());//코루틴 실행
        }
        
    }
    IEnumerator skilltimechk()
    {
        yield return null;
        if(getSkilltime>0)
        { 
            getSkilltime-= Time.deltaTime;//시간이 0초보다 크면 1초 씩 감소
        }
        if (getSkilltime < 0)//0 초면
        {
            getSkilltime =0;//스킬 쿨 0으로 초기화 하고
            isHideskill = false;//코루틴 비활성화
            hideSkillButton.SetActive(false);//버튼 비활성
            flag = false;//스킬 쿨 끝나면 다시 사용가능하게 설정
        }
        hideSkillTimeTexts.text=getSkilltime.ToString("00");//->수정해 보기
        float time = getSkilltime / skilltime;
        hideSkillimage.fillAmount = time;//그림자 값 초기화
    }
}
