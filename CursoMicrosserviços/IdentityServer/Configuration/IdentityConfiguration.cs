using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        //Perfis dos usuarios(perfis) que irao existir na aplicao cliente e que irao requisitar coisas no backend
        public const string Admin = "Admin";
        public const string Client = "Client";

        //Definindo as Claims, informações da identificação do usuário. Recursos protegisdos pelo Identity Server
        public static IEnumerable<IdentityResource> IdentityResources =>  
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(), 
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        //Recursos que uma api pode acessar. Nome da role e nome que a role possui para ser mostrada. Fazia algo parecido assim na azure. 
        //Um escopo [e usado por um Client.
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read",displayName: "Read data."),
                new ApiScope(name: "write","Write data."),
                new ApiScope(name: "delete","Delete data.")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client()
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //Credenciais que o client ira usar. Vai precisar das credenciais do usuario para acessar
                    AllowedScopes = {"read", "write", "profile"} // permissoes para ler, escrever e acessar o perfile
                },
                new Client()
                {
                    ClientId = "geek_shopping",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //Credenciais que o client ira usar. Vai precisar das credenciais do usuario para acessar
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:4430/signin-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "geek_shopping"
                    }, 
                }
            };
    }
}
