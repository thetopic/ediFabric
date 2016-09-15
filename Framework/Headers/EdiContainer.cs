﻿
//---------------------------------------------------------------------
// This file is part of ediFabric
//
// Copyright (c) ediFabric. All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using EdiFabric.Framework.Constants;

namespace EdiFabric.Framework.Headers
{
    /// <summary>
    /// EDI container interface
    /// </summary>
    public interface IEdiGroup
    {
        /// <summary>
        /// Generates a collection of EDI strings.
        /// </summary>
        /// <param name="separators">The EDI separators.</param>
        /// <returns>The collection of EDI strings.</returns>
        IEnumerable<string> GenerateEdi(Separators separators);
    }

    /// <summary>
    /// THis class represents an EDI interchange or group
    /// </summary>
    /// <typeparam name="T">The header type.</typeparam>
    /// <typeparam name="TU">The items type - the group type if the container is an interchange or the messages type if the container is a group.</typeparam>
    /// <typeparam name="TV">The trailer type.</typeparam>
    public class EdiContainer<T, TU, TV> 
    {
        /// <summary>
        /// The header (ISA or UNB)
        /// </summary>
        public T Header { get; private set; }
        private readonly Func<T, int, TV> _trailerSetter;
        private readonly List<TU> _items = new List<TU>();
        /// <summary>
        /// The items (groups or messages)
        /// </summary>
        public IReadOnlyCollection<TU> Items
        {
            get { return _items.AsReadOnly(); }
        }
        /// <summary>
        /// The trailer (IEA or UNZ)
        /// </summary>
        public TV Trailer { get; private set; }
        
        /// <summary>
        /// Protected constructor. 
        /// </summary>
        /// <param name="header">The header type.</param>
        /// <param name="trailerSetter">The function to set the trailer.</param>
        protected EdiContainer(T header, Func<T, int, TV> trailerSetter)
        {
            if (header == null) throw new ArgumentNullException("header");
            if (trailerSetter == null) throw new ArgumentNullException("trailerSetter");

            Header = header;
            _trailerSetter = trailerSetter;
        }

        /// <summary>
        /// Adds an item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(TU item)
        {
            if (item == null) throw new ArgumentNullException("item");

            _items.Add(item);
            Trailer = _trailerSetter(Header, _items.Count);
        }

        /// <summary>
        /// Adds a collection of items.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddItems(IEnumerable<TU> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            _items.AddRange(items);
            Trailer = _trailerSetter(Header, _items.Count);
        }

        /// <summary>
        /// Generates a collection of EDI strings.
        /// </summary>
        /// <param name="separators">The EDI separators.</param>
        /// <returns>The collection of EDI strings.</returns>
        public IEnumerable<string> GenerateEdi(Separators separators)
        {
            var result = new List<string>();

            result.AddRange(ToEdi(Header, separators));
            foreach (var item in Items)
            {
                var group = item as IEdiGroup;
                result.AddRange(group != null ? group.GenerateEdi(separators) : ToEdi(item, separators));
            }
            result.AddRange(ToEdi(Trailer, separators));

            return result;
        }

        private static IEnumerable<string> ToEdi(object item, Separators separators)
        {
            var parseTree = ParseNode.BuldTree(item);
            var segments = parseTree.Descendants().Where(d => d.Prefix == Prefixes.S).Reverse();
            return segments.Select(segment => segment.GenerateSegment(separators));
        }
    }
}

