using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Realms;
using UnityEngine.UI;

public class RealmController : MonoBehaviour
{
    private Realm _realm;
    public static CharacterModel _characterModel;
    public static RealmController Instance;


    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("RealmController started");
    }

    void OnEnable()
    {

        Debug.Log("enabled");


        _realm = Realm.GetInstance();
        _characterModel = _realm.Find<CharacterModel>("TestCharacter001");
        if (_characterModel == null)
        {
            _realm.Write(() => {
                _characterModel = _realm.Add(new CharacterModel("TestCharacter001", 0, 0));
            });
        }

        var _characterName = GameObject.Find("CharacterName").GetComponent<Text>();
        _characterName.text = "Character Name: " + _characterModel.gamerTag;


        Debug.Log(_characterModel.gamerTag);
    }
    void OnDisable()
    {
        _realm.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void collectToken() // performs an update on the Character Model's token count
    {

        Debug.Log("token count before:" + _characterModel.tokenCount);
        _realm.Write(() =>
        {
            _characterModel.tokenCount += 1;
        });

        var _tokenCount = GameObject.Find("TokensCollected").GetComponent<Text>();
        _tokenCount.text = "Tokens Collected: " + _characterModel.tokenCount;


        Debug.Log("token count after:" + _characterModel.tokenCount);

    }
    public void defeatEnemy() // performs an update on the Character Model's enemiesDefeated Count
    {
        Debug.Log("enemyDefeatedCount before:" + _characterModel.enemyDefeatedCount);
        _realm.Write(() =>
        {
            _characterModel.enemyDefeatedCount += 1;
        });

        var _enemyDefeatedCount = GameObject.Find("EnemiesDefeated").GetComponent<Text>();
        _enemyDefeatedCount.text = "Enemies Defeated: " + _characterModel.enemyDefeatedCount;


        Debug.Log("enemyDefeatedCount after:" + _characterModel.enemyDefeatedCount);
    }
    public void characterDefeated()
    {
        Debug.Log("character final score: \t enemyDefeatedCount:" + _characterModel.enemyDefeatedCount + _characterModel.enemyDefeatedCount + " \t tokenCount: " + _characterModel.tokenCount);
        _realm.Write(() =>
        {
            _characterModel.enemyDefeatedCount = 0;
            _characterModel.tokenCount = 0;
        });


        var _tokenCount = GameObject.Find("TokensCollected").GetComponent<Text>();
        _tokenCount.text = "Tokens Collected: " + _characterModel.tokenCount;

        var _enemyDefeatedCount = GameObject.Find("EnemiesDefeated").GetComponent<Text>();
        _enemyDefeatedCount.text = "Enemies Defeated: " + _characterModel.enemyDefeatedCount;
    }
}
