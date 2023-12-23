using Zenject;
using UnityEngine;
using System.Collections.Generic;
using GameModeFeature;
using Core;
using TagComponents;
using StatisticsFeature;
using TimerFeature;
using UI.GameplayUI;
using UI.MetagameUI;
using GameplayVisualsFeature;
using UI.MetagameUI.Windows;
using UI;
using ComboGenerationFeature;
using ComboSwitchingFeature;

namespace Infrastracture
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Header("Scriptable objects")]
        [SerializeField] private ButtonsHolderSO _buttonsHolder;
        [SerializeField] private GameConfigSO _gameConfig;
        [SerializeField] private VisualsPresetSO _gameplayVisuals;
        [SerializeField] private VisualsPresetSO _defaultGameplayVisuals;

        [Header("CombosTemplates")]
        [SerializeField] private CombosTemplatesSO _threeSymbolsCombosTemplates;
        [SerializeField] private CombosTemplatesSO _fiveSymbolsCombosTemplates;
        [SerializeField] private CombosTemplatesSO _sevenSymbolsCombosTemplates;
        [SerializeField] private CombosTemplatesSO _defaultCombosTemplates;

        [Header("Game modes")]
        [SerializeField] private GameModeSO _unlimitedTimeMode;
        [SerializeField] private GameModeSO _firstTapMode;
        [SerializeField] private GameModeSO _instantMode;
        [SerializeField] private GameModeSO _defaultGameMode;

        [Header("View")]
        [SerializeField] private ComboDisplay _comboDisplayer;
        [SerializeField] private PrepTimerDisplay _prepTimerDisplay;
        [SerializeField] private BrokenCombosDisplay _brokenCombosDisplay;
        [SerializeField] private FinishedCombosDisplay _finishedCombosDisplay;

        [Header("Objects")]
        [SerializeField] private GameplayUITag _gameplayUI;
        [SerializeField] private MetagameUITag _metagameUI;
        [SerializeField] private GameplayZone _gameplayZone;

        [Header("Monobehaviours")]

        [SerializeField] private TimerUpdater _timerUpdater;
        [SerializeField] private AppStarter _appStarter;
        [SerializeField] private EnvironmentScaleHolder _environmentScaleHolder;
        [SerializeField] private StartGameButton _startGameButton;

        [Header("Mediators")]
        [SerializeField] private GameplayMediatorToLogic _gameplayMediatorToLogic;
        [SerializeField] private GameplayMediatorToUI _gameplayMediatorToUI;
        [SerializeField] private MetagameMediatorToLogic _metagameMediatorToLogic;
        [SerializeField] private MetagameMediatorToUI _metagameMediatorToUI;
        [SerializeField] private GameMediator _gameMediator;

        [Header("Windows")]
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private MenuWindow _menuWindow;

        public override void InstallBindings()
        {
            Container.Bind<CombosTemplatesSO>()
                .FromInstance(_defaultCombosTemplates)
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
                .FromInstance(_buttonsHolder)
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
                .To<GameStarter>()
                .AsSingle();

            Container.Bind<GameModeSO>()
                .FromInstance(_defaultGameMode)
                .AsSingle();

            Container.Bind<GameConfigSO>()
                .FromInstance(_gameConfig)
                .AsSingle();

            Container.Bind<GameplayUITag>()
                .FromInstance(_gameplayUI)
                .AsSingle();

            Container.Bind<MetagameUITag>()
                .FromInstance(_metagameUI)
                .AsSingle();

            Container.Bind<AppStarter>()
                .FromInstance(_appStarter)
                .AsSingle()
                .NonLazy();

            Container.Bind<IUIInitializer>()
                .To<UIInitializer>()
                .AsSingle();

            Container.Bind<GameMediator>()
                .FromInstance(_gameMediator)
                .AsSingle();

            Container.Bind<IMetagameMediatorToLogic>()
                .FromInstance(_metagameMediatorToLogic)
                .AsSingle();

            Container.Bind<IMetagameMediatorToUI>()
                .FromInstance(_metagameMediatorToUI)
                .AsSingle();

            Container.Bind<IGameReseter>()
                .To<GameReseter>()
                .AsSingle();

            Container.Bind<IScaleHolder>()
                .FromInstance(_environmentScaleHolder)
                .AsSingle();

            Container.Bind<Dictionary<VisualPresetName, VisualsPresetSO>>()
                .FromInstance(PackGameplayVisualsToDictionary())
                .AsSingle();

            Container.Bind<VisualsPresetSO>()
                .FromInstance(_defaultGameplayVisuals)
                .AsSingle();

            Container.Bind<IGameplayZone>()
                .FromInstance(_gameplayZone)
                .AsSingle();

            Container.Bind<IEnvironmentObjectsDestroyer>()
                .To<EnvironmentObjectsDestroyer>()
                .AsSingle();

            Container.Bind<GameplayVisualsSetter>()
                .To<GameplayVisualsSetter>()
                .AsSingle();

            Container.Bind<VisualsPresetHolder>()
                .To<VisualsPresetHolder>()
                .AsSingle();

            Container.Bind<IEnvironmentFramer>()
                .To<EnvironmentFramer>()
                .AsSingle();

            Container.Bind<MenuWindow>()
                .FromInstance(_menuWindow)
                .AsSingle();

            Container.Bind<SettingsWindow>()
                .FromInstance(_settingsWindow)
                .AsSingle();

            Container.Bind<IWindowHolder>()
                .To<MetagameWindowHolder>()
                .AsSingle();

            Container.Bind<IStartGameButton>()
                .FromInstance(_startGameButton)
                .AsSingle();

            Container.Bind<CombosTemplatesHolder>()
                .To<CombosTemplatesHolder>()
                .AsSingle();

            Container.Bind<Dictionary<CombosTemplatesName, CombosTemplatesSO>>()
                .FromInstance(PackCombosTemplatesToDictionary())
                .AsSingle();

            Container.Bind<IComboConverter>()
                .To<SimpleComboConverter>()
                .AsSingle();

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

        private Dictionary<VisualPresetName, VisualsPresetSO> PackGameplayVisualsToDictionary()
        {
            Dictionary<VisualPresetName, VisualsPresetSO> gameplayVisuals = new Dictionary<VisualPresetName, VisualsPresetSO>
            {
                { VisualPresetName.Default, _gameplayVisuals }
            };
            return gameplayVisuals;
        }

        private Dictionary<CombosTemplatesName, CombosTemplatesSO> PackCombosTemplatesToDictionary()
        {
            Dictionary<CombosTemplatesName, CombosTemplatesSO> combosTemplates = new Dictionary<CombosTemplatesName, CombosTemplatesSO>
            {
                { CombosTemplatesName.Default, _defaultCombosTemplates },
                { CombosTemplatesName.ThreeSymbols, _threeSymbolsCombosTemplates },
                { CombosTemplatesName.FiveSymbols, _fiveSymbolsCombosTemplates },
                { CombosTemplatesName.SevenSymbols, _sevenSymbolsCombosTemplates }
            };
            return combosTemplates;
        }
    }
}

