using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class ProviderInputType:InputObjectGraphType
    {
        public ProviderInputType()
        {
            Name = "ProviderInput";
            Field<NonNullGraphType<StringGraphType>>("Provider_Email");
            Field<NonNullGraphType<StringGraphType>>("Provider_Name");
            Field<NonNullGraphType<StringGraphType>>("Provider_Password");
        }

    }
}
