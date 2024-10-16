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
    private bool flag=false;//��ų ���� true�� ��ȯ
    public float skilltime;// public���� ��Ÿ�� ����
    private float getSkilltime = 0;
     
    void Start()
    {
        hideSkillTimeTexts=textpros.GetComponent<TextMeshProUGUI>();//������ �Ǹ� hideSkillTimeTexts ����
        hideSkillButton.SetActive(false);//hideSkillButton��ư ��Ȱ��
        
    }

    
    void Update()
    {
        HideSkillchk();
    }
    public void HideSkillSetting()
    {
        if (! flag)//��ų �����ߴ�. ��� ������ ����
        {//flag=false�� ���� ����

            getSkilltime = skilltime;//��ų ��Ÿ�� �޾ƿ�
            isHideskill = true;//Ȱ��ȭ �Ǹ� ����
            hideSkillButton.SetActive(true);//Ȱ��ȭ
           flag=true;//���� �Ǽ� ��ų�ٽ� ������ ���ϰ� true �� ��ȯ
        }
       
    }
    private void HideSkillchk()
    {
        if(isHideskill)//true��
        {
            StartCoroutine(skilltimechk());//�ڷ�ƾ ����
        }
        
    }
    IEnumerator skilltimechk()
    {
        yield return null;
        if(getSkilltime>0)
        { 
            getSkilltime-= Time.deltaTime;//�ð��� 0�ʺ��� ũ�� 1�� �� ����
        }
        if (getSkilltime < 0)//0 �ʸ�
        {
            getSkilltime =0;//��ų �� 0���� �ʱ�ȭ �ϰ�
            isHideskill = false;//�ڷ�ƾ ��Ȱ��ȭ
            hideSkillButton.SetActive(false);//��ư ��Ȱ��
            flag = false;//��ų �� ������ �ٽ� ��밡���ϰ� ����
        }
        hideSkillTimeTexts.text=getSkilltime.ToString("00");//->������ ����
        float time = getSkilltime / skilltime;
        hideSkillimage.fillAmount = time;//�׸��� �� �ʱ�ȭ
    }
}
