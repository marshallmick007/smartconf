﻿using System;
using System.Collections.Generic;

namespace SmartConf
{
    /// <summary>
    /// A source for creating configuration objects of
    /// type <typeparam name="T"></typeparam>.
    /// </summary>
    public interface IConfigurationSource<T> where T : class
    {
        /// <summary>
        /// Indicate that this source should be the default
        /// source to save changes to.
        /// </summary>
        bool PrimarySource { get; set; }

        /// <summary>
        /// Configuration object generated for this source.
        /// </summary>
        T Config { get; }

        /// <summary>
        /// Invalidate the configuration source, causing the next
        /// read to re-initialize the Config object.
        /// </summary>
        void Invalidate();

        /// <summary>
        /// Save the entire object to the config source.
        /// </summary>
        /// <param name="obj">Object to save.</param>
        /// <exception cref="InvalidOperationException">
        /// The IConfigurationSource does not support write operations.
        /// </exception>
        void Save(T obj);

        /// <summary>
        /// Save parts of the object to the config source.
        /// </summary>
        /// <param name="obj">Object to save.</param>
        /// <param name="propertyNames">
        /// List of property names that need saving.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// The IConfigurationSource does not support write operations.
        /// </exception>
        void PartialSave(T obj, IEnumerable<string> propertyNames);
    }
}
