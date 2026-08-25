using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.SplitOffsets
{
    public class SplitOffsetsComponent : LogicComponent
    {
        public override string ComponentName => "Split Offsets";

        public SplitOffsetsSettings Settings { get; set; }

        private LiveSplitState _state;
        private TimeSpan _injectedOffset = TimeSpan.Zero;
        private List<TimeSpan> _parsedOffsets = new List<TimeSpan>();

        private static readonly Dictionary<string, Regex> _regexCache = new Dictionary<string, Regex>
        {
            { "Square Brackets [ ]", new Regex(@"\[(-?[0-9:\.]+)\]", RegexOptions.Compiled) },
            { "Parentheses ( )",     new Regex(@"\((-?[0-9:\.]+)\)", RegexOptions.Compiled) },
            { "Curly Braces { }",    new Regex(@"\{(-?[0-9:\.]+)\}", RegexOptions.Compiled) },
            { "Angle Brackets < >",  new Regex(@"<(-?[0-9:\.]+)>", RegexOptions.Compiled) }
        };

        public SplitOffsetsComponent(LiveSplitState state)
        {
            _state = state;
            Settings = new SplitOffsetsSettings();

            _state.OnStart += State_OnStart;
            _state.OnSplit += State_OnSplit;
            _state.OnUndoSplit += State_OnUndoSplit;
            _state.OnSkipSplit += State_OnSkipSplit;
            _state.OnReset += State_OnReset;
        }

        private Regex GetOffsetRegex()
        {
            if (_regexCache.TryGetValue(Settings.TagEnclosure, out Regex regex))
            {
                return regex;
            }
            return _regexCache["Square Brackets [ ]"];
        }

        private void State_OnStart(object sender, EventArgs e)
        {
            if (!Settings.EnableOffsets)
                return;

            _parsedOffsets.Clear();

            for (int i = 0; i < _state.Run.Count; i++)
            {
                _parsedOffsets.Add(GetOffset(_state.Run[i].Name));
            }

            SyncGameTime();
        }

        private void State_OnSplit(object sender, EventArgs e) => SyncGameTime();

        private void State_OnUndoSplit(object sender, EventArgs e) => SyncGameTime();
        private void State_OnSkipSplit(object sender, EventArgs e) => SyncGameTime();

        private void State_OnReset(object sender, TimerPhase value)
        {
            _injectedOffset = TimeSpan.Zero;
            _parsedOffsets.Clear();
        }

        private void SyncGameTime()
        {
            if (!Settings.EnableOffsets || _state.CurrentPhase == TimerPhase.NotRunning) 
                return;

            TimeSpan targetOffset = TimeSpan.Zero;
            int maxIndex = Math.Min(_state.CurrentSplitIndex, _state.Run.Count - 1);

            for (int i = 0; i <= maxIndex; i++)
            {
                if (i < _parsedOffsets.Count)
                    targetOffset += _parsedOffsets[i];
            }

            TimeSpan difference = targetOffset - _injectedOffset;

            if (difference != TimeSpan.Zero)
            {
                TimeSpan currentGameTime = _state.CurrentTime.GameTime ?? TimeSpan.Zero;
                _state.SetGameTime(currentGameTime + difference);
                _injectedOffset = targetOffset; 
            }
        }

        private TimeSpan GetOffset(string splitName)
        {
            Match match = GetOffsetRegex().Match(splitName);
            if (!match.Success)
                return TimeSpan.Zero;

            string rawValue = match.Groups[1].Value;
            bool isNegative = rawValue.StartsWith("-");
            string timeString = rawValue.TrimStart('-');

            string[] timeFormats = new[]
            {
                @"m\:ss\.fff", @"m\:ss\.ff", @"m\:ss\.f", @"m\:ss",
                @"mm\:ss\.fff", @"mm\:ss\.ff", @"mm\:ss\.f", @"mm\:ss",
                @"h\:mm\:ss\.fff", @"h\:mm\:ss\.ff", @"h\:mm\:ss\.f", @"h\:mm\:ss"
            };

            if (TimeSpan.TryParseExact(timeString, timeFormats, CultureInfo.InvariantCulture, out TimeSpan parsedSpan))
            {
                return isNegative ? -parsedSpan : parsedSpan;
            }

            if (double.TryParse(timeString, NumberStyles.Float, CultureInfo.InvariantCulture, out double seconds))
            {
                TimeSpan span = TimeSpan.FromSeconds(seconds);
                return isNegative ? -span : span;
            }

            return TimeSpan.Zero;
        }

        public override Control GetSettingsControl(LayoutMode mode) => Settings;
        public override XmlNode GetSettings(XmlDocument document) => Settings.GetSettings(document);
        public override void SetSettings(XmlNode settings) => Settings.SetSettings(settings);

        public override void Dispose()
        {
            _state.OnStart -= State_OnStart;
            _state.OnSplit -= State_OnSplit;
            _state.OnUndoSplit -= State_OnUndoSplit;
            _state.OnSkipSplit -= State_OnSkipSplit;
            _state.OnReset -= State_OnReset;
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
    }
}