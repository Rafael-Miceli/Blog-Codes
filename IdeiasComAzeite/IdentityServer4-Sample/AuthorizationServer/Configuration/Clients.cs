﻿using IdentityServer4.Core.Models;
using System.Collections.Generic;

namespace AuthorizationServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new []
            {
                new Client
                {
                    ClientId = "teste",
                    ClientName = "Teste OAuth2",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    //Pequena mudança no nome dos Scopes comparado ao IdentityServe3
                    AllowedScopes  = new List<string> { StandardScopes.OpenId.Name },
                    Enabled = true
                }             
            };
        }
    }
}