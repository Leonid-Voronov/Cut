using Assets.Scripts.TagComponents;
using UnityEngine;
using Zenject;

public class GameMediator : MonoBehaviour
{
    private GameplayUI _gameplayUI;
    private MetagameUI _metagameUI;

    [Inject]
    public void Construct(GameplayUI gameplayUI, MetagameUI metagameUI)
    {
        _gameplayUI = gameplayUI;
        _metagameUI = metagameUI;
    }

    public void DisableAllUI()
    {
        _gameplayUI.gameObject.SetActive(false);
        _metagameUI.gameObject.SetActive(false);
    }

    public void SwitchToGameplayUI()
    {
        DisableAllUI();
        _gameplayUI.gameObject.SetActive(true);
    }

    public void SwitchToMetagameUI()
    {
        DisableAllUI();
        _metagameUI.gameObject.SetActive(true);
    }
}
