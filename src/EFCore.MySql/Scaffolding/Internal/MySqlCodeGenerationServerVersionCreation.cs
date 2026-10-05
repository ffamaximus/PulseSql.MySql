// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using PulseSql.EntityFrameworkCore.MySql.Storage;

namespace PulseSql.EntityFrameworkCore.MySql.Scaffolding.Internal
{
    internal class MySqlCodeGenerationServerVersionCreation
    {
        public ServerVersion ServerVersion { get; }

        public MySqlCodeGenerationServerVersionCreation(ServerVersion serverVersion)
        {
            ServerVersion = serverVersion;
        }
    }
}
