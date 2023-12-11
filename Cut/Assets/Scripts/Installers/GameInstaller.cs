using Zenject;
using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using Assets.Scripts.GameModeFeature;

namespace Cut.Infrastracture
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Header("Scriptable objects")]
        [SerializeField] private CombosTemplatesSO _templates;
        [SerializeField] private ButtonsHolderSO _buttonsHolder;
        [SerializeField] private GameModeSO _unlimitedTimeMode;
        [SerializeField] private GameModeSO _firstTapMode;
        [SerializeField] private GameModeSO _instantMode;

        [Header("View")]
        [SerializeField] private ComboDisplay _comboDisplayer;
        [SerializeField] private PrepTimerDisplay _prepTimerDisplay;
        [SerializeField] private BrokenCombosDisplay _brokenCombosDisplay;
        [SerializeField] private FinishedCombosDisplay _finishedCombosDisplay;

        [Header("Monobehaviours")]
        [SerializeField] private GameplayMediatorToLogic _gameplayMediatorToLogic;
        [SerializeField] private GameplayMediatorToUI _gameplayMediatorToUI;
        [SerializeField] private TimerUpdater _timerUpdater;
        [SerializeField] private GameStarter _gameStarter;

        public override void InstallBindings()
        {
            Container.Bind<CombosTemplatesSO>()
                .FromInstance( _templates )
                .AsSingle();

            Container.Bind<IRandomTemplateService>()
                .To<RandomTemplateService>()
                .AsSingle();

            Container.Bind<IListDisplayer>()
                .To<ListConsoleDisplayer>()
                .AsSingle();

            Container.Bind<IComboGenerator>()
                .To<ComboGenerator>()
                .AsSingle();

            Container.Bind<IButtonSideQualifier>()
                .To<ButtonSideQualifier>()
                .AsSingle();

            Container.Bind<ButtonsHolderSO>()
                .FromInstance( _buttonsHolder )
                .AsSingle();

            Container.Bind<IListRandomService>()
                .To<ListRandomService>()
                .AsSingle();

            Container.Bind<IListUniqueService>()
                .To<ListUniqueService>()
                .AsSingle();

            Container.Bind<IComboHolder>()
                .To<ComboHolder>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IComboInspector>()
                .To<ComboInspector>()
                .AsSingle();

            Container.Bind<IComboSwitcher>()
                .To<ComboSwitcher>()
                .AsSingle();
            
            Container.Bind<IComboFinisher>()
                .To<ComboFinisherPrototype>()
                .AsSingle();

            Container.Bind<IComboDisplay>()
                .FromInstance(_comboDisplayer)
                .AsSingle();

            Container.Bind<SessionStatistics>()
                .To<SessionStatistics>()
                .AsSingle();

            Container.Bind<IComboBreaker>()
                .To<ComboBreakerPrototype>()
                .AsSingle();

            Container.Bind<Dictionary<GameMode, GameModeSO>>()
                .FromInstance(PackGameModesToDictionary())
                .AsSingle();

            Container.Bind<IFactory<IPrepTimer>>()
                .To<CustomPrepTimerFactory>()
                .AsSingle();

            Container.BindFactory<UnlimitedPrepTimer, UnlimitedPrepTimer.Factory>();
            Container.BindFactory<FirstTapPrepTimer, FirstTapPrepTimer.Factory>();
            Container.BindFactory<InstantPrepTimer, InstantPrepTimer.Factory>();

            Container.Bind<ITimerUpdater>()
                .FromInstance(_timerUpdater) 
                .AsSingle();
            
            Container.Bind<IPrepTimerDisplay>()
                .FromInstance(_prepTimerDisplay) 
                .AsSingle();

            Container.Bind<ITimerHolder>()
                .To<TimerHolder>()
                .AsSingle();

            Container.Bind<IGameplayMediatorToLogic>()
                .FromInstance(_gameplayMediatorToLogic)
                .AsSingle();

            Container.Bind<IGameplayMediatorToUI>()
                .FromInstance(_gameplayMediatorToUI)
                .AsSingle();

            Container.Bind<IBrokenCombosDisplay>()
                .FromInstance(_brokenCombosDisplay)
                .AsSingle();

            Container.Bind<IFinishedCombosDisplay>()
                .FromInstance(_finishedCombosDisplay)
                .AsSingle();

            Container.Bind<GameModeHolder>()
                .To<GameModeHolder>()
                .AsSingle();

            Container.Bind<GameStarter>()
                .FromInstance(_gameStarter)
                .AsSingle()
                .NonLazy();

            //Tests

            //Container.Bind<FirstTapPrepTimer>().To<FirstTapPrepTimer>().AsSingle().NonLazy();
            //Container.Bind<IComboGeneratorTest>().To<ComboGeneratorTest>().AsSingle().NonLazy();

        }

        private Dictionary<GameMode, GameModeSO> PackGameModesToDictionary()
        {
            Dictionary<GameMode, GameModeSO> gameModes = new Dictionary<GameMode, GameModeSO>
            {
                { GameMode.UnlimitedTime, _unlimitedTimeMode },
                { GameMode.FirstTap, _firstTapMode },
                { GameMode.Instant, _instantMode }
            };
            return gameModes;
        }
    }
}

