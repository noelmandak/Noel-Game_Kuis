
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct DataSoal
    {
        public string pertanyaan;
        public Sprite petunjukJawaban;
        
        public string[] pilihanJawaban;
        public bool[] adalahBenar;
    }
    
    [SerializeField]
    private DataSoal[] _soalSoal = new DataSoal[0];

    [SerializeField]
    private TextMeshProUGUI _tempatTextLevel = null;

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];

    private int _currentLevel = 0;
    private int _indexSoal = -1;

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;
        _currentLevel++;

        _tempatTextLevel.text = $"Level {_currentLevel}";

        if (_indexSoal >= _soalSoal.Length)
        {
            _indexSoal = 0;
        }

        DataSoal soal = _soalSoal[_indexSoal];

        _pertanyaan.SetPertanyaan(soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            poin.SetJawaban(soal.pilihanJawaban[i], soal.adalahBenar[i]);
        }
    }

    public void ResetLevel()
    {
        _currentLevel = 0;
        _indexSoal = -1;
        NextLevel();
    }
}
