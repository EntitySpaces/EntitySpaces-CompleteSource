/*
===============================================================================
                     EntitySpaces(TM) by EntitySpaces, LLC
                 A New 2.0 Architecture for the .NET Framework
                          http://www.entityspaces.net
===============================================================================
                       EntitySpaces Version # 2007.0.0730.0
                       MyGeneration Version # 1.2.0.7
                           7/30/2007 5:51:12 PM
-------------------------------------------------------------------------------
*/


using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
    public partial class ComputedTest : esComputedTest
    {
        #region Custom Entity Tests

        public string GetDescriptionDoubleQuoteTest()
        {
            return this.Meta.Columns["DateAdded"].Description;
        }

        public string GetDescriptionBackSlashTest()
        {
            return this.Meta.Columns["SomeDate"].Description;
        }
    }

        # endregion
}
