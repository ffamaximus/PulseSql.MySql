// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using PulseSql.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;
using PulseSql.EntityFrameworkCore.MySql.Query.Internal;

namespace PulseSql.EntityFrameworkCore.MySql.Json.Newtonsoft.Query.Internal
{
    public class MySqlJsonNewtonsoftMemberTranslatorPlugin : IMemberTranslatorPlugin
    {
        public MySqlJsonNewtonsoftMemberTranslatorPlugin(
            IRelationalTypeMappingSource typeMappingSource,
            ISqlExpressionFactory sqlExpressionFactory,
            IMySqlJsonPocoTranslator jsonPocoTranslator)
        {
            var mySqlSqlExpressionFactory = (MySqlSqlExpressionFactory)sqlExpressionFactory;
            var mySqlJsonPocoTranslator = (MySqlJsonPocoTranslator)jsonPocoTranslator;

            Translators = new IMemberTranslator[]
            {
                new MySqlJsonNewtonsoftDomTranslator(
                    mySqlSqlExpressionFactory,
                    typeMappingSource,
                    mySqlJsonPocoTranslator),
                jsonPocoTranslator,
            };
        }

        public virtual IEnumerable<IMemberTranslator> Translators { get; }
    }
}
