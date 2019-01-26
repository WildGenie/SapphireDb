﻿using RealtimeDatabase.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using RealtimeDatabase.Helper;

// ReSharper disable PossibleMultipleEnumeration

namespace RealtimeDatabase.Models.Prefilter
{
    class ThenOrderByPrefilter : IPrefilter
    {
        public string SelectFunctionString { get; set; }

        public Dictionary<string, string> ContextData { get; set; }

        public bool Descending { get; set; }

        public IEnumerable<object> Execute(IEnumerable<object> array)
        {
            if (array.Any())
            {
                try
                {
                    Func<object, IComparable> function = SelectFunctionString.CreateFunction(array.FirstOrDefault()?.GetType(), ContextData)
                        .MakeDelegate<Func<object, IComparable>>();

                    IOrderedEnumerable<object> orderedArray = (IOrderedEnumerable<object>)array;

                    if (Descending)
                    {
                        return orderedArray.ThenByDescending(function);
                    }

                    return orderedArray.ThenBy(function);
                }
                catch
                {
                    // ignored
                }
            }

            return array;
        }
    }
}
