using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Api.Core.Extensions
{
    public static class CommandExtensions
    {
        public static void ConfigureCommand(this DbCommand command, string storedProcedureName)
        {
            command.CommandTimeout = 120;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
        }
    }
}
