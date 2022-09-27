using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL
{
    public class PoWerUSchema:Schema
    {
        public PoWerUSchema(IServiceProvider resolver):base(resolver)
        {
            Query = (IObjectGraphType)resolver.GetService(typeof(PoWerUQuery));
            Mutation = (IObjectGraphType)resolver.GetService(typeof(PowerUMutation));

        }

    }
}
