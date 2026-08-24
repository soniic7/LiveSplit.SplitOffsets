using System;
using LiveSplit.Model;
using LiveSplit.SplitOffsets;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(SplitOffsetsFactory))]

namespace LiveSplit.SplitOffsets
{
    public class SplitOffsetsFactory : IComponentFactory
    {
        public string ComponentName => "Split Offsets";
        public string Description => "Automatically adjusts Game Time based on offset tags in split names.";
        public ComponentCategory Category => ComponentCategory.Control;

        public IComponent Create(LiveSplitState state) => new SplitOffsetsComponent(state);

        public string UpdateName => ComponentName;
        public string UpdateURL => "";
        public string XMLURL => "";
        public string BaseSolverURL => "";
        public Version Version => Version.Parse("1.0.0");
    }
}