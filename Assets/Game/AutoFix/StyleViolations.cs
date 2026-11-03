using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace RoslynRulesTest.Assets.Game.AutoFix
{
    class StyleViolations
    {
        private int _counter = 0;
        private string _title = "demo";
        private int _seed = 5;
        private readonly string _stableTitle = "stable";
        private Action? _changed = static () => { };

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int Counter { get { return _counter; } set { _counter = value; } }

        public StyleViolations()
        {
            _counter = 0;
        }

        public int Add(int left, int right)
        {
            return (left) + right;
        }

        public bool IsPositive(int value)
        {
            if (value > 0) return true;
            else return false;
        }

        public string Run(string? input)
        {
            string label = string.Format("value: {0}", input);
            List<string> values = new List<string>();
            values.Add(label);
            values.Add(_stableTitle);

            var person = new Person();
            person.Name = label;

            var pair = (person.Name, values.Count);
            var anonymous = new { person.Name, values.Count };

            int parsed;
            if (int.TryParse(input, out parsed))
            {
                this._counter = this._counter + parsed;
            }

            var last = values[values.Count - 1];
            var segment = input == null ? "empty" : input.Substring(0, Math.Min(2, input.Length));
            var name = person == null ? "unknown" : person.Name;
            var display = input != null ? input.Length.ToString() : "0";

            object candidate = person;
            if (candidate is Person)
            {
                var castPerson = (Person)candidate;
                label = castPerson.Name;
            }

            object? maybePerson = person as object;
            if (maybePerson != null)
            {
                label = maybePerson.ToString()!;
            }

            string kind;
            switch (values.Count)
            {
                case 0: kind = "none"; break;
                case 1: kind = "one"; break;
                default: kind = "many"; break;
            }

            if (!(input is null))
            {
                label = input;
            }

            Func<int, int> square = x => { return x * x; };
            Func<string, int> length = value => value.Length;
            var sum = square(values.Count) + length(label) + _seed + (parsed * 2 + 1);

            (int, int) coordinates = (1, 2);
            var x = coordinates.Item1;
            var y = coordinates.Item2;
            var temporary = x;
            x = y;
            y = temporary;

            string tail = label.Substring(Math.Max(0, label.Length - 1));
            var formatted = $"{input}";
            var flag = IsPositive(sum) == true;
            var referenceNull = ReferenceEquals(input, null);
            var nested = new NestedPerson();
            nested.Address.City = "Berlin";
            var known = IsKnown(nested);
            var maxValue = System.Int32.MaxValue;

            if (_changed != null)
            {
                _changed();
            }

            if (input == null)
            {
                input = "fallback";
            }

            var builder = new StringBuilder();
            builder.Append(sum.ToString());
            builder.Append("!");

            return string.Join(",", values) + kind + tail + formatted + flag + builder + maxValue + referenceNull + known + pair.Item1 + anonymous.Name + last + segment + name + display + this.Add(1, 2) + this.Counter + this.Title;
        }

        public static ReadOnlySpan<byte> Utf8Marker() => "sample"u8;

        public static string DefaultLabel(string? value) => value ?? default(string);

        public static int Calculate(int value)
        {
            int DoubleIt(int number)
            {
                return number * 2;
            }

            return DoubleIt(value);
        }

        public void IgnoreResult()
        {
            "unused".ToString();
            var result = Calculate(1);
            result = Calculate(2);
        }

        private sealed class Person
        {
            public string Name { get; set; } = string.Empty;
        }

        private sealed class NestedPerson
        {
            public Address Address { get; set; } = new Address();
        }

        private sealed class Address
        {
            public string City { get; set; } = string.Empty;
        }

        private static bool IsKnown(NestedPerson person)
        {
            return person is { Address.City: "Berlin" };
        }
    }
}
