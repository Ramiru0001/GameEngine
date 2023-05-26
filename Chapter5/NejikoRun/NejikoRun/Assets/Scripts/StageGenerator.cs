using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 30;
    int currentChipIndex;

    public Transform charater;
    public GameObject[] stageChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }
    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�̃`�b�v�̃C���f�b�N�X���v�Z
        int charaPositionIndex = (int)(character.position.z / StageChipSize);
        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V�������s��
        if (charaPositionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex * preInstantiate);
        }
    }
    //�w���Index�܂ł̃X�e�[�W�`�b�v�𐶐����ĊǗ����ɒu��
    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;
        //�w��̃X�e�[�`�b�v�܂ł��쐬
        for(int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            //���������X�e�[�W�`�b�v���Ǘ����X�g�ɒǉ�
            generatedStageList.Add(stageObject);
        }
        //�X�e�[�W�ێ�������ɂȂ�܂ŌÂ��X�e�[�W���폜
        while(generatedStageList.Count>preInstantiate+2) Destroy01destStage();
        currentChipIndex = toChipIndex;
    }
    //�w��̃C���f�b�N�X�ʒu��Stage�I�u�W�F�N�g�������_���ɐ���
    GameObject GenerateStage(int chipIndex)
    {
        int nextstageChip = Random.Range(0, stageChips.Length);
        GameObject stageObject = (GameObject)Instantiate(
            stageChips[nextStageChip], 
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
            );
        return stageObject;
    }
    //��ԌÂ��X�e�[�W���폜
    void Destroy01destStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}