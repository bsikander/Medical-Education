using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OracleClient;

namespace Utilities
{
    public static class DBParameterExtension
    {
        public static OracleParameter Clone(this OracleParameter param)
        {
            ICloneable cloneableParameter = param as ICloneable;

            if (cloneableParameter != null)
            {
                return cloneableParameter.Clone() as OracleParameter;
            }
            else
            {
                throw new ApplicationException(
                    string.Format("Unable to clone parameter {0}",
                    param.ParameterName));
            }
        }
    }
}
