/*===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:17 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

#if(!SILVERLIGHT)
using System.ServiceModel.DomainServices.Server;
#endif

namespace BusinessObjects
{
	public partial class Suppliers
	{

#if(SILVERLIGHT)

		[Display(AutoGenerateField=false)]
		public Dictionary<string, object> esExtraColumns
		{
			get
			{
				if (_esExtraColumns == null)
				{
					if (this.esExtendedData != null)
					{
						_esExtraColumns = esDataContractSerializer.FromXml(this.esExtendedData,
							typeof(Dictionary<string, object>))
							as Dictionary<string, object>;
					}
					else
					{
						_esExtraColumns = new Dictionary<string, object>();
					}
				}

				return _esExtraColumns;
			}

			set { }


		}
		private Dictionary<string, object> _esExtraColumns;
#endif

	}
}	