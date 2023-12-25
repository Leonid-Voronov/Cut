using GameModeFeature;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ComboSwitchingFeature
{
    public class ComboConverterHolder
    {
        private Dictionary<ComboDisplayMode, IComboConverter> _comboConverters = new Dictionary<ComboDisplayMode, IComboConverter>();
        private IComboConverter _currentComboConverter;
        public IComboConverter CurrentComboConverter => _currentComboConverter;
        [Inject]
        public ComboConverterHolder(SimpleComboConverter simpleComboConverter, MathComboConverter mathComboConverter) 
        {
            _comboConverters.Add(ComboDisplayMode.Standard, simpleComboConverter);
            _comboConverters.Add(ComboDisplayMode.MathEquation, mathComboConverter);
            _currentComboConverter = simpleComboConverter;
        }

        public void SetComboConverter(ComboDisplayMode comboDisplayMode) { _currentComboConverter = _comboConverters[comboDisplayMode]; }
    }
}