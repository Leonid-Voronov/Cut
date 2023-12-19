using System.Collections.Generic;
using Zenject;

namespace GameplayVisualsFeature
{
    public class VisualsPresetHolder
    {
        private Dictionary<VisualPresetName, VisualsPresetSO> _visualPresets;
        private VisualsPresetSO _currentVisualPreset;
        public VisualsPresetSO CurrentVisualPreset => _currentVisualPreset;

        [Inject]
        public VisualsPresetHolder(Dictionary<VisualPresetName, VisualsPresetSO> visualPresets, VisualsPresetSO defaultVisualPreset)
        {
            _visualPresets = visualPresets;
            _currentVisualPreset = defaultVisualPreset;
        }

        public void SetCurrentVisualPreset(VisualPresetName visualPresetName)
        {
            _currentVisualPreset = _visualPresets[visualPresetName];
        }
    }

    public enum VisualPresetName
    {
        Default
    }
}

