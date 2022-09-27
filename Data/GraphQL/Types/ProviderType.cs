using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class ProviderType : ObjectGraphType<ProviderEntity>
    {
        public ProviderType()
        {
            Field(t => t.Provider_Email);
            Field(t => t.Provider_Name);
            Field(t => t.Provider_Password);
        }
    }
}
