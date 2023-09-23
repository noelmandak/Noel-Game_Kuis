
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private LevelPackKuis _soalSoal = null;

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
        if (!_playerProgress.MuatProgres())
        {
            _playerProgress.SimpanProgress();
        }

        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;
        _currentLevel++;

        _tempatTextLevel.text = $"Level {_currentLevel}";

        if (_indexSoal >= _soalSoal.BanyakLevel)
        {
            _indexSoal = 0;
        }

        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        _pertanyaan.SetPertanyaan(soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }

    public void ResetLevel()
    {
        _currentLevel = 0;
        _indexSoal = -1;
        NextLevel();
    }
}
